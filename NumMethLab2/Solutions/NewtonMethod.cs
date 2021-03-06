﻿using System;
using static System.Math;

namespace NumMethLab2.Solutions
{
    public class NewtonMethod
    {
        private readonly double a;
        private readonly double b;
        private readonly Func<double, double> df;
        private readonly Func<double, double> f;

        public NewtonMethod(Func<double, double> f, Func<double, double> df, double a, double b)
        {
            this.f = f;
            this.df = df;
            this.a = a;
            this.b = b;
        }

        public double GetAnswer()
        {
            var xCurrent = b;
            var xPrevious = a;

            var numberOfIterations = 0;

            while (Abs(f(xCurrent) - f(xPrevious)) > Constants.Eps)
            {
                numberOfIterations++;

                xPrevious = xCurrent;
                xCurrent = xPrevious - f(xPrevious) / df(xPrevious);
            }

            Console.WriteLine("Number of Iterations Newton:{0}", numberOfIterations);
            return xCurrent;
        }
    }
}