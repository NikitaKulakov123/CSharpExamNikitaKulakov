using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class AttachedComponent
    {
        public string filePath = "null";
        public string link = "null";

        public AttachedComponent(string _filePath, string _link)
        {
            filePath = _filePath;
            link = _link;
        }
    }
}
