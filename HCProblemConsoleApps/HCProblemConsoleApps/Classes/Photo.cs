using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCProblemConsoleApps.Classes
{
    class Photo
    {
        private bool type; //horizontal - 0; vertical - 1
        private int numberOfTags;
        private string[] tags;

        public bool Type
        {
            set
            {
                type = value;
            }
            get
            {
                return type;
            }
        }

        public int NumberOfTags
        {
            set
            {
                numberOfTags = value;
            }
            get
            {
                return numberOfTags;
            }
        }


    }
}
