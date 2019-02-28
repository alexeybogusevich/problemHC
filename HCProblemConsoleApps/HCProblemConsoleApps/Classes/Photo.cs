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

        public int Id { get; private set; }

        public HashSet<string> Tags { get; private set; }

        public Photo(int Id, bool IsHorizontal, HashSet<string> tags = null)
        {
            if (tags == null)
                tags = new HashSet<string>();
            this.Id = Id;
            if (IsHorizontal)
                this.IsHorizontal = true;
            else
                this.IsHorizontal = false;
        }

        public void addTags(string tag)
        {
            Tags.Add(tag);
        }
    }
}
