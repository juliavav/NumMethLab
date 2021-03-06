﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumMethLab1.Solutions;
using NumMethLab3.Helpers;

namespace NumMethLab3.Solutions
{
    class SplineInterpolation
    {
        private readonly double[] fi;
        private readonly double[] xi;
        private readonly int n;

        public SplineInterpolation(double[] fi, double[] xi)
        {
            this.fi = fi;
            this.xi = xi;
            n = xi.Length;
        }

        public void GetAnswer(double x)
        {
            var a = CountA();
            var c = CountC();
            var b = CountB(c);
            var d = CountD(c);

            var i = IntervalHelpers.FindI(xi, x);

            Console.WriteLine($"S(x)={a[i + 1]} + {b[i + 1]}*x + {c[i + 1]}*x*x + {d[i + 1]}*x*x*x");
            Console.WriteLine($"S({x})={F(x - xi[i], a[i + 1], b[i + 1], c[i + 1], d[i + 1])}");
        }
        private double H(int i) => xi[i] - xi[i - 1];

        private double F(double x, double a, double b, double c, double d) =>
            a + b * x + c * Math.Pow(x, 2) + d * Math.Pow(x, 3);

        private double[] CountA()
        {
            var a = new List<double> {0};
            a.AddRange(fi);
            a.RemoveAt(a.Count-1);
            return a.ToArray();
        }

        private double[] CountB(double[] c)
        {
            var b = Enumerable.Repeat(0.0,n-1).ToList();
            for (int i = 1; i < n-1; i++)
            {
                b[i] = (fi[i] - fi[i-1]) / H(i) - 1 / 3.0 * H(i) * (c[i + 1] + 2 * c[i]);
            }

            b.Add((fi[n - 1] - fi[n - 2]) / H(n - 1) - 2.0 / 3 * H(n - 1) * c[n - 1]);
            return b.ToArray();
        }

        private double[] CountC()
        {
            var a = new List<double> { 0 };
            Enumerable.Range(2,n-3).Select(H).ToList().ForEach(a.Add);

            var b = Enumerable.Range(2, n-2).Select(item => 2 * (H(item - 1) + H(item))).ToList();

            var c = Enumerable.Range(2, n-3 ).Select(H).ToList();
            c.Add(0);

            var d = Enumerable.Range(2, n-2)
                .Select(i => 3 * ((fi[i] - fi[i - 1]) / H(i) - (fi[i - 1] - fi[i - 2]) / H(i - 1))).ToList();

            var answer = new TridiagonalSolution(a, b, c, d).GetAnswer();
            answer.Insert(0,0);
            answer.Insert(0, 0);
            return answer.ToArray();
        }

        private double[] CountD(double[] c)
        {
            var d = new List<double> {0};
            Enumerable.Range(1,n-2).Select(i=>(c[i+1]-c[i])/(3*H(i))).ToList().ForEach(d.Add);
            d.Add(-c[n-1]/(3*H(n-1)));
            return d.ToArray();
        }
    }
}
