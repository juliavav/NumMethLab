using System;
using System.Linq;

namespace NumMethLab3.Solutions
{
    class NewtonInterpolation
    {
        private Func<double, double> fi;
        private readonly double[] xi;
        private readonly int n;
        private string answer;

        public NewtonInterpolation(Func<double, double> fi, double[] xi)
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
            Console.WriteLine(answer.Remove(answer.Length - 2));
            return result;
        }

        private double[] CountCoefficients(double x)
        {
            var y = xi.Select(point => fi(point)).ToArray();
            var coefficients = new double[y.Length];
            y.CopyTo(coefficients, 0);

            for (int i = 1; i < coefficients.Length; i++)
            {
                for (int j = coefficients.Length - 1; j > i - 1; j--)
                {
                    coefficients[j] = (coefficients[j] - coefficients[j - 1]) / (xi[j] - xi[j - i]);
                }

            }

            return coefficients;
        }
    }
}
