using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethLab3.Solutions
{
    class LagrangeInterpolation
    {
        private Func<double, double> f;
        private readonly double[] xi;
        private readonly int n;
        private string answer;
        private string[] lAnswer;

        public LagrangeInterpolation(Func<double, double> f, double[] xi)
        {
            this.f = f;
            this.xi = xi;
            n = xi.Length;
            lAnswer = new string[n];
        }

        public double GetResult(double X)
        {
            return Ln(X);
        }

        private double CountLi(int i, double x)
        {
            var li = 1.0;

            for (int j = 0; j < n; j++)
            {
                if (j != i)
                {
                    li *= (x - xi[j]) / (xi[i] - xi[j]);
                    lAnswer[i]+=($"((x - {xi[j]})/({xi[i] - xi[j]}))*");
                }

            }

            return li;
        }

        private double Ln(double x)
        {
            var l = 0.0;
            answer = "Ln(x)=";

            for (int i = 0; i < n; i++)
            {
                l += f(xi[i]) * CountLi(i, x);
                answer += $"({f(xi[i])})*{lAnswer[i].Remove(lAnswer[i].Length-1)} + ";
            }

            answer = answer.Remove(answer.Length - 2);
            Console.WriteLine(answer);
            return l;
        }
    }
}
