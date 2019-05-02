using System;
using static System.Math;

namespace NumMethLab2.Solutions
{
    public class SimpleIterations
    {
        private readonly double a;
        private readonly double b;
        private readonly Func<double, double> df;
        private readonly Func<double, double> dphi;
        private readonly Func<double, double> f;
        private readonly Func<double, double> phi;

        public SimpleIterations(Func<double, double> f, Func<double, double> df, Func<double, double> phi,
            Func<double, double> dphi, double a, double b)
        {
            this.f = f;
            this.df = df;
            this.phi = phi;
            this.dphi = dphi;
            this.a = a;
            this.b = b;
        }

        public double GetAnswer()
        {
            var xPrevious = (b - a) / 2;
            var xCurrent = a;

            var numberOfIterations = 0;

            var m = Max(Abs(dphi(a)), Abs(dphi(b)));

            while (Abs(f(xCurrent) - f(xPrevious)) * (m / (1 - m)) > Constants.Eps)
            {
                numberOfIterations++;

                var xTemp = xCurrent;
                xCurrent = phi(xPrevious);
                xPrevious = xTemp;
            }

            Console.WriteLine("Number of Iterations Simple:{0}", numberOfIterations);
            return xCurrent;
        }
    }
}