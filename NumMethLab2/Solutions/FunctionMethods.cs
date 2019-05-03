using System;
using static System.Math;

namespace NumMethLab2.Solutions
{
    public static class FunctionMethods
    {
        public static double F(double x) => Cos(x) + 0.25 * x - 0.5;

        public static double Df(double x) => -Sin(x) + 0.25;

        public static double Phi(double x) => x - Sign(Df(x)) / Max(Abs(Constants.A), Abs(Constants.B)) * F(x);

        public static double Dphi(double x) => 1 - Df(x) * Sign(Df(x)) / Max(Abs(Constants.A), Abs(Constants.B));

        public static double F1(double x1, double x2) => x1 - Cos(x2) - 1;

        public static double F2(double x1, double x2) => x2 - Log(x1 + 1) - 2;

        private static double J00(double x1, double x2) => 1;
        private static double J01(double x1, double x2) => Sin(x2);
        private static double J10(double x1, double x2) => -1 / (x1 + 1);
        private static double J11(double x1, double x2) => 1;

        public static Func<double, double, double>[] Fi = { F1, F2 };
        public static Func<double, double, double>[,] J = { { J00, J01 }, { J10, J11 } };

        public static double Phi1(double x1, double x2) => Cos(x2) + 1;

        public static double Phi2(double x1, double x2) => Log(x1 + 1) + 2;

        private static double Dphi01(double x1, double x2) => -Sin(x2);
        private static double Dphi10(double x1, double x2) => 1 / (x1 + 1);



        public static Func<double, double, double>[] PhiX = { Phi1, Phi2 };
        public static Func<double, double, double>[] DphiX = { Dphi01, Dphi10 };



        public static double Fv2(double x) => Cos(x) + 0.25 * x - 0.5;

        public static double Dfv2(double x) => -Sin(x) + 0.25;

        public static double Phiv2(double x) => -4 * Cos(x) + 2;

        public static double Dphiv2(double x) => 4 * Sin(x);


        //public static double Dphi(double x) => 4 * Sin(x);
        //public static double Phi(double x) => -4 * Cos(x) + 1;
    }
}
