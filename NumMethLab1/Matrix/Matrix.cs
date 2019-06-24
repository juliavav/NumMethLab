using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NumMethLab1.Solutions;

namespace NumMethLab1.Matrix
{
    public class Matrix : IEnumerable<double>
    {
        public double[,] Elements { get; set; }

        public double this[int i, int j]
        {
            get => Elements[i, j];
            set => Elements[i, j] = value;
        }

        public Matrix(int n, int m)
        {
            Elements = new double[n, m];
        }

        public Matrix(int n)
        {
            Elements = new double[n, n];
        }

        public Matrix(Vector.Vector a)
        {
            Elements = new double[1, a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                Elements[0, i] = a[i];
            }
        }

        public Matrix(Vector.Vector a, bool t)
        {
            Elements = new double[a.Length, 1];
            for (int i = 0; i < a.Length; i++)
            {
                Elements[i, 0] = a[i];
            }
        }

        public Vector.Vector GetColumn(int j)
        {
            var result = new List<double>();
            for (int i = 0; i < this.RowCount; i++)
            {
                result.Add(this[i,j]);
            }
            return new Vector.Vector(result);
        }
        public Matrix(Matrix copyMatrix)
        {
            Elements = new double[copyMatrix.RowCount, copyMatrix.ColumnCount];
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

        public double RateC()
        {
            var maximum = 0.0;
            for (int i = 0; i < RowCount; i++)
            {
                var summ = 0.0;
                for (int j = 0; j < ColumnCount; j++)
                {
                    summ += Math.Abs(this[i, j]);
                }

                if (maximum < summ)
                    maximum = summ;
            }

            return maximum;
        }

        //public Matrix(List<List<double>> elements)
        //{
        //    Elements = new double[elements.Count, elements.Count];
        //    for (int i = 0; i < elements.Count; i++)
        //    {
        //        for (int j = 0; j < elements.Count; j++)
        //        {
        //            Elements[i, j] = elements[i][j];
        //        }
        //    }
        //}

        public Matrix(List<List<double>> elements)
        {
            Elements = new double[elements[0].Count, elements.Count];
            for (int i = 0; i < elements[0].Count; i++)
            {
                for (int j = 0; j < elements.Count; j++)
                {
                    Elements[i, j] = elements[j][i];
                }
            }
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

        public static Matrix operator *(Matrix A, double number)
        {
            return MatrixComputation.Multiply(A, number);
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            return MatrixComputation.Summarize(A, B);
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            return MatrixComputation.Difference(A, B);
        }

        public static Matrix operator *(Matrix A, Vector.Vector B)
        {
            return A * (new Matrix(B));
        }

        public static Matrix operator *(Vector.Vector B, Matrix A)
        {
            return (new Matrix(B))*A;
        }
        public void SwapRows(int first, int second)
        {
            if (first != second)
            {
                for (var i = first; i < ColumnCount; i++)
                {
                    var temp = Elements[second, i];
                    Elements[second, i] = Elements[first, i];
                    Elements[first, i] = temp;
                }
            }
        }

        public Matrix ToLower()
        {
            var answer = new Matrix(this);
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (j >= i) answer[i, j] = 0;
                }
            }

            return answer;
        }

        public Matrix Transpose()
        {
            var tempElements = new double[ColumnCount, RowCount];
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    tempElements[j, i] = Elements[i, j];
                }
            }

            return new Matrix(tempElements);
        }

        public double Determinant()
        {
            var lu = new LuDecomposition(this);
            return lu.Determinant();
        }

        public Matrix Inverse()
        {
            var E = IdentityMatrix(RowCount);
            var X = new List<List<double>>();
            for (int i = 0; i < RowCount; i++)
            {
                var list = Enumerable.Repeat(0.0, RowCount).ToList();
                list[i] = 1.0;
                X.Add(new LuSolution(new Matrix(this),list).GetAnswer());
            }

            return new Matrix(X).Transpose();
        }

        public static Matrix ZerosMatrix(int nRows, int nCols)
        {
            double[,] zerosMatrix = new double[nRows, nCols];
            return new Matrix(zerosMatrix);
        }

        public static Matrix ZerosMatrix(int n)
        {
            double[,] zerosMatrix = new double[n, n];
            return new Matrix(zerosMatrix);
        }

        public static Matrix IdentityMatrix(int matrixSize)
        {
            double[,] identMatrix = new double[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                identMatrix[i, i] = 1;
            }
            return new Matrix(identMatrix);
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

        public List<double> Multiply(List<double> inputList)
        {
            return MatrixComputation.Multiply(this, inputList);
        }

        public void Print()
        {
            for (int i = 0; i < ColumnCount; ++i)
            {
                for (int j = 0; j < RowCount; j++)
                {
                    Console.Write("{0:N} ", Elements[i, j]);
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

