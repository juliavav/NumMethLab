using System;
using System.Collections.Generic;
using System.Linq;
using NumMethLab1.Solutions;
using NumMethLab1.Vector;

namespace NumMethLab4.Solutions
{
    class BoundaryProblem
    {
        private readonly Func<double, double, double, double> func;
        private readonly double y0;
        private readonly double y1;
        private readonly double alpha;
        private readonly double beta;
        private readonly double delta;
        private readonly double gamma;
        private readonly double a;
        private readonly double b;
        private readonly double h;
        private readonly Func<double, double> accurateSolution;
        private readonly Func<double, double> p;
        private readonly Func<double, double> q;
        private readonly Func<double, double> f;
        private readonly int n;
        private List<double> x;

        public BoundaryProblem(Func<double, double, double, double> func, double y0, double y1, double alpha, double beta, double delta, double gamma, double a, double b, double h, Func<double, double> accurateSolution, Func<double,double> p, Func<double,double> q, Func<double, double> f)
        {
            this.func = func;
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
            this.p = p;
            this.q = q;
            this.f = f;
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
            var eta1 = 10.0;
            var eta2 = -1000000.0;
            var yEta1 = Fi(eta1,h,func,out y);
            var yEta2 = Fi(eta2, h, func,out y);
            var num = 0;
            while (Math.Abs(eta1-eta2)>0.00001)
            {
                num++;
                var etaI = eta2 - yEta2 * (eta2 - eta1) / (yEta2 - yEta1);
                yEta1 = yEta2;
                yEta2 = Fi(etaI, h, func,out y);
                eta1 = eta2;
                eta2 = etaI;
            }
            //Console.WriteLine(num);
            return y;
        }

        private double Fi(double eta, double h, Func<double, double, double, double> func, out List<double> y)
        {
            var y0 = eta;
            var z0 = (y0 - alpha * eta) / beta;

            var cauchy = new CauchyProblem(func, y0, z0, a, b, h, x=>x+1);
            var rk = cauchy.RungeKutta(h);
            //cauchy.RungeRomberg();

            y = rk[0];

            return delta * rk[0][n - 1] + gamma * rk[1][n - 1] - y1;
        }

        public List<double> FiniteDifference(double h)
        {
            var A = new List<double>{0};
            for (int i = 1; i < n-1; i++)
            {
                A.Add(1-p(x[i])*h/2);
            }
            A.Add(-gamma);

            var B = new List<double>{alpha*h - beta};
            for (int i = 1; i < n-1; i++)
            {
                B.Add(q(x[i]) * h*h -2);
            }
            B.Add(delta*h +gamma);

            var C = new List<double> { beta };
            for (int i = 1; i < n-1; i++)
            {
                C.Add(1 + p(x[i]) * h / 2);
            }
            C.Add(0);

            var D = new List<double> { y0*h };
            for (int i = 1; i < n-1; i++)
            {
                D.Add(f(x[i]) * h * h);
            }
            D.Add(y1*h);

            var tridiagonal = new TridiagonalSolution(A, B, C, D);
            var answer = tridiagonal.GetAnswer();
            return tridiagonal.GetAnswer();
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
            Console.WriteLine("Shooting:");
            var shootingY1 = Shooting(h);
            shootingY1.Print();
            var shootingY2 = Shooting(h2);
            var diff = shootingY1.Difference(shootingY2);
            var rrShooting = diff.Select(i => i / (k - 1)).Select(Math.Abs).ToList();
            Console.WriteLine("Shooting RR Error:");
            rrShooting.Print();

            Console.WriteLine("FiniteDifference:");
            var fY1 = FiniteDifference(h);
            fY1.Print();
            var fY2 = FiniteDifference(h2);
            diff = fY1.Difference(fY2);
            var rrFiniteDifference = diff.Select(i => i / (Math.Pow(k, 4) - 1)).Select(Math.Abs).ToList();
            Console.WriteLine("FiniteDifference RR Error:");
            rrFiniteDifference.Print();
        }
    }
}
