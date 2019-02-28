using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCProblemConsoleApps.Classes
{
    class Slide 
    {
        public Photo leftPhoto { get; set; }
        public Photo rightPhoto { get; set; }

        Slide() { }

        Slide(Photo horizontal)
        {
            leftPhoto = horizontal;
        }

        Slide(Photo vertical1, Photo vertical2)
        {
            leftPhoto = vertical1;
            rightPhoto = vertical2;
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
    }
}
