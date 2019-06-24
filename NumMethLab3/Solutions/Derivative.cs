namespace NumMethLab3.Solutions
{
    class Derivative
    {
        private readonly double[] fi;
        private readonly double[] xi;
        public Derivative(double[] fi, double[] xi)
        {
            this.fi = fi;
            this.xi = xi;
        }

        private int FindI(double X)
        {
            int i;
            for (i = 0; i < xi.Length; i++)
            {
                if (X <= xi[i + 1] && X >= xi[i])
                {
                    break;
                }
            }

            return i;
        }

        public double Second(double X)
        {
            var i = FindI(X);
            var diff1 = (fi[i + 2] - fi[i + 1]) / (xi[i + 2] - xi[i + 1]);
            var diff2 = (fi[i + 1] - fi[i]) / (xi[i + 1] - xi[i]);
            return 2 * (diff1 -diff2) / (xi[i + 2] - xi[i]);
        }
        public double First(double X)
        {
            var i = FindI(X);
            return (fi[i + 1] - fi[i]) / (xi[i + 1] - xi[i]) + Second(X) * (X - xi[i] / 2 - xi[i + 1] / 2);
        }
    }
}
