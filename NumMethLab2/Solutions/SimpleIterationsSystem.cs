namespace NumMethLab2.Solutions
{
    using NumMethLab1.Matrix;
    using NumMethLab1.Solutions;
    using System;
    using System.Linq;
    using static System.Math;

    class SimpleIterationsSystem
    {
        private readonly double[] a;
        private readonly double[] b;
        private readonly Func<double, double, double>[] phi;
        private readonly Func<double, double, double>[] dphi;

        public SimpleIterationsSystem(Func<double, double, double>[] phi, Func<double, double, double>[] dphi, double[] a,
            double[] b)
        {
            this.phi = phi;
            this.dphi = dphi;
            this.a = a;
            this.b = b;
        }


        public double[] GetAnswer()
        {
            var xPrevious = new[]
            {
                0.0, 0.0
            };
            var xCurrent = new[]
            {
                (b[0] - a[0]) / 2,
                (b[1] - a[1]) / 2
            };

            var numberOfIterations = 0;

            var m = Max(Abs(dphi[0](xCurrent[0], xCurrent[1])), Abs(dphi[1](xCurrent[0], xCurrent[1])));

            while (Max(Abs(xCurrent[0] - xPrevious[0]), Abs(xCurrent[1] - xPrevious[1])) > Constants.Eps)
            {
                numberOfIterations++;
                
                xPrevious = xCurrent;
                xCurrent = new[] { phi[0](xPrevious[0],xPrevious[1]), phi[1](xPrevious[0], xPrevious[1]) };
            }

            Console.WriteLine("Number of Iterations Simple:{0}", numberOfIterations);
            return xCurrent;
        }

    }
}

