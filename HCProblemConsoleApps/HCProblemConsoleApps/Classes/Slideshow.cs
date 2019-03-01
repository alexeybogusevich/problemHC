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
        protected List<Slide> slidesFinal;
        private int N;
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
            matrix.ToMatrixString();
        }

        public Slideshow() {
            slides = new List<Slide>();
            slidesSorted = new List<Slide>();
            slidesFinal = new List<Slide>();
            matrix = Matrix<Double>.Build.Dense(1, 1);
            N = 0;
        }

        public Slideshow(List<Slide> slide) {
            slides = slide;
            slidesSorted = slides;
            slidesSorted.Sort(ComparisonByTagsNum);
            slidesFinal = new List<Slide>();
            matrix = Matrix<Double>.Build.Dense(slidesSorted.Count(), slidesSorted.Count(), (i, j) => slidesSorted[i].CompareTo(slidesSorted[j]));
            N = matrix.ColumnCount;
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

        //LEXUS//
        public void LexusSolve()
        {
            double maxElemInMatrix = matrix[0, 1];
            int firstSlideIndex = 0;
            int secondSlideIndex = 1;
            List<int> resultSlidesIndexes = new List<int>();
            for (int i = 0; i < N; ++i)
            {
                for (int j = i + 1; j < N; ++j)
                {
                    if (matrix[i, j] > maxElemInMatrix)
                    {
                        maxElemInMatrix = matrix[i, j];
                        firstSlideIndex = i;
                        secondSlideIndex = j;
                    }
                }
            }
            int counter = 1;
            resultSlidesIndexes.Add(Math.Min(firstSlideIndex, secondSlideIndex));
            slidesFinal.Add(slidesSorted[firstSlideIndex]);
            resultSlidesIndexes.Add(Math.Max(firstSlideIndex, secondSlideIndex));
            slidesFinal.Add(slidesSorted[secondSlideIndex]);
            while (resultSlidesIndexes.Count() < N - 1)
            {
                double maxOnIteration = 0;
                int nextIndex = -1;
                for (int i = 0; i < resultSlidesIndexes[counter]; ++i)
                {
                    if (resultSlidesIndexes.Contains(i)) continue;
                    if (matrix[i, resultSlidesIndexes[counter]] > maxOnIteration)
                    {
                        maxOnIteration = matrix[i, resultSlidesIndexes[counter]];
                        nextIndex = i;
                    }
                }
                for (int j = resultSlidesIndexes[counter] + 1; j < N; ++j)
                {
                    if (resultSlidesIndexes.Contains(j)) continue;
                    if (matrix[resultSlidesIndexes[counter], j] > maxOnIteration)
                    {
                        maxOnIteration = matrix[resultSlidesIndexes[counter], j];
                        nextIndex = j;
                    }
                }
                resultSlidesIndexes.Add(nextIndex);
                slidesFinal.Add(slidesSorted[nextIndex]);
                ++counter;
            }
            slides = slidesFinal;
        }
    }
}
