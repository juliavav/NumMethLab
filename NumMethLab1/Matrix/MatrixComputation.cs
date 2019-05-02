using System;
using System.Collections.Generic;
using System.Linq;

namespace NumMethLab1.Matrix
{
    class MatrixComputation
    {
        internal static Matrix Multiply(Matrix a, Matrix b)
        {
            int mA = a.RowCount, mB = b.RowCount,
                nA = a.ColumnCount, nB = b.ColumnCount;
            if (nA != mB)
                throw new ArgumentException(
                    "Size not match!");

            var ans = new double[mA, nB];
            for (int i = 0; i < mA; ++i)
            {
                for (int j = 0; j < nA; ++j)
                {
                    for (int k = 0; k < nB; k++)
                    {
                        ans[i, k] += a[i, j] * b[j, k];
                    }
                }
            }
            return new Matrix(ans);
        }

        internal static Matrix Multiply(Matrix a, int number)
        {
            for (int i = 0; i < a.ColumnCount; i++)
            {
                for (int j = 0; j < a.RowCount; j++)
                {
                    a[i, j] *= number;
                }
            }

            return a;
        }

        internal static Matrix Summarize(Matrix a, Matrix b)
        {
            if (a.ColumnCount != b.ColumnCount || a.RowCount != b.RowCount)
            {
                throw new ArgumentException("Matrix sizes not match!");
            }

            for (int i = 0; i < a.RowCount; i++)
            {
                for (int j = 0; j < a.ColumnCount; j++)
                {
                    a[i, j] += b[i, j];
                }
            }

            return a;
        }

        internal static List<double> Multiply(Matrix matrix, List<double> vector)
        {
            if (matrix.ColumnCount != vector.Count)
            {
                throw new ArgumentException("Sizes not match!");
            }

            var answer = Enumerable.Repeat(0.0, vector.Count).ToList();

            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    answer[i] += vector[j]*matrix[i, j];
                }
            }

            return answer;
        }

        public static Matrix Difference(Matrix a, Matrix b)
        {
            if (a.ColumnCount != b.ColumnCount || a.RowCount != b.RowCount)
            {
                throw new ArgumentException("Matrix sizes not match!");
            }

            for (int i = 0; i < a.RowCount; i++)
            {
                for (int j = 0; j < a.ColumnCount; j++)
                {
                    a[i, j] -= b[i, j];
                }
            }

            return a;
        }

        public static Matrix Multiply(Matrix a, double number)
        {
            for (int i = 0; i < a.ColumnCount; i++)
            {
                for (int j = 0; j < a.RowCount; j++)
                {
                    a[i, j] *= number;
                }
            }

            return a;
        }
    }
}

