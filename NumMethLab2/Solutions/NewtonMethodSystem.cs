namespace NumMethLab2.Solutions
{
    using NumMethLab1.Matrix;
    using NumMethLab1.Solutions;
    using System;
    using System.Linq;
    using static System.Math;
    internal class NewtonMethodSystem
    {
        private readonly double[] a;
        private readonly double[] b;
        private readonly Func<double, double, double>[] f;
        private readonly Func<double, double, double>[,] J;

        public NewtonMethodSystem(Func<double, double, double>[] f, Func<double, double, double>[,] J, double[] a,
            double[] b)
        {
            this.f = f;
            this.J = J;
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

            while (Max(Abs(xCurrent[0] - xPrevious[0]), Abs(xCurrent[1] - xPrevious[1])) > Constants.Eps)
            {
                numberOfIterations++;

                var delta = CountDelta(xCurrent);

                xPrevious = xCurrent;
                xCurrent = new[] { xPrevious[0] + delta[0], xPrevious[1] + delta[1] };
            }

            Console.WriteLine("Number of Iterations Newton:{0}", numberOfIterations);
            return xCurrent;
        }

        private double[] CountDelta(double[] x)
        {
            var coefficients = new double[x.Length, x.Length];
            for (var i = 0; i < x.Length; i++)
                for (var j = 0; j < x.Length; j++)
                    coefficients[i, j] = J[i, j](x[0], x[1]);

            var fx = new double[x.Length];
            for (var i = 0; i < x.Length; i++) fx[i] = -f[i](x[0], x[1]);

            var Jx = new Matrix(coefficients);

            var lu = new LuSolution(Jx, fx.ToList());

            return lu.GetAnswer().ToArray();
        }
    }
}