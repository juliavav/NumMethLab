using System;
using System.Collections.Generic;
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

            for (int i = 0; i < dim; i++)
            {
                vectorBeta[i] /= matrix[i, i];
                for (int j = 0; j < dim; j++)
                {
                    matrixAlpha[i, j] /= -1 * matrix[i, i];
                }
            }

            return vectorBeta;
        }


    }
}
