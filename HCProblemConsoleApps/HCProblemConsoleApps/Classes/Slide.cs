using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCProblemConsoleApps.Classes
{
    class Slide 
    {
        protected Photo leftPhoto;
        protected Photo rihtPhoto;

        Slide() { }

        Slide(Photo horizontal)
        {
            leftPhoto = horizontal;
        }

        Slide(Photo vertical1, Photo vertical2)
        {
            leftPhoto = vertical1;
            rihtPhoto = vertical2;
        }
    }
}
