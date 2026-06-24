using ProgPoePart_2.Models;
using ProgPoePart_2.Services;
using System;
using System.Windows;

namespace ProgPoePart_2
{
    public partial class MainWindow : Window
    {
        private UserMemory userMemory;
        private KeywordHandler keywordHandler;
        private ResponseManager responseManager;
        private SentimentAnalyzer sentimentAnalyzer;
        private VoiceManager voiceManager;

        private ActivityLogger activityLogger;
        private TaskManager taskManager;
        private QuizManager quizManager;
        private NLPIntentManager intentManager;

        private string previousTopic = "";

        public MainWindow()
        {
            InitializeComponent();

            userMemory = new UserMemory();
            keywordHandler = new KeywordHandler();
            responseManager = new ResponseManager();
            sentimentAnalyzer = new SentimentAnalyzer();
            voiceManager = new VoiceManager();

            activityLogger = new ActivityLogger();
            taskManager = new TaskManager(activityLogger);
            quizManager = new QuizManager();
            intentManager = new NLPIntentManager();

            AddBotMessage("Welcome to the Cybersecurity Awareness Chatbot!");
            AddBotMessage("Please tell me your name to begin.");
            voiceManager.PlayVoice();

            LoadTasksToGrid();
        }

        // === CHATBOT ===
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text.Trim();
            if (string.IsNullOrEmpty(userMessage)) return;

            AddUserMessage(userMessage);
            string botResponse = ProcessMessage(userMessage);
            AddBotMessage(botResponse);
            voiceManager.PlayVoice();
            UserInput.Clear();
        }

        private string ProcessMessage(string message)
        {
            string lowerMessage = message.ToLower();

            if (lowerMessage.StartsWith("my name is"))
            {
                string name = message.Substring(10).Trim();
                userMemory.UserName = name;
                activityLogger.Log($"User introduced name: {name}");
                return $"Nice to meet you, {name}! How can I help you with cybersecurity today?";
            }

            if (intentManager.IsTaskIntent(lowerMessage))
            {
                string result = taskManager.AddTask("New Task", "Added via chat", "");
                activityLogger.Log("Task intent detected via chat");
                return result;
            }

            if (intentManager.IsReminderIntent(lowerMessage))
            {
                activityLogger.Log("Reminder set via chat");
                return "Reminder added!";
            }

            if (intentManager.IsQuizIntent(lowerMessage))
            {
                quizManager.ResetQuiz();
                NextQuestion_Click(null, null);
                activityLogger.Log("Quiz started");
                return "Starting quiz...";
            }

            if (intentManager.IsLogIntent(lowerMessage))
            {
                return activityLogger.GetRecentLog();
            }

            string sentimentResponse = sentimentAnalyzer.AnalyzeSentiment(lowerMessage);
            if (!string.IsNullOrEmpty(sentimentResponse))
            {
                activityLogger.Log("Sentiment detected");
                return sentimentResponse;
            }

            string keyword = keywordHandler.GetKeyword(message);
            if (!string.IsNullOrEmpty(keyword))
            {
                previousTopic = keyword;
                activityLogger.Log($"Keyword matched: {keyword}");
                return responseManager.GetRandomResponse(keyword);
            }

            return "I am sorry, I did not understand that. Please ask about cybersecurity topics like password safety, scams, phishing, or privacy.";
        }

        private void AddUserMessage(string message)
        {
            ChatDisplay.AppendText("YOU: " + message + Environment.NewLine + Environment.NewLine);
            ChatDisplay.ScrollToEnd();
        }

        private void AddBotMessage(string message)
        {
            ChatDisplay.AppendText("BOT: " + message + Environment.NewLine + Environment.NewLine);
            ChatDisplay.ScrollToEnd();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ChatDisplay.Clear();
            AddBotMessage("Chat cleared.");
            AddBotMessage("Welcome back! Ask me anything about cybersecurity.");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // === TASK ASSISTANT ===
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitleBox.Text;
            string desc = TaskDescriptionBox.Text;
            string reminder = TaskReminderBox.Text;

            string result = taskManager.AddTask(title, desc, reminder);
            AddBotMessage(result);
            LoadTasksToGrid();
        }

        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskGrid.SelectedItem is CyberTask task)
            {
                taskManager.MarkAsComplete(task.Id);
                AddBotMessage($"Task '{task.Title}' marked complete.");
                LoadTasksToGrid();
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskGrid.SelectedItem is CyberTask task)
            {
                taskManager.DeleteTask(task.Id);
                AddBotMessage($"Task '{task.Title}' deleted.");
                LoadTasksToGrid();
            }
        }

        private void LoadTasksToGrid()
        {
            TaskGrid.ItemsSource = taskManager.GetAllTasks();
        }

        // === QUIZ ===
        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            var question = quizManager.GetCurrentQuestion();
            if (question != null)
            {
                QuizQuestionText.Text = question.Question;
                QuizOptionsList.ItemsSource = question.Options;
                QuizFeedbackText.Text = "";
            }
            else
            {
                QuizScoreText.Text = quizManager.GetFinalScore();
                QuizFeedbackText.Text = quizManager.GetFinalMessage();
                activityLogger.Log("Quiz completed");
            }
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (QuizOptionsList.SelectedItem != null)
            {
                string answer = QuizOptionsList.SelectedItem.ToString();
                bool correct = quizManager.SubmitAnswer(answer);
                QuizFeedbackText.Text = quizManager.GetFeedback(correct);
                QuizScoreText.Text = $"Score: {quizManager.GetFinalScore()}";
                activityLogger.Log($"Quiz answer submitted: {answer} (Correct: {correct})");
            }
        }

        // === ACTIVITY LOG ===
        private void ShowMoreLog_Click(object sender, RoutedEventArgs e)
        {
            LogDisplay.Text = activityLogger.GetFullLog();
        }
    }
}
