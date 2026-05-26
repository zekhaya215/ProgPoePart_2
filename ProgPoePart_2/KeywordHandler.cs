namespace ProgPoePart_2.Services
{
    public class KeywordHandler
    {
        public string GetKeyword(string message)
        {
            string lowerMessage = message.ToLower();

            if (lowerMessage.Contains("password"))
                return "password";

            if (lowerMessage.Contains("phishing"))
                return "phishing";

            if (lowerMessage.Contains("scam"))
                return "scam";

            if (lowerMessage.Contains("privacy"))
                return "privacy";

            if (lowerMessage.Contains("malware"))
                return "malware";

            if (lowerMessage.Contains("hacking"))
                return "hacking";

            if (lowerMessage.Contains("virus"))
                return "virus";

            return "";
        }
    }
}