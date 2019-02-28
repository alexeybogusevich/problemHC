using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCProblemConsoleApps.Classes {
    class Slideshow {
        protected List<Slide> slides;

        Slideshow() {
            slides = new List<Slide>();
        }

        Slideshow(List<Slide> slide) {
            slides = slide;
        }

        public string SlideshowOUT() {
            StringBuilder sb = new StringBuilder();
            //количество слайдов
            sb.AppendLine(slides.Count.ToString());
            foreach (Slide slide in slides) {
                //для каждого слайда ID фоток(фотки)
                sb.AppendLine(slide.GetPhotos());
            }

            string res = sb.ToString();

            return res;
        }
    }
}
