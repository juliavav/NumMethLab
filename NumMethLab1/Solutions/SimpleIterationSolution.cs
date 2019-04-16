using System;
using System.Collections.Generic;
using NumMethLab1.Vector;
using static System.Double;
using matrix = NumMethLab1.Matrix.Matrix;

namespace NumMethLab1.Solutions
{
    class SimpleIterationSolution
    {
        private readonly matrix matrix;
        private readonly List<double> vectorB;
        private readonly int dim;

        public SimpleIterationSolution(matrix matrix, List<double> vectorB)
        {
            this.vectorB = vectorB;
            this.matrix = matrix;
            dim = matrix.ColumnCount;
        }

        public List<double> GetAnswer()
        {
            var vectorBeta = new List<double>(vectorB);
            var matrixAlpha = new matrix(matrix);
            var matrixDInverse = matrix.IdentityMatrix(matrixAlpha.ColumnCount);

            for (int i = 0; i < dim; i++)
            {
                vectorBeta[i] /= matrix[i, i];
                matrixDInverse[i, i] = 1 / matrix[i, i];
            }

            matrixAlpha = matrix.IdentityMatrix(matrixAlpha.ColumnCount) - matrixDInverse * matrix;

            List<double> vectorX;
            var vectorXk = new List<double>(vectorBeta);
            var count = 0;
            do
            {
                count++;
                vectorX = new List<double>(vectorXk);
                vectorXk = vectorBeta.Sum(matrixAlpha.Multiply(vectorX));
            } while (!IsFinished(vectorX, vectorXk, matrixAlpha));

            Console.WriteLine("Number of Simple iterations {0}",count);
            return vectorXk;
        }

        public bool IsFinished(List<double> vectorXCurrent, List<double> vectorXPrevious, matrix matrixAlpha)
        {
            var vectorDiffRate = vectorXCurrent.Difference(vectorXPrevious).RateC();
            var matrixAlphaRate = matrixAlpha.RateC();
            return Math.Abs(matrixAlphaRate - 1) < Epsilon
                ? vectorDiffRate <= MatrixConstants.Eps
                : vectorDiffRate * matrixAlphaRate / (1 - matrixAlphaRate) <= MatrixConstants.Eps;
        }

    }
}
