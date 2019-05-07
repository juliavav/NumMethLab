using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethLab3.Solutions
{
    class NewtonInterpolation
    {
        private readonly double[] fi;
        private readonly double[] xi;
        private readonly int n;
        private string answer;

        public NewtonInterpolation(double[] fi,double[] xi)
        {
            this.fi = fi;
            this.xi = xi;
            n = xi.Length;
        }

        public double GetResult(double X)
        {
            var coefficients = CountCoefficients(X);
            var result = coefficients[0];
            answer = $"Pn(x) = {result} +";
            for (int i = 1; i < n; i++)
            {
                var resultSum = 1.0;
                for (int j = 0; j < i; j++)
                {
                    resultSum *= X - xi[j];
                    answer += $"(x - {xi[j]})";
                }

                answer += $"*({coefficients[i]}) + ";
                resultSum *= coefficients[i];
                result += resultSum;
            }
            Console.WriteLine(answer.Remove(answer.Length-2));
            return result;
        }

        private double H(int i) => xi[i] - xi[i - 1];
        private double[] CountA()
        {
           var a = fi;
           return a;
        }

        private double[] CountB(double[] c)
        {
            var b = new double[n];
            for (int i = 0; i < n; i++)
            {
                b[i] = (fi[i+1]-fi[i])/H(i) - 1/3.0*H(i)*(c[i+1]+2*c[i])
            }
        }

    }
}
