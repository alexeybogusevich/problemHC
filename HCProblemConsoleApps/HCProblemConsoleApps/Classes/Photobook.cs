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

                int idCounter = 0;

                string temp;

                while ((temp = reader.ReadLine()) != null)
                {
                    var line = temp.Split(' ');

                    bool isHorisontal = line[0] == "H";

                    HashSet<string> tags = new HashSet<string>(line.Skip(2));

                    photoList.Add(new Photo(idCounter, isHorisontal, tags));

                    idCounter++;
                }

                result = new Photobook(photoList);

            }

            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{_photos.Count}");

            _photos.ForEach(photo => sb.AppendLine(photo.ToString()));

            return sb.ToString();
        }
    }
}
