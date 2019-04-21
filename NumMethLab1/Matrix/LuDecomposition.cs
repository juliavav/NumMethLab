using System;
using System.Collections.Generic;
using System.Linq;

namespace NumMethLab1.Matrix
{
    public class LuDecomposition
    {
        private readonly Matrix a;
        private readonly int dim;

        public Stack<int> SwappedElements { get; }

        public LuDecomposition(Matrix a)
        {
            this.a = a;
            dim = a.ColumnCount;
            SwappedElements = new Stack<int>();
            Decompose();
        }

        public Matrix L { get; set; }
        public Matrix U { get; set; }
        public Matrix LU { get; set; }


        public double Determinant()
        {
            // ReSharper disable once PossibleLossOfFraction
            return Math.Pow(-1, SwappedElements.Count / 2) *
                   Enumerable.Range(0, dim).Select(i => LU[i, i]).Aggregate((x, y) => x * y);
        }

        private void Decompose()
        {
            if (a == null)
                throw new ArgumentException("Matrix can't be null.");

            U = new Matrix(a);
            L = Matrix.IdentityMatrix(dim);


            var currentK = 0;

            for (var k = 0; k < dim; k++)
            {
                double p = 0;

                for (var i = k; i < dim; i++)
                    if (Math.Abs(a[i, k]) > p)
                    {
                        p = Math.Abs(a[i, k]);
                        currentK = i;
                    }

                if (Math.Abs(p) < double.Epsilon)
                    throw new ArgumentException("Bad matrix");

                if (k != currentK)
                {
                    L.SwapRows(k, currentK);
                    U.SwapRows(k, currentK);
                    SwappedElements.Push(currentK);
                    SwappedElements.Push(k);
                }

                L[k, k] = 1;


                for (var i = k + 1; i < dim; i++)
                {
                    L[i, k] = U[i, k] / U[k, k];
                    for (var j = k; j < dim; j++)
                        U[i, j] = U[i, j] - L[i, k] * U[k, j];
                }
            }

            LU = new Matrix(L + U + Matrix.IdentityMatrix(dim) * -1);
        }
    }
}