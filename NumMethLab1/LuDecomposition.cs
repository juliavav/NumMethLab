using System;
using System.Collections;

namespace NumMethLab1
{
    public class LuDecomposition
    {
        private readonly int matrixSize;
        private readonly Matrix a;

        private Stack swappedElements;

        public Matrix L { get; set; }
        public Matrix U { get; set; }
        public Matrix LU { get; set; }

        public LuDecomposition(Matrix a)
        {
            this.a = a;
            matrixSize = a.ColumnCount;
            swappedElements = new Stack();
            Decompose();
        }

        //private int FindRowWithMaxColumnElement(int columnNumber) //looks like working 
        //{
        //    var maxElement = Math.Abs(a[columnNumber, columnNumber]); //check index
        //    var maxElementIndex = columnNumber;

        //    // Поиск максимального элемента в j столбце
        //    for (var i = columnNumber + 1; i < matrixSize; i++)
        //        if (Math.Abs(a[i, columnNumber]) > maxElement)
        //        {
        //            maxElement = Math.Abs(a[i, columnNumber]);
        //            maxElementIndex = i;
        //        }

        //    return maxElementIndex;
        //}

        private void Decompose()
        {
            if (a == null)
            {
                throw new ArgumentException("Matrix can't be null.");
            }

            U = new Matrix(a);
            L = Matrix.IdentityMatrix(matrixSize);
            

            var currentK = 0;

            for (var k = 0; k < matrixSize; k++)
            {
                double p = 0;
                for (var i = k; i < matrixSize; i++)
                {
                    if (Math.Abs(a[i, k]) > p)
                    {
                        p = Math.Abs(a[i, k]);
                        currentK = i;
                    }
                }
                if (Math.Abs(p) < Double.Epsilon)
                {
                    throw new ArgumentException("Bad matrix");
                }

                L.SwapRows(k, currentK);
                U.SwapRows(k,currentK);
                swappedElements.Push(currentK);
                swappedElements.Push(k);
                
                for (int i = k + 1; i < matrixSize; i++)
                {
                    L[i,k] = U[i, k] / U[k, k];
                    for (int j = k; j < matrixSize; j++)
                    {
                        U[i, j] = U[i, j] - L[i,k]* U[k, j];
                    }
                }
            }
            LU = new Matrix(L + U + Matrix.IdentityMatrix(matrixSize)*(-1));
        }
    }
}