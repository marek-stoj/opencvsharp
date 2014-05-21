﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Blob;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.Extensions;

namespace OpenCvSharp.Sandbox
{
    /// <summary>
    /// 書き捨てのコード。
    /// うまくいったらSampleに移管
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Bar();
            //Foo();
            //Run();
        }

        private static void Bar()
        {
            var bowkMeansTrainer =
                new BOWKMeansTrainer(5, new TermCriteria(), attempts: 5, flags: KMeansFlag.PpCenters);
        }

        private static void Foo()
        {
            while (true)
            {
                IplImage img = new IplImage("img/lenna.png");
                Cv.ReleaseImage(img);
                Console.WriteLine("{0:F2}MB", MyProcess.WorkingSet64 / 1024.0 / 1024.0);
                //img.Dispose(); does not work either.
            }
        }

        private static void Run()
        {
            string[] algoNames = Algorithm.GetList();
            algoNames.ToString();

            SIFT al1 = Algorithm.Create<SIFT>("Feature2D.SIFT");
            string[] ppp = al1.GetParams();
            Console.WriteLine(ppp);
            var t = al1.ParamType("contrastThreshold");
            double d = al1.GetDouble("contrastThreshold");
            t.ToString();
            d.ToString();

            var src = new Mat("img/lenna.png");
            var rand = new Random();
            var memory = new List<long>(100);

            var a1 = new Mat(src, Rect.FromLTRB(0, 0, 30, 40));
            var a2 = new Mat(src, Rect.FromLTRB(0, 0, 30, 40));
            var a3 = new Mat(src, Rect.FromLTRB(0, 0, 30, 40));
            a3.ToString();

            for (long i = 0;; i++)
            {
                SIFT a = Algorithm.Create<SIFT>("Feature2D.SIFT");
                a.ToString();

                for (int j = 0; j < 200; j++)
                {
                    int c1 = rand.Next(100, 400);
                    int c2 = rand.Next(100, 400);
                    Mat temp = src.Row[c1];
                    src.Row[c1] = src.Row[c2];
                    src.Row[c2] = temp;
                }

                memory.Add(MyProcess.WorkingSet64);
                if (memory.Count >= 100)
                {
                    double average = memory.Average();
                    Console.WriteLine("{0:F3}MB", average / 1024.0 / 1024.0);
                    memory.Clear();
                    GC.Collect();
                }
            }

        }

    }
}
