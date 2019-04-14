using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NumMethLab1.Matrix
{
    public class Matrix : IEnumerable<double>
    {
        public double[,] Elements { get; set; }

        public double this[int i, int j]
        {
            get => Elements[i,j];
            set => Elements[i,j] = value;
        }
        
        public Matrix(int n, int m)
        {
            Elements = new double[n,m];
        }

        public Matrix(int n)
        {
            Elements = new double[n, n];
        }

        public Matrix(Matrix copyMatrix)
        {
            Elements = new double[copyMatrix.RowCount,copyMatrix.ColumnCount];
            for (int i = 0; i < copyMatrix.RowCount; i++)
            {
                for (int j = 0; j < copyMatrix.ColumnCount; j++)
                {
                    Elements[i, j] = copyMatrix[i, j];
                }
            }
        }

        public Matrix(double[,] elements)
        {
            Elements = elements;
        }
       
        public int RowCount => Elements.GetLength(0);

        public int ColumnCount => Elements.GetLength(1);

        public int Count => Elements.Length;

        public static Matrix operator *(Matrix A, Matrix B)
        {
            return MatrixComputation.Multiply(A, B);
        }

        public static Matrix operator *(Matrix A, int number)
        {
            return MatrixComputation.Multiply(A, number);
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            return MatrixComputation.Summarize(A, B);
        }

        public void SwapRows(int first, int second)
        {
            if (first != second)
            {
                for (var i = first; i < ColumnCount; i++)
                {
                    var temp = Elements[i, second];
                    Elements[i, second] = Elements[i, first];
                    Elements[i, first] = temp;
                }
            }
        }
        //public Matrix Transpose()
        //{
        //   ;
        //}

        
        public static Matrix ZerosMatrix(int nRows, int nCols)
        {
            double[,] zerosMatrix = new double[nRows,nCols]; 
            return new Matrix(zerosMatrix);
        }

        public static Matrix IdentityMatrix(int matrixSize)
        {
            double[,] identyMatrix = new double[matrixSize,matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                identyMatrix[i,i] = 1;
            }
            return new Matrix(identyMatrix);
        }
        
        IEnumerator<double> IEnumerable<double>.GetEnumerator()
        {
            foreach (var item in Elements)
                yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this.AsEnumerable();
        }

        public void Print()
        {
            for (int i = 0; i < ColumnCount; ++i)
            {
                for (int j = 0; j < RowCount; j++)
                {
                    Console.Write("{0:N} ", Elements[i,j]);
                }
                Console.WriteLine();
            }
        }
       
        public bool Equals(Matrix other)
        {
            throw new NotImplementedException();
        }
        
    }
}

