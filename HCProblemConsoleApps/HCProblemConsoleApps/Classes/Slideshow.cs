using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace HCProblemConsoleApps.Classes {
    class Slideshow {
        protected List<Slide> slides;
        protected List<Slide> slidesSorted;

        private Matrix<Double> matrix;

        private static int ComparisonByTagsNum(Slide s1, Slide s2) {
            if (s1.Tags.Count > s2.Tags.Count)
            {
                return 1;
            }
            else if (s1.Tags.Count < s2.Tags.Count)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public void MatrixOut() {

        }

        public Slideshow() {
            slides = new List<Slide>();
            slidesSorted = new List<Slide>();
            matrix = Matrix<Double>.Build.Dense(0, 0);
        }

        public Slideshow(List<Slide> slide) {
            slides = slide;
            slidesSorted = slides;
            slidesSorted.Sort(ComparisonByTagsNum);
            matrix = Matrix<Double>.Build.Dense(slidesSorted.Count(), slidesSorted.Count(), (i, j) => slidesSorted[i].CompareTo(slidesSorted[j]));
        }

        public string SlideshowOUT() {
            StringBuilder sb = new StringBuilder();
            //количество слайдов
            sb.AppendLine(slides.Count.ToString());
            foreach (Slide slide in slides)
            {
                //для каждого слайда ID фоток(фотки)
                sb.AppendLine(slide.GetPhotos());
            }

            string res = sb.ToString();

            return res;
        }

        public void AddSlide(Slide slide) {
            slides.Add(slide);
        }
    }
}
