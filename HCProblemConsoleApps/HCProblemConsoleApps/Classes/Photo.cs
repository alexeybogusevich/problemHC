using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCProblemConsoleApps.Classes
{
    class Photo
    {
        public bool IsHorizontal { get; private set; }

        public int ID { get; private set; }

        public HashSet<string> Tags { get; private set; }

        public Photo(int ID, bool IsHorizontal, HashSet<string> tags = null)
        {
            if (tags == null)
                tags = new HashSet<string>();
        }

        public void addTag(string tag)
        {
            Tags.Add(tag);
        }
    }
}
