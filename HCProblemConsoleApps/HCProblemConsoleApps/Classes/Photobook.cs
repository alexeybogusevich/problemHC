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

        public Slideshow DoJob()
        {
            var res = new Slideshow();

            Photo temp = null;

            foreach (var photo in _photos)
            {
                Slide slide;

                if (!photo.IsHorizontal)
                {
                    if (temp == null)
                    {
                        temp = photo;
                        continue;
                    }
                    else
                    {
                        slide = new Slide(temp, photo);
                        temp = null;
                    }
                }
                else
                {
                    slide = new Slide(photo);
                }

                res.AddSlide(slide);
            }

            return res;
        }

        public Slideshow DoJob2()
        {
            var res = new Slideshow();

            Photo temp = null;

            _photos.Shuffle();

            foreach (var photo in _photos)
            {
                Slide slide;

                if (!photo.IsHorizontal)
                {
                    if (temp == null)
                    {
                        temp = photo;
                        continue;
                    }
                    else
                    {
                        slide = new Slide(temp, photo);
                        temp = null;
                    }
                }
                else
                {
                    slide = new Slide(photo);
                }

                res.AddSlide(slide);
            }

            return res;
        }

        public Slideshow DoJob3()
        {
            var res = new Slideshow();

            Photo temp = null;

            _photos.Shuffle();

            Dictionary<string, List<Photo>> dict = new Dictionary<string, List<Photo>>();

            foreach (var photo in _photos)
            {
                var tag = string.Join(" ", photo.Tags.Take(photo.Tags.Count / 2).Select(x => x.ToString()));

                if (!dict.ContainsKey(tag))
                {
                    dict[tag] = new List<Photo>();
                }

                dict[tag].Add(photo);
            }

            foreach (var p in dict)
            {
                foreach (var photo in p.Value)
                {
                    Slide slide;

                    if (!photo.IsHorizontal)
                    {
                        if (temp == null)
                        {
                            temp = photo;
                        }
                        else
                        {
                            slide = new Slide(temp, photo);
                            res.AddSlide(slide);
                            temp = null;
                        }
                    }
                    else
                    {
                        slide = new Slide(photo);
                        res.AddSlide(slide);
                    }

                    
                }

                return res;
            }

            return res;
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
