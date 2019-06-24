using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethLab3.Solutions
{
    class Integration
    {
        private readonly Func<double, double> f;
        private readonly int a;
        private readonly int b;
        private readonly double h1;
        private readonly double h2;
        public Integration(Func<double,double> f, int a, int b, double h1, double h2)
        {
            this.a = a;
            this.b = b;
            this.f = f;
            this.h1 = h1;
            this.h2 = h2;
        }

        public double Rectangle(double h)
        {
            var x = Enumerable.Range(0, (int)((b - a) / h)).Select(i => i*h + a).ToList();
            return h * (Enumerable.Range(1, x.Count-1)).Select(i => f((x[i - 1] + x[i]) / 2)).Sum();
        }

        public double Trapeze(double h)
        {
            var x = Enumerable.Range(0, (int)((b - a) / h)).Select(i => i * h + a).ToList();
            var y = x.Select(f).ToList();
            return h * 1/2.0*(Enumerable.Range(1, x.Count-1)).Select(i => y[i]+y[i-1]).Sum();
        }

        public double Simpson(double h)
        {
            var x = Enumerable.Range(0, (int)((b - a) / h)).Select(i => i * h + a).ToList();
            var y = x.Select(f).ToList();
            var sum1 = 0.0;
            var sum2 = 0.0;
            for (int i = 1; i < y.Count-1; i+=2)
            {
                sum1 += y[i];
            }
            for (int i = 2; i < y.Count - 1; i += 2)
            {
                sum2 += y[i];
            }
            return h * 1 / 3.0 * (y[0]+4*sum1 +2*sum2 +y.Last());
        }

        public void RoungeRomberg()
        {
            var value = 0.10447;
            var r1 = Rectangle(h1);
            var r2 = Rectangle(h2);
            var t1 = Trapeze(h1);
            var t2 = Trapeze(h2);
            var s1 = Simpson(h1);
            var s2 = Simpson(h2);
            var k = h1 / h2;
            Console.WriteLine("Integral rectangle:{0}",(r1-r2)/(k*k-1));
            Console.WriteLine("Error rectangle:{0}", (r1 - value) / (k * k - 1));
            Console.WriteLine("Integral trapeze:{0}", (t1 - t2) / (k * k - 1));
            Console.WriteLine("Error trapeze:{0}", (t1 - value) / (k * k - 1));
            Console.WriteLine("Integral Simpson:{0}", (s1 - s2) / (k * k - 1));
            Console.WriteLine("Error Simpson:{0}", (s1 - value) / (k * k - 1));
        }
    }
}
