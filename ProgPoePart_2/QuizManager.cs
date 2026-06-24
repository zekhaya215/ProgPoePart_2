using ProgPoePart_2.Models;
using System.Collections.Generic;

namespace ProgPoePart_2.Services
{
    public class QuizManager
    {
        private List<QuizQuestion> questions;

        private int currentIndex;
        
        private int score;

        public QuizManager()
        {
            questions = new List<QuizQuestion>();

            LoadQuestions();

            currentIndex = 0;

            score = 0;
        }

        private void LoadQuestions()
        {
            questions.Add(new QuizQuestion
            {
                Question = "What should you do if you receive an email asking for your password?",
                Options = new List<string>
                {
                    "Reply with your password",
                    "Delete the email",
                    "Report the email as phishing",
                    "Ignore it"
                },
                CorrectAnswer = "Report the email as phishing",
                Explanation = "Reporting phishing emails helps prevent scams."
            });

            questions.Add(new QuizQuestion
            {
                Question = "True or False: You should use the same password everywhere.",
                Options = new List<string>
                {
                    "True",
                    "False"
                },
                CorrectAnswer = "False",
                Explanation = "Every account should have a unique password."
            });

            questions.Add(new QuizQuestion
            {
                Question = "What does 2FA stand for?",
                Options = new List<string>
                {
                    "Two Factor Authentication",
                    "Two File Access",
                    "Fast Authentication",
                    "File Authorization"
                },
                CorrectAnswer = "Two Factor Authentication",
                Explanation = "2FA adds an extra security layer."
            });

            questions.Add(new QuizQuestion
            {
                Question = "Which website is generally safer?",
                Options = new List<string>
                {
                    "http://example.com",
                    "https://example.com",
                    "Both are identical",
                    "Neither"
                },
                CorrectAnswer = "https://example.com",
                Explanation = "HTTPS encrypts data."
            });

            questions.Add(new QuizQuestion
            {
                Question = "What is phishing?",
                Options = new List<string>
                {
                    "A fishing hobby",
                    "A cyberattack that steals information",
                    "An antivirus",
                    "A browser"
                },
                CorrectAnswer = "A cyberattack that steals information",
                Explanation = "Phishing tricks users into revealing data."
            });

            questions.Add(new QuizQuestion
            {
                Question = "True or False: Public Wi-Fi is always secure.",
                Options = new List<string>
                {
                    "True",
                    "False"
                },
                CorrectAnswer = "False",
                Explanation = "Public Wi-Fi can be risky."
            });

            questions.Add(new QuizQuestion
            {
                Question = "What does malware do?",
                Options = new List<string>
                {
                    "Protects files",
                    "Improves internet speed",
                    "Damages systems or steals information",
                    "Creates passwords"
                },
                CorrectAnswer = "Damages systems or steals information",
                Explanation = "Malware is harmful software."
            });

            questions.Add(new QuizQuestion
            {
                Question = "What should you do before clicking a link?",
                Options = new List<string>
                {
                    "Click immediately",
                    "Verify the source",
                    "Share it",
                    "Ignore it"
                },
                CorrectAnswer = "Verify the source",
                Explanation = "Always check the sender first."
            });

            questions.Add(new QuizQuestion
            {
                Question = "True or False: Antivirus software helps protect your device.",
                Options = new List<string>
                {
                    "True",
                    "False"
                },
                CorrectAnswer = "True",
                Explanation = "Antivirus software helps detect threats."
            });

            questions.Add(new QuizQuestion
            {
                Question = "What is social engineering?",
                Options = new List<string>
                {
                    "Building social networks",
                    "Manipulating people into giving information",
                    "Programming websites",
                    "Creating passwords"
                },
                CorrectAnswer = "Manipulating people into giving information",
                Explanation = "Social engineering targets people rather than systems."
            });
        }

        public QuizQuestion GetCurrentQuestion()
        {
            if (currentIndex < questions.Count)
            {
                return questions[currentIndex];
            }

            return null;
        }

        public bool SubmitAnswer(string answer)
        {
            bool correct =
                questions[currentIndex].CorrectAnswer == answer;

            if (correct)
            {
                score++;
            }

            currentIndex++;

            return correct;
        }

        public string GetFeedback(bool correct)
        {
            return questions[currentIndex - 1].Explanation;
        }

        public bool IsFinished()
        {
            return currentIndex >= questions.Count;
        }

        public string GetFinalScore()
        {
            return $"{score} / {questions.Count}";
        }

        public string GetFinalMessage()
        {
            if (score >= 8)
            {
                return "Excellent cybersecurity knowledge!";
            }

            if (score >= 5)
            {
                return "Good effort. Keep learning!";
            }

            return "You should spend more time learning cybersecurity basics.";
        }

        public void ResetQuiz()
        {
            currentIndex = 0;

            score = 0;
        }
    }
}