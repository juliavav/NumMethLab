using System;
using System.Collections.Generic;
using System.Linq;
using NumMethLab1.Vector;

namespace NumMethLab4.Solutions
{
    class BoundaryProblem
    {
        private readonly Func<double, double, double, double> f;
        private readonly double y0;
        private readonly double y1;
        private readonly double alpha;
        private readonly double beta;
        private readonly double delta;
        private readonly double gamma;
        private readonly int a;
        private readonly int b;
        private readonly double h;
        private readonly Func<double, double> accurateSolution;
        private readonly int n;
        private List<double> x;

        public BoundaryProblem(Func<double, double, double, double> f, double y0, double y1, double alpha, double beta, double delta, double gamma, int a, int b, double h, Func<double, double> accurateSolution)
        {
            this.f = f;
            this.y0 = y0;
            this.y1 = y1;
            this.alpha = alpha;
            this.beta = beta;
            this.delta = delta;
            this.gamma = gamma;
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

        public List<double> Shooting(double h)
        {
            var y = new List<double>();
            var eta1 = 1000000.0;
            var eta2 = -1000000.0;
            var yEta1 = Fi(eta1,h,f,out y);
            var yEta2 = Fi(eta2, h, f,out y);

            while (Math.Abs(eta1-eta2)>0.0000001)
            {
                var etaI = eta2 - yEta2 * (eta2 - eta1) / (yEta2 - yEta1);
                yEta1 = yEta2;
                yEta2 = Fi(etaI, h, f,out y);
            }

            return y;
        }

        private double Fi(double eta, double h, Func<double, double, double, double> func, out List<double> y)
        {
            var y0 = eta;
            var z0 = (y0 - alpha * eta) / beta;

            var cauchy = new CauchyProblem(func, y0, z0, a, b, h, null);
            var rk = cauchy.RungeKutta(h);

            y = rk[0];

            return delta * rk[0][n - 1] + gamma * rk[1][n - 1] - y1;
        }

        public List<List<double>> FiniteDifference(double h)
        {
            //var y = new List<double> { y0 };
            //var z = new List<double> { yD0 };

            //for (int i = 0; i < n; i++)
            //{
            //    var k1 = h * G(x[i], y[i], z[i]);
            //    var q1 = h * cauchyFunc(x[i], y[i], z[i]);
            //    var k2 = h * G(x[i] + 0.5 * h, y[i] + 0.5 * k1, z[i] + 0.5 * q1);
            //    var q2 = h * cauchyFunc(x[i] + 0.5 * h, y[i] + 0.5 * k1, z[i] + 0.5 * q1);
            //    var k3 = h * G(x[i] + 0.5 * h, y[i] + 0.5 * k2, z[i] + 0.5 * q2);
            //    var q3 = h * cauchyFunc(x[i] + 0.5 * h, y[i] + 0.5 * k2, z[i] + 0.5 * q2);
            //    var k4 = h * G(x[i] + h, y[i] + k3, z[i] + q3);
            //    var q4 = h * cauchyFunc(x[i] + h, y[i] + k3, z[i] + q3);
            //    y.Add(y[i] + (k1 + 2 * k2 + 2 * k3 + k4) / 6);
            //    z.Add(z[i] + (q1 + 2 * q2 + 2 * q3 + q4) / 6);
            //}
            //var result = new List<List<double>> { y, z };
            //return result;
        }


        public void RungeRomberg()
        {
            //var h2 = h / 2;
            //var k = h / h2;
            //Console.WriteLine("X");
            //x.Print();
            //Console.WriteLine("Y");
            //var y = x.Select(accurateSolution).ToList();
            //y.Print();
            //Console.WriteLine("Euler:");
            //var eulerY1 = Euler(h);
            //eulerY1.Print();
            //var eulerY2 = Euler(h2);
            //var diff = eulerY1.Difference(eulerY2);
            //var rrEuler = diff.Select(i => i / (k - 1)).Select(Math.Abs).ToList();
            //Console.WriteLine("Euler RR Error:");
            //rrEuler.Print();

            //Console.WriteLine("RungeKutta:");
            //var rY1 = RungeKutta(h)[0];
            //rY1.Print();
            //var rY2 = RungeKutta(h2)[0];
            //diff = rY1.Difference(rY2);
            //var rrRungeKutta = diff.Select(i => i / (Math.Pow(k, 4) - 1)).Select(Math.Abs).ToList();
            //Console.WriteLine("RungeKutta RR Error:");
            //rrRungeKutta.Print();

            //Console.WriteLine("Adams:");
            //var aY1 = Adams(h);
            //aY1.Print();
            //var aY2 = Adams(h2);
            //diff = aY1.Difference(aY2);
            //var rrAdams = diff.Select(i => i / (Math.Pow(k, 4) - 1)).Select(Math.Abs).ToList();
            //Console.WriteLine("Adams RR Error:");
            //rrAdams.Print();
        }
    }
}
