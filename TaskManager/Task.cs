using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaskManager
{
    internal class Task
    {
        public string name = "null";
        public string description = "null";
        public char importanceLevel = 'A';
        public string startTime = "null";
        public string finishTime = "null";
        public string plannedFinishTime = null;
        public string stage = "Not done";
        public AttachedComponent[] attachedComponents = new AttachedComponent[0];

        public Task(string _name, string _description, char _importanceLevel, string _plannedFinishTime)
        {
            if (String.IsNullOrEmpty(_name))
            {
                name = "New task";
            }
            else
            {
                name = _name;
            }

            description = _description;

            importanceLevel = _importanceLevel;

            if (_plannedFinishTime == null)
            {
                plannedFinishTime = null;
            }
            else
            {
                plannedFinishTime = _plannedFinishTime;
            }
        }

        public void attachComponent(string component, bool isFile)
        {
            Array.Resize(ref attachedComponents, attachedComponents.Length + 1);
            attachedComponents[attachedComponents.Length - 1] = new AttachedComponent("null", "null");

            if (isFile)
            {
                attachedComponents[attachedComponents.Length - 1].filePath = component;
            }
            else
            {
                attachedComponents[attachedComponents.Length - 1].link = component;
            }
        }

        public void removeAttachedComponent(int index)
        {
            AttachedComponent[] tempComponents = new AttachedComponent[attachedComponents.Length - 1];

            for (int i = 0; i < index; i++)
                tempComponents[i] = attachedComponents[i];
            for (int i = index + 1; i < attachedComponents.Length; i++)
                tempComponents[i - 1] = attachedComponents[i];

            attachedComponents = tempComponents;
        }

        public void replaceAttachedComponent(int indexOfComponent, int indexOfPlace)
        {
            AttachedComponent[] tempComponents = new AttachedComponent[attachedComponents.Length];
            AttachedComponent[] tempComponents2 = new AttachedComponent[attachedComponents.Length];

            if (indexOfComponent < indexOfPlace)
            {
                for (int i = 0; i < indexOfComponent; i++)
                    tempComponents[i] = attachedComponents[i];
                for (int i = indexOfComponent + 1; i < attachedComponents.Length; i++)
                    tempComponents[i - 1] = attachedComponents[i];
                for (int i = indexOfPlace + 1; i < attachedComponents.Length; i++)
                    tempComponents[i] = attachedComponents[i];

                tempComponents[indexOfPlace] = attachedComponents[indexOfComponent];
            }
            else
            {
                for (int i = 0; i < indexOfComponent; i++)
                    tempComponents[i] = attachedComponents[i];
                for (int i = indexOfComponent + 1; i < attachedComponents.Length; i++)
                    tempComponents[i - 1] = attachedComponents[i];

                Array.Copy(tempComponents, tempComponents2, attachedComponents.Length);

                for (int i = indexOfPlace + 1; i < attachedComponents.Length; i++)
                    tempComponents[i] = tempComponents2[i - 1];

                tempComponents[indexOfPlace] = attachedComponents[indexOfComponent];

                tempComponents[indexOfPlace] = attachedComponents[indexOfComponent];
            }

            attachedComponents = tempComponents;
        }
    }
}