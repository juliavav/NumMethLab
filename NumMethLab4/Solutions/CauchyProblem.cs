using System;
using System.Collections.Generic;
using System.Linq;
using NumMethLab1.Vector;

namespace NumMethLab4.Solutions
{
    class CauchyProblem
    {
        private readonly Func<double, double, double, double> cauchyFunc;
        private readonly double y0;
        private readonly double yD0;
        private readonly int a;
        private readonly int b;
        private readonly double h;
        private readonly Func<double, double> accurateSolution;
        private readonly double n;
        private List<double> x;

        public CauchyProblem(Func<double, double, double, double> cauchyFunc, double y0, double yD0, int a, int b, double h, Func<double, double> accurateSolution)
        {
            this.cauchyFunc = cauchyFunc;
            this.y0 = y0;
            this.yD0 = yD0;
            this.a = a;
            this.b = b;
            this.h = h;
            this.accurateSolution = accurateSolution;
            n = (int)((b - a) / h);
            x = new List<double>(); //разбиение
            for (double i = a; i < b; i += h)
            {
                x.Add(i);
            }

        }

        private double G(double x, double y, double z) => z;

        public List<double> Euler(double h)
        {
            var y = new List<double> { y0 };
            var z = yD0;

            for (int i = 0; i < n; i++)
            {
                z += h * cauchyFunc(x[i], y[i], z);
                y.Add(y[i] + h * G(x[i], y[i], z));
            }

            return y;
        }

        public List<List<double>> RungeKutta(double h)
        {
            var y = new List<double> { y0 };
            var z = new List<double> { yD0 };

            for (int i = 0; i < n; i++)
            {
                var k1 = h * G(x[i], y[i], z[i]);
                var q1 = h * cauchyFunc(x[i], y[i], z[i]);
                var k2 = h * G(x[i] + 0.5 * h, y[i] + 0.5 * k1, z[i] + 0.5 * q1);
                var q2 = h * cauchyFunc(x[i] + 0.5 * h, y[i] + 0.5 * k1, z[i] + 0.5 * q1);
                var k3 = h * G(x[i] + 0.5 * h, y[i] + 0.5 * k2, z[i] + 0.5 * q2);
                var q3 = h * cauchyFunc(x[i] + 0.5 * h, y[i] + 0.5 * k2, z[i] + 0.5 * q2);
                var k4 = h * G(x[i] + h, y[i] + k3, z[i] + q3);
                var q4 = h * cauchyFunc(x[i] + h, y[i] + k3, z[i] + q3);
                y.Add(y[i] + (k1 + 2 * k2 + 2 * k3 + k4) / 6);
                z.Add(z[i] + (q1 + 2 * q2 + 2 * q3 + q4) / 6);
            }
            var result = new List<List<double>> { y, z };
            return result;
        }

        public List<double> Adams(double h)
        {
            var x = this.x.Take(4).ToList();
            var yz = RungeKutta(h);
            var y = yz[0].Take(4).ToList();
            var z = yz[1].Take(4).ToList();
            for (int i = 3; i < n - 1; i++)
            {
                z.Add(z[i] + h / 24 * (55 * cauchyFunc(x[i], y[i], z[i]) -
                               59 * cauchyFunc(x[i - 1], y[i - 1], z[i - 1]) +
                               37 * cauchyFunc(x[i - 2], y[i - 2], z[i - 2]) -
                               9 * cauchyFunc(x[i - 3], y[i - 3], z[i - 3])));
                y.Add(y[i] + h / 24 * (55 * G(x[i], y[i], z[i]) -
                                  59 * G(x[i - 1], y[i - 1], z[i - 1]) +
                                  37 * G(x[i - 2], y[i - 2], z[i - 2]) -
                                  9 * G(x[i - 3], y[i - 3], z[i - 3])));
                x.Add(x[i]+h);

            }

            return y;
        }

        public void RungeRomberg()
        {
            var h2 = h / 2;
            var k = h / h2;
            Console.WriteLine("X");
            x.Print();
            Console.WriteLine("Y");
            var y = x.Select(accurateSolution).ToList();
            y.Print();
            Console.WriteLine("Euler:");
            var eulerY1 = Euler(h);
            eulerY1.Print();
            var eulerY2 = Euler(h2);
            var diff = eulerY1.Difference(eulerY2);
            var rrEuler = diff.Select(i => i /( k - 1)).Select(Math.Abs).ToList();
            Console.WriteLine("Euler RR Error:");
            rrEuler.Print();

            Console.WriteLine("RungeKutta:");
            var rY1 = RungeKutta(h)[0];
            rY1.Print();
            var rY2 = RungeKutta(h2)[0];
            diff = rY1.Difference(rY2);
            var rrRungeKutta = diff.Select(i => i / (Math.Pow(k,4)-1)).Select(Math.Abs).ToList();
            Console.WriteLine("RungeKutta RR Error:");
            rrRungeKutta.Print();

            Console.WriteLine("Adams:");
            var aY1 = Adams(h);
            aY1.Print();
            var aY2 = Adams(h2);
            diff = aY1.Difference(aY2);
            var rrAdams = diff.Select(i => i / (Math.Pow(k, 4) - 1)).Select(Math.Abs).ToList();
            Console.WriteLine("Adams RR Error:");
            rrAdams.Print();
        }
    }
}
