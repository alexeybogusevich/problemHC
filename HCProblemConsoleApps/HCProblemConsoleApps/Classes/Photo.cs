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

        public Photo(int id, bool isHorizontal, HashSet<string> tags = null)
        {
            if (tags == null)
            {
                Tags = new HashSet<string>();
            }
            else
            {
                Tags = tags;
            }

            Id = id;
            IsHorizontal = isHorizontal;
        }

        public void AddTags(string tag)
        {
            Tags.Add(tag);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(IsHorizontal ? "H " : "V ");
            sb.Append(Tags.Count);
            
            foreach (var tag in Tags)
            {
                sb.Append($" {tag}");
            }

            return sb.ToString();
        }

    }
}
