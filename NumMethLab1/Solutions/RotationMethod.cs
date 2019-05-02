using System;
using static System.Math;
using matrix = NumMethLab1.Matrix.Matrix;

namespace NumMethLab1.Solutions
{
    class RotationMethod
    {
        private readonly matrix A;
        private readonly int dim;

        public RotationMethod(matrix A)
        {
            this.A = A;
            dim = A.ColumnCount;
        }

        public matrix GetAnswer()
        {
            var U = matrix.IdentityMatrix(dim);
            var Ak = new matrix(A);
            var count = 0;
            while (!IsFinished(Ak))
            {
                count++;
                var Uk = FindU(Ak);
                Ak = Uk.Transpose() * Ak * Uk;
                U = U * Uk;
            }
            Console.WriteLine("NumberOfIterations: {0}\n Lambda Matrix:", count);
            Ak.Print();
            return U;
        }

        private matrix FindU(matrix Ak)
        {
            double maxEl = 0;
            int iMax = 0;
            int jMax = 0;

            for (int i = 0; i < dim; ++i)
            {
                for (int j = i + 1; j < dim; ++j)
                {
                    if (Abs(Ak[i, j]) > maxEl)
                    {
                        iMax = i;
                        jMax = j;
                        maxEl = Abs(Ak[i, j]);
                    }
                }
            }

            double phi = CountPhi(Ak, iMax, jMax);

            var U = matrix.IdentityMatrix(dim);

            U[iMax, jMax] = -Sin(phi);
            U[jMax, iMax] = Sin(phi);
            U[jMax, jMax] = Cos(phi);
            U[iMax, iMax] = Cos(phi);

            return U;
        }

        private double CountPhi(matrix Ak, int iMax, int jMax)
        {
            return Abs(Ak[iMax, iMax] - Ak[jMax, jMax]) < Double.Epsilon
                ? PI / 4
                : 0.5 * Atan(2.0 * Ak[iMax, jMax] / (Ak[iMax, iMax] - Ak[jMax, jMax]));
        }

        private bool IsFinished(matrix Ak)
        {
            double sum = 0;

            for (int i = 0; i < dim; ++i)
            {
                for (int j = i + 1; j < dim; ++j)
                {
                    sum += Pow(Ak[i, j], 2);
                }
            }

            return Pow(sum, 0.5) < MatrixConstants.Eps;
        }


    }
}
