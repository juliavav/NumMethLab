using static System.Math;

namespace NumMethLab2.Solutions
{
    public static class FunctionMethods
    {
        public static double F(double x) => Cos(x) + 0.25 * x - 0.5;

        public static double Df(double x) => -Sin(x) + 0.25;

        public static double Phi(double x) => x - Sign(Df(x)) / Max(Abs(Constants.A), Abs(Constants.B))*F(x);

        public static double Dphi(double x) => 1 - Df(x)*Sign(Df(x))/Max(Abs(Constants.A), Abs(Constants.B));
        
        //public static double Dphi(double x) => 4 * Sin(x);
        //public static double Phi(double x) => -4 * Cos(x) + 1;
    }
}
