using System;
using System.Collections.Generic;

namespace ProgPoePart_2.Services
{
    public class ResponseManager
    {
        private Random random = new Random();

        private Dictionary<string, List<string>> responses;

        public ResponseManager()
        {
            responses = new Dictionary<string, List<string>>
            {
                {
                    "password",
                    new List<string>
                    {
                        "Use a strong password with letters, numbers, and symbols.",
                        "Never use easy passwords like 123456 or password.",
                        "Change your passwords regularly and keep them private."
                    }
                },

                {
                    "phishing",
                    new List<string>
                    {
                        "Phishing attacks trick users into revealing sensitive information.",
                        "Do not click suspicious links in emails or messages.",
                        "Always verify the sender before opening links."
                    }
                },

                {
                    "scam",
                    new List<string>
                    {
                        "Scams often try to steal money or personal information.",
                        "Never share banking details with unknown people.",
                        "Be cautious of offers that seem too good to be true."
                    }
                },

                {
                    "privacy",
                    new List<string>
                    {
                        "Protect your privacy by limiting what you share online.",
                        "Review privacy settings on your social media accounts.",
                        "Never post sensitive personal information publicly."
                    }
                },

                {
                    "malware",
                    new List<string>
                    {
                        "Malware is harmful software that damages systems or steals data.",
                        "Install antivirus software to protect your computer.",
                        "Avoid downloading files from untrusted websites."
                    }
                },

                {
                    "hacking",
                    new List<string>
                    {
                        "Hackers try to gain unauthorized access to systems.",
                        "Keep software updated to reduce security risks.",
                        "Use strong passwords and enable two-factor authentication."
                    }
                },

                {
                    "virus",
                    new List<string>
                    {
                        "Computer viruses can spread and damage files.",
                        "Use antivirus software to detect threats.",
                        "Avoid opening suspicious attachments."
                    }
                }
            };
        }

        public string GetRandomResponse(string keyword)
        {
            if (responses.ContainsKey(keyword))
            {
                List<string> topicResponses = responses[keyword];
                int index = random.Next(topicResponses.Count);
                return topicResponses[index];
            }

            return "I do not have information on that topic yet.";
        }

        public string GetMoreInfo(string topic)
        {
            switch (topic)
            {
                case "password":
                    return "Strong passwords should be long, unique, and should never be shared.";

                case "phishing":
                    return "Phishing messages often pretend to be from trusted companies to steal your information.";

                case "scam":
                    return "Scammers use deception to trick victims into giving money or sensitive information.";

                case "privacy":
                    return "Privacy means protecting personal information from unauthorized access.";

                case "malware":
                    return "Malware includes viruses, spyware, ransomware, and other harmful software.";

                case "hacking":
                    return "Hacking can involve stealing data, breaking into systems, or exploiting vulnerabilities.";

                case "virus":
                    return "A computer virus is malicious code that spreads between systems and damages files.";

                default:
                    return "Please ask me about a cybersecurity topic.";
            }
        }
    }
}