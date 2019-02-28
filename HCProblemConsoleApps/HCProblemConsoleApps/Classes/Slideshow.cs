﻿using System;
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

        //LEXUS//
        public int sum()
        {
            double maxElemInMatrix = matrix[0, 1];
            int indx0 = 0;

            int indx1 = 1;
            List<int> resInxs = new List<int>();
            for (int i = 0; i < matrix.ColumnCount; ++i)
            {
                for (int j = i + 1; j < matrix.ColumnCount; ++j)
                {
                    if (matrix[i, j] > maxElemInMatrix)
                    {
                        maxElemInMatrix = matrix[i, j];
                        indx0 = i;
                        indx1 = j;
                    }
                }
            }
            int counter = 1;
            resInxs.Add(Math.Min(indx0, indx1));
            resInxs.Add(Math.Max(indx0, indx1));
            while (resInxs.Count() < matrix.ColumnCount - 1)
            {
                double maxOnIteration = 0;
                int nextIndex = -1;
                for (int i = 0; i < resInxs[counter]; ++i)
                {
                    if (resInxs.Contains(i)) continue;
                    if (matrix[i, resInxs[counter]] > maxOnIteration)
                    {
                        maxOnIteration = matrix[i, resInxs[counter]];
                        nextIndex = i;
                    }
                }
                for (int j = matrix[i, resInxs[counter]] + 1; j < matrix.ColumnCount; ++j)
                {
                    if (resInxs.Contains(j)) continue;
                    if (matrix[resInxs[counter], j] > maxOnIteration)
                    {
                        maxOnIteration = matrix[resInxs[counter], j];
                        nextIndex = j;
                    }
                }
                resInxs.Add(nextIndex);
                ++counter;
            }
            return resInxs.Sum();
        }
        //LEXUS//
    }
}
