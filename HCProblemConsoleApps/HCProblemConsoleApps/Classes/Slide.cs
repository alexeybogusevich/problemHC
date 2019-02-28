using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCProblemConsoleApps.Classes {
    class Slide
    {
        public Photo leftPhoto { get; set; }
        public Photo rightPhoto { get; set; }

        public HashSet<string> Tags { get; private set; }

        public Slide()
        {
            Tags = new HashSet<string>();
        }

        public Slide(Photo horizontal)
        {
            leftPhoto = horizontal;
            Tags = horizontal.Tags;
        }

        public Slide(Photo vertical1, Photo vertical2)
        {
            leftPhoto = vertical1;
            rightPhoto = vertical2;
            Tags = vertical1.Tags;
            Tags.UnionWith(vertical2.Tags);
        }

        public string GetPhotos()
        {
            if (rightPhoto == null)
            {
                return leftPhoto.Id.ToString();
            }
            else
            {
                return leftPhoto.Id.ToString() + ' ' + rightPhoto.Id.ToString();
            }
        }

        public int CompareTo(Slide slide2)
        {
            int intersection = this.Tags.Intersect(slide2.Tags).Count();

            int AwoB = this.Tags.Except(slide2.Tags).Count();

            int BwoA = slide2.Tags.Except(this.Tags).Count();

            return Math.Min(intersection, Math.Min(AwoB, BwoA));
        }
    }
}
