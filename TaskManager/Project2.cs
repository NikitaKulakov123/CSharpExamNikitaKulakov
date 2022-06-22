using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class Project2
    {
        public string name = "null";
        public string description = "null";

        public Task2[] tasks = new Task2[0];

        public Project2(string _name, string _description)
        {
            if (String.IsNullOrEmpty(_name))
            {
                name = "New project";
            }
            else
            {
                name = _name;
            }

            description = _description;
        }

        public void AddTask(string taskName, string taskDescription, char taskImportanceLevel)
        {
            Array.Resize(ref tasks, tasks.Length + 1);
            tasks[tasks.Length - 1] = new Task2(taskName, taskDescription, taskImportanceLevel, "null");
            tasks[tasks.Length - 1].startTime = DateTime.Now.ToString();
        }
    }
}
