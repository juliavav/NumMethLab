using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumMethLab1.Matrix;
using NumMethLab1.Solutions;
using NumMethLab1.Vector;

namespace NumMethLab3.Solutions
{
    class MinSquareMethod
    {
        private readonly double[] fi;
        private readonly double[] xi;
        private List<double> coefficients;

        public MinSquareMethod(double[] fi, double[] xi)
        {
            this.fi = fi;
            this.xi = xi;
        }

        private double F(double x)
        {
            var result = 0.0;
            for (int i = 0; i < coefficients.Count; i++)
            {
                result += coefficients[i] * Math.Pow(x, i);
            }

            return result;
        }
        private double Error(Func<double, double> f) =>
            Enumerable.Range(0, xi.Length).Select(i => Math.Pow(f(xi[i]) - fi[i], 2)).Sum();

        public void GetAnswer(int n)
        {
            var listF= new List<List<double>>();
            for (int i = 0; i < n; i++)
            {
                var phi = xi.Select(j => Math.Pow(j, i)).ToList();
                listF.Add(phi);
            }

            var matrixF = new Matrix(listF);
            var matrixFT = matrixF.Transpose();
            var G = matrixFT * matrixF;
            var y = new Vector(fi);
            var z = matrixFT * y.Transpose();
            var lu = new LuSolution(G,z.GetColumn(0).Elements);
            coefficients = lu.GetAnswer();
            Console.WriteLine("Error:{0}",Error(F));

        }

    }
}
