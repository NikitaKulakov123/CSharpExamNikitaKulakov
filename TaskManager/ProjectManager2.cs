using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class ProjectManager2
    {
        public Project2[] projects = new Project2[0];

        public void AddProject(string projectName, string projectDescription)
        {
            Console.WriteLine();

            Array.Resize(ref projects, projects.Length + 1);
            projects[projects.Length - 1] = new Project2(projectName, projectDescription);
        }

        public bool NameExistCheck(int index, string name)
        {
            int j = 0;

            for (int i = 0; i < projects.Length; i++)
            {
                if(!projects[i].name.Equals(name))
                {
                    j++;
                }
            }

            if(j == projects.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void PlanFinishTime(int projectIndex, int taskIndex, string day, string month, int year)
        {
            projects[projectIndex].tasks[taskIndex].plannedFinishTime = $"{day}.{month}.{year}";

            Console.WriteLine(projects[projectIndex].tasks[taskIndex].plannedFinishTime);
        }

        public void RemoveProject(int indexOfComponent)
        {
            int indexOfPlace = projects.Length - 1;

            Project2[] tempComponents = new Project2[projects.Length];
            Project2[] tempComponents2 = new Project2[projects.Length];

            for (int i = 0; i < indexOfComponent; i++)
                tempComponents[i] = projects[i];
            for (int i = indexOfComponent + 1; i < projects.Length; i++)
                tempComponents[i - 1] = projects[i];

            Array.Copy(tempComponents, tempComponents2, projects.Length);

            for (int i = indexOfPlace + 1; i < projects.Length; i++)
                tempComponents[i] = tempComponents2[i - 1];

            tempComponents[indexOfPlace] = projects[indexOfComponent];

            projects = tempComponents;

            Array.Resize(ref projects, projects.Length - 1);
        }
    }
}
