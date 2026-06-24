using ProgPoePart_2.Models;
using System.Collections.Generic;

namespace ProgPoePart_2.Services
{
    public class TaskManager
    {
        private TaskStorageHelper storage;
        private ActivityLogger logger;
        
        public TaskManager(ActivityLogger activityLogger)
        {
            storage = new TaskStorageHelper();
            logger = activityLogger;
        }

        public string AddTask(string title, string description, string reminder)
        {
            storage.AddTask(title, description, reminder);

            logger.Log($"Task added: '{title}'");

            return $"Task '{title}' added successfully.";
        }

        public List<CyberTask> GetAllTasks()
        {
            return storage.LoadTasks();
        }

        public void MarkAsComplete(int id)
        {
            storage.MarkAsComplete(id);

            logger.Log($"Task ID {id} marked as complete.");
        }

        public void DeleteTask(int id)
        {
            storage.DeleteTask(id);

            logger.Log($"Task ID {id} deleted.");
        }
    }
}