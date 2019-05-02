using NumMethLab1.Matrix;
using NumMethLab1.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using static System.Math;
using matrix = NumMethLab1.Matrix.Matrix;

namespace NumMethLab1.Solutions
{
    class QrMethod
    {
        private readonly matrix matrix;
        private readonly int dim;

        public QrMethod(matrix matrix)
        {
            this.matrix = matrix;
            dim = matrix.ColumnCount;
        }

        public List<Complex> GetAnswer()
        {
            var Ak = new matrix(matrix);
            var eigenvalues = new List<Complex>();
            for (int i = 0; i < dim; i++)
            {
                eigenvalues.Add(Ak[i,i]);
            }

            var numberOfIterations = 0;
            while (true)
            {
                var qrDecomposition = new QrDecomposition(Ak);
                Ak = qrDecomposition.R * qrDecomposition.Q;

                var nextEigenvalues = new List<Complex>();

                for (int i = 0; i < dim; i++)
                {
                    if (Ak.GetColumn(i).Skip(i + 1).ToList().Rate2() < MatrixConstants.Lab5Eps)
                    {
                        nextEigenvalues.Add(new Complex(Ak[i, i], 0));
                    }
                    else if (Ak.GetColumn(i).Skip(i + 2).ToList().Rate2() < MatrixConstants.Lab5Eps)
                    {
                        var roots = SolveQuadratic(Ak[i, i], Ak[i + 1, i + 1], Ak[i, i + 1], Ak[i + 1, i]);
                        nextEigenvalues.AddRange(roots);
                        i++;
                    }
                    else
                    {
                        nextEigenvalues.Clear();
                        break;
                    }
                }

                numberOfIterations++;

                if (nextEigenvalues.Count == dim)
                {
                    var isRootsFound = true;
                    for (int i = 0; i < dim; i++)
                    {
                        if (Abs(eigenvalues[i].Real - nextEigenvalues[i].Real) > MatrixConstants.Lab5Eps)
                        {
                            isRootsFound = false;
                            break;
                        }
                    }

                    if (isRootsFound)
                    {
                        break;
                    }
                    eigenvalues = new List<Complex>(nextEigenvalues);
                }
            }
            Console.WriteLine("Number of iterations: {0}", numberOfIterations);
            return eigenvalues;
        }


        private Complex[] SolveQuadratic(double a, double b, double c, double d)
        {
            double D = (a + b) * (a + b) - 4 * (a * b - c * d);
            var result = new Complex[2];
            Complex x1, x2;

            if (D < 0)
            {
                x1 = new Complex((a + b) / 2, Sqrt(-D) / 2);
                x2 = new Complex((a + b) / 2, -Sqrt(-D) / 2);
                result[0] = x1;
                result[1] = x2;
                return result;
            }

            if (Math.Abs(D) < Double.Epsilon)
            {
                x1 = new Complex((a + b) / 2, 0);
                result[0] = x1;
                return result;
            }

            x1 = new Complex((a + b + Math.Sqrt(D)) / 2, 0);
            x2 = new Complex((a + b - Math.Sqrt(D)) / 2, 0);
            result[0] = x1;
            result[1] = x2;
            return result;
        }

    }
}
