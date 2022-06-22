using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class ProjectManager
    {
        public Project[] projects = new Project[0];

        public ProjectManager()
        {

        }

        public void AddProject(string projectName, string projectDescription)
        {
            Console.WriteLine();

            Array.Resize(ref projects, projects.Length + 1);
            projects[projects.Length - 1] = new Project(projectName, projectDescription);
        }

        public void NameExistCheck(int index, string name, bool isProject)
        {
            while (true)
            {
                int j = 0;

                if (isProject)
                {
                    for (int i = 0; i < projects.Length; i++)
                    {
                        if (projects[i].name.Equals(name))
                        {
                            j++;

                            Console.WriteLine("This project is already exists! Enter another name.");
                            name = Console.ReadLine();
                            projects[i].name = name;

                            break;
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < projects[index].tasks.Length; i++)
                    {
                        if (projects[index].tasks[i].name.Equals(name))
                        {
                            j++;

                            Console.WriteLine("This task is already exists! Enter another name.");
                            name = Console.ReadLine();
                            projects[index].tasks[i].name = name;

                            break;
                        }
                    }

                }

                if (j == 0)
                {
                    break;
                }
            }
        }

        public void PlanFinishTime(int projectIndex, int taskIndex, string day, string month, int year)
        {
            projects[projectIndex].tasks[taskIndex].plannedFinishTime = $"{day}.{month}.{year}";

            Console.WriteLine(projects[projectIndex].tasks[taskIndex].plannedFinishTime);
        }
    }
}