using static System.Math;

namespace NumMethLab4
{
    class Functions
    {
        public static double f1(double x, double y, double yD) => 1 + 2 * Pow(Tan(x), 2) * y;
        public static double solution1(double x) => 1 / Cos(x) + Sin(x) + x / Cos(x);
        public const double y01 = 1;
        public const double yD01 = 2;
        public const int a1 = 0;
        public const int b1 = 1;
        public const double h1 = 0.1;


        //public static double func2(double x, double y, double yD) => 2 * (1 + Pow(Tan(x), 2)) * y;
        //public static double solution2(double x) => 1 + Tan(x*(x+1));
        //public static double f(double x) => 0;
        //public static double p(double x) => 0;
        //public static double q(double x) => 2 * (1 + Pow(Tan(x), 2));
        //public const double a2 = PI/4;
        //public const double b2 = PI/3;
        //public const double h2 = 0.1;
        //public const double alpha = 0;
        //public const double beta = 1;
        //public const double gamma = 1;
        //public const double delta = -1;
        //public const double y02 = 3+PI/2;
        //public static readonly double yD02 = 3+PI*(4-Sqrt(3))/3.0;

        public static double func2(double x, double y, double yD) => (4 * y - 4 * x * yD) / (2 * x + 1);
        public static double solution2(double x) => x + Exp(-2 * x);
        public static double f(double x) => 0;
        public static double p(double x) => 4 * x / (2 * x + 1);
        public static double q(double x) => -4 / (2 * x + 1);
        public const double a2 = 0;
        public const double b2 = 1;
        public const double h2 = 0.1;
        public const double alpha = 0;
        public const double beta = 1;
        public const double gamma = 1;
        public const double delta = 2;
        public const double y02 = -1;
        public static readonly double yD02 = 3;

    }
}
