namespace ProgPoePart_2.Services
{
    public class SentimentAnalyzer
    {
        public string AnalyzeSentiment(string message)
        {
            // Worried sentiment
            if (message.Contains("worried") || message.Contains("scared") || message.Contains("afraid"))
            {
                return "It sounds like you are worried. Cybersecurity can feel overwhelming, but staying informed helps you stay safe.";
            }

            // Frustrated sentiment
            if (message.Contains("frustrated") || message.Contains("angry") || message.Contains("upset"))
            {
                return "I understand this may be frustrating. Let me help you with cybersecurity advice step by step.";
            }

            // Curious sentiment
            if (message.Contains("curious") || message.Contains("interested") || message.Contains("want to learn"))
            {
                return "That is great! Learning about cybersecurity is one of the best ways to stay protected online.";
            }

            // Confused sentiment
            if (message.Contains("confused") || message.Contains("don't understand") || message.Contains("not sure"))
            {
                return "No problem. Cybersecurity topics can be confusing at first, but I will explain them simply.";
            }

            // Happy sentiment
            if (message.Contains("happy") || message.Contains("excited"))
            {
                return "I’m glad you are feeling positive! Let’s continue learning about cybersecurity.";
            }

            return "";
        }
    }
}