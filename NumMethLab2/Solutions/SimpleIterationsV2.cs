namespace NumMethLab2.Solutions
{
    using System;
    using static System.Math;

    class SimpleIterationsV2
    {

        private readonly double a;
        private readonly double b;
        private readonly Func<double, double> dphi;
        private readonly Func<double, double> f;
        private readonly Func<double, double> phi;

        public SimpleIterationsV2(Func<double, double> f, Func<double, double> phi, Func<double, double> dphi, double a, double b)
        {
            this.f = f;
            this.phi = phi;
            this.dphi = dphi;
            this.a = a;
            this.b = b;
        }

        public double GetAnswer()
        {
            var xPrevious = a;
            var xCurrent = (b - a) / 2; ;

            var numberOfIterations = 0;

            var m = Max(Abs(dphi(a)), Abs(dphi(b)));

            while (Abs(f(xCurrent) - f(xPrevious)) * (m / (1 - m)) > Constants.Eps)
            {
                numberOfIterations++;

                xPrevious = xCurrent;
                xCurrent = phi(xPrevious);
            }

            Console.WriteLine("Number of Iterations Simple V2:{0}", numberOfIterations);
            return xCurrent;
        }
    }
}
