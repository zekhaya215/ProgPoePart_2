using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgPoePart_2.Services
{
    public class ActivityLogger
    {
        private List<string> log = new List<string>();

        public void Log(string action)
        {
            log.Add($"[{DateTime.Now:HH:mm}] {action}");
        }

        public string GetRecentLog(int count = 10)
        {
            var recent = log.TakeLast(count).ToList();

            string output = "";

            for (int i = 0; i < recent.Count; i++)
            {
                output += $"{i + 1}. {recent[i]}\n";
            }

            return output;
        }

        public string GetFullLog()
        {
            string output = "";

            for (int i = 0; i < log.Count; i++)
            {
                output += $"{i + 1}. {log[i]}\n";
            }

            return output;
        }

        public int GetCount()
        {
            return log.Count;
        }
    }
}