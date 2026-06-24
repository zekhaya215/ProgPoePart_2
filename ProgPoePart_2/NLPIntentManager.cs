namespace ProgPoePart_2.Services
{
    public class NLPIntentManager
    {
        public bool IsTaskIntent(string message)
        {
            return message.Contains("add task") ||
                   message.Contains("add a task") ||
                   message.Contains("create task") ||
                   message.Contains("i need to") ||
                   message.Contains("enable") ||
                   message.Contains("set up");
        }

        public bool IsReminderIntent(string message)
        {
            return message.Contains("remind me") ||
                   message.Contains("reminder") ||
                   message.Contains("set reminder") ||
                   message.Contains("set a reminder") ||
                   message.Contains("don't forget");
        }

        public bool IsQuizIntent(string message)
        {
            return message.Contains("start quiz") ||
                   message.Contains("take quiz") ||
                   message.Contains("quiz me") ||
                   message.Contains("test my knowledge") ||
                   message.Contains("play the game");
        }

        public bool IsLogIntent(string message)
        {
            return message.Contains("show activity log") ||
                   message.Contains("show log") ||
                   message.Contains("what have you done") ||
                   message.Contains("what did you do") ||
                   message.Contains("recent actions");
        }
    }
}