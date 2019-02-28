using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCProblemConsoleApps.Classes
{
    class Photobook
    {
        private List<Photo> _photos;

        public Photobook()
        {
            _photos = new List<Photo>();
        }

        public Photobook(List<Photo> photos)
        {
            _photos = photos;
        }

        public static Photobook FromFile(string filename)
        {
            Photobook result;

            using (var reader = File.OpenText(filename))
            {
                var collectionSize = int.Parse(reader.ReadLine());

                var photoList = new List<Photo>();

                string temp;

                while ((temp = reader.ReadLine()) != null)
                {

                }

                result = new Photobook(photoList);

            }

            return result;
        }
    }
}
