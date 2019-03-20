using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethLab1
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

            return a ;
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
    }
}

