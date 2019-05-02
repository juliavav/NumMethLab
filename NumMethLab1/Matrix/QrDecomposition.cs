using System;
using System.ComponentModel;
using System.Linq;
using static System.Math;
using vector = NumMethLab1.Vector.Vector;

namespace NumMethLab1.Matrix
{
    class QrDecomposition
    {
        private readonly Matrix a;
        private readonly int dim;

        public Matrix Q { get; set; }
        public Matrix R { get; set; }
        public Matrix QR { get; set; }

        public QrDecomposition(Matrix a)
        {
            this.a = a;
            dim = a.ColumnCount;
            Decompose();
        }

        private void Decompose()
        {
            R = new Matrix(a);
            Q = Matrix.IdentityMatrix(a.ColumnCount);

            for (int i = 0; i < R.ColumnCount - 1; i++)
            {
                var b = R.GetColumn(i);
                var v = CountV(b, i);
                var H = GetHouseholderMatrix(v);

                Q *= H;

                R = H * R;
            }

            QR = Q * R;
        }

        private Matrix GetHouseholderMatrix(vector v)
        {
            var E = Matrix.IdentityMatrix(v.Length);
            return E + ( v.Transpose() * v * (-2.0 / vector.ScalarMultiply(v, v)));
        }

        private vector CountV(vector b, int firstToCount)
        {
            var e = vector.IdentityVector(firstToCount, b.Length);
            var v = new vector(Enumerable.Repeat(0.0, firstToCount).ToList());
            b.Elements = b.Skip(firstToCount).ToList();
            v.Elements.AddRange(b);

            return v + e * Sign(b[0]) * b.Rate2();
        }
    }
}
