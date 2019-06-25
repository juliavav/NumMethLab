using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethLab4
{
    class Functions
    {
        public static double f1(double x, double y, double yD) => 1 + 2 * Math.Pow(Math.Tan(x), 2) * y;
        public static double solution1(double x) => 1 / Math.Cos(x) + Math.Sin(x) + x / Math.Cos(x);
        public const double y01 = 1;
        public const double yD01 = 2;
        public const int a1 = 0;
        public const int b1 = 1;
        public const double h1 = 0.1;
    }
}
