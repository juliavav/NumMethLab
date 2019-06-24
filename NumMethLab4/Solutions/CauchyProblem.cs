using System;

namespace NumMethLab4.Solutions
{
    class CauchyProblem
    {
        private readonly Func<double, Func<double, double>, double> cauchyFunc;
        private readonly double y0;
        private readonly double yD0;
        private readonly double a;
        private readonly double b;
        private readonly double h;
        private readonly Func<double, double> accurateSolution;

        public CauchyProblem(Func<double, Func<double, double>, double> cauchyFunc, double y0, double yD0, double a, double b, double h, Func<double, double> accurateSolution)
        {
            this.cauchyFunc = cauchyFunc;
            this.y0 = y0;
            this.yD0 = yD0;
            this.a = a;
            this.b = b;
            this.h = h;
            this.accurateSolution = accurateSolution;
        }

        public double Euler()
        {

        }
    }
}
