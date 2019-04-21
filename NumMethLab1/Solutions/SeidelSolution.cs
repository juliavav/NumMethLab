using NumMethLab1.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using matrix=NumMethLab1.Matrix.Matrix ;

namespace NumMethLab1.Solutions
{
    class SeidelSolution
    {
        private readonly matrix matrix;
        private readonly List<double> vectorB;
        private readonly int dim;

        public SeidelSolution(matrix matrix, List<double> vectorB)
        {
            this.vectorB = vectorB;
            this.matrix = matrix;
            dim = matrix.ColumnCount;
        }

        public List<double> GetAnswer()
        {
            var vectorBeta = new List<double>(vectorB);
            var matrixAlpha = new matrix(matrix);
            var matrixDInverse = Matrix.Matrix.IdentityMatrix(matrixAlpha.ColumnCount);

            for (int i = 0; i < dim; i++)
            {
                vectorBeta[i] /= matrix[i, i];
                matrixDInverse[i, i] = 1 / matrix[i, i];
            }

            matrixAlpha = Matrix.Matrix.IdentityMatrix(matrixAlpha.ColumnCount) - matrixDInverse * matrix;

            var matrixB = matrixAlpha.ToLower();
            var matrixC = matrixAlpha - matrixB;

            List<double> vectorX;
            var vectorXk = new List<double>(vectorBeta);
            var count = 0;
            do
            {
                count++;
                vectorX = new List<double>(vectorXk);
                vectorXk = vectorBeta.Sum(matrixAlpha.Multiply(vectorX));
                vectorXk = vectorBeta.Sum(matrixB.Multiply(vectorXk).Sum(matrixC.Multiply(vectorX)));
            } while (!IsFinished(vectorX, vectorXk, matrixAlpha, matrixC));


            Console.WriteLine("Number of Siedel iterations {0} ", count);
            return vectorXk;
        }

        public bool IsFinished(List<double> vectorXCurrent, List<double> vectorXPrevious, matrix matrixAlpha, matrix matrixC)
        {
            var vectorDiffRate = vectorXCurrent.Difference(vectorXPrevious).RateC();
            var matrixAlphaRate = matrixAlpha.RateC();
            var matrixCRate = matrixC.RateC();
            return Math.Abs(matrixAlphaRate - 1) < Double.Epsilon
                ? vectorDiffRate <= MatrixConstants.Eps
                : vectorDiffRate * matrixCRate / (1 - matrixAlphaRate) <= MatrixConstants.Eps;
        }

        public List<double> GetAnswer2()
        {
            var vectorBeta = new List<double>(vectorB);
            var matrixAlpha = new matrix(matrix);
            var matrixDInverse = Matrix.Matrix.IdentityMatrix(dim);

            for (int i = 0; i < dim; i++)
            {
                vectorBeta[i] /= matrix[i, i];
                matrixDInverse[i, i] = 1 / matrix[i, i];
            }

            matrixAlpha = Matrix.Matrix.IdentityMatrix(dim) - matrixDInverse * matrix;

            var matrixB = matrixAlpha.ToLower();
            var matrixC = matrixAlpha - matrixB;
            var matrixEbInverse = (Matrix.Matrix.IdentityMatrix(dim) - matrixB).Inverse();

            List<double> vectorX;
            var vectorXk = new List<double>(vectorBeta);
            var count = 0;
            do
            {
                count++;
                vectorX = new List<double>(vectorXk);
                vectorXk = ((matrixEbInverse*matrixC).Multiply(vectorX)).Sum(matrixEbInverse.Multiply(vectorBeta));
            } while (!IsFinished(vectorX, vectorXk, matrixAlpha, matrixC));


            Console.WriteLine("Number of Siedel2 iterations {0} ", count);
            return vectorXk;
        }

    }
}


