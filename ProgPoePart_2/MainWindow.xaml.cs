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

        private string previousTopic = "";
        
        public MainWindow()
        {
            InitializeComponent();

            // Initialize services
            userMemory = new UserMemory();
            keywordHandler = new KeywordHandler();
            responseManager = new ResponseManager();
            sentimentAnalyzer = new SentimentAnalyzer();
            voiceManager = new VoiceManager();

            // Welcome message
            AddBotMessage("Welcome to the Cybersecurity Awareness Chatbot!");
            AddBotMessage("Please tell me your name to begin.");

            // Play welcome WAV file
            voiceManager.PlayVoice();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text.Trim();

            if (string.IsNullOrEmpty(userMessage))
            {
                return;
            }

            AddUserMessage(userMessage);

            string botResponse = ProcessMessage(userMessage);

            AddBotMessage(botResponse);

            // Play WAV file when bot replies
            voiceManager.PlayVoice();

            UserInput.Clear();
        }

        private string ProcessMessage(string message)
        {
            string lowerMessage = message.ToLower();

            // Memory: remember name
            if (lowerMessage.StartsWith("my name is"))
            {
                string name = message.Substring(10).Trim();
                userMemory.UserName = name;
                return $"Nice to meet you, {name}! How can I help you with cybersecurity today?";
            }

            // Memory recall
            if (lowerMessage.Contains("what do you remember"))
            {
                if (!string.IsNullOrEmpty(userMemory.UserName))
                {
                    return $"I remember that your name is {userMemory.UserName}.";
                }
                else
                {
                    return "I do not know your name yet. Please tell me your name.";
                }
            }

            // Conversation flow
            if (lowerMessage.Contains("tell me more") || lowerMessage.Contains("explain more"))
            {
                if (!string.IsNullOrEmpty(previousTopic))
                {
                    return responseManager.GetMoreInfo(previousTopic);
                }
                else
                {
                    return "Please tell me which cybersecurity topic you want to know more about.";
                }
            }

            // Sentiment detection
            string sentimentResponse = sentimentAnalyzer.AnalyzeSentiment(lowerMessage);
            if (!string.IsNullOrEmpty(sentimentResponse))
            {
                return sentimentResponse;
            }

            // Keyword recognition
            string keyword = keywordHandler.GetKeyword(message);

            if (!string.IsNullOrEmpty(keyword))
            {
                previousTopic = keyword;
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
    }
}