using System;
using System.Collections.Generic;
using NumMethLab1.Vector;
using matrix = NumMethLab1.Matrix.Matrix;

namespace NumMethLab1.Solutions
{
    class SimpleIterationSolution
    {
        private readonly matrix matrix;
        private List<double> vectorB;
        private readonly int dim;

        public SimpleIterationSolution(matrix matrix, List<double> vectorB)
        {
            this.vectorB = vectorB;
            this.matrix = matrix;
        }

        public List<double> GetAnswer()
        {
            var vectorBeta = new List<double>(vectorB);
            var matrixAlpha = new matrix(matrix);
            var list = matrixAlpha.Multiply(vectorBeta);
            for (int i = 0; i < dim; i++)
            {
                vectorBeta[i] /= matrix[i, i];
                for (int j = 0; j < dim; j++)
                {
                    matrixAlpha[i, j] /= -1 * matrix[i, i];
                }
            }

            var vectorX = new List<double>(vectorBeta);
            var vectorXk = new List<double>();

            do
            {
                vectorXk = vectorBeta.Sum(matrixAlpha.Multiply(vectorX));
            } while (!IsFinished(vectorX, vectorXk));
        }

        public bool IsFinished(List<double> vectorX, List<double> vectorXk)
        {

        }

    }
}
