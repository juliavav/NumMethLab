using System;
using System.Collections;
using System.Linq;

namespace NumMethLab1.Matrix
{
    public class LuDecomposition
    {
        private readonly Matrix a;
        private readonly int matrixSize;

        private readonly Stack swappedElements;

        public LuDecomposition(Matrix a)
        {
            this.a = a;
            matrixSize = a.ColumnCount;
            swappedElements = new Stack();
            Decompose();
        }

        public Matrix L { get; set; }
        public Matrix U { get; set; }
        public Matrix LU { get; set; }


        public double Determinant()
        {
            // ReSharper disable once PossibleLossOfFraction
            return Math.Pow(-1, swappedElements.Count / 2) *
                   Enumerable.Range(0, matrixSize).Select<int, double>(i => LU[i, i]).Aggregate((x, y) => x * y);
        }

        private void Decompose()
        {
            if (a == null)
                throw new ArgumentException("Matrix can't be null.");

            U = new Matrix(a);
            L = Matrix.IdentityMatrix(matrixSize);


            var currentK = 0;

            for (var k = 0; k < matrixSize; k++)
            {
                double p = 0;
                for (var i = k; i < matrixSize; i++)
                    if (Math.Abs((double) a[i, k]) > p)
                    {
                        p = Math.Abs((double) a[i, k]);
                        currentK = i;
                    }
                if (Math.Abs(p) < double.Epsilon)
                    throw new ArgumentException("Bad matrix");

                L.SwapRows(k, currentK);
                U.SwapRows(k, currentK);
                swappedElements.Push(currentK);
                swappedElements.Push(k);

                for (var i = k + 1; i < matrixSize; i++)
                {
                    L[i, k] = U[i, k] / U[k, k];
                    for (var j = k; j < matrixSize; j++)
                        U[i, j] = U[i, j] - L[i, k] * U[k, j];
                }
            }

            LU = new Matrix(L + U + Matrix.IdentityMatrix(matrixSize) * -1);
        }
    }
}