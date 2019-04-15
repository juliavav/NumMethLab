using NumMethLab1.Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using matrix = NumMethLab1.Matrix.Matrix;

namespace NumMethLab1.Solutions
{
    public class LuSolution
    {
        private readonly matrix matrix;
        private List<double> vectorB;
        private readonly int dim;

        public LuSolution(matrix matrix, List<double> vectorB)
        {
            if (matrix.RowCount != vectorB.Count)
            {
                throw new ArgumentException("Size not match!");
            }
            this.matrix = matrix;
            this.vectorB = vectorB;
            dim = vectorB.Count;
        }

        public List<double> GetAnswer()
        {
            var lu = new LuDecomposition(matrix);
            vectorB = SwapVector(vectorB, lu.SwappedElements);
            var vectorZ = new List<double>(vectorB);
            
            for (int i = 1; i < dim; i++)
            {
                var sum = 0.0;
                for (int j = 0; j < i; j++)
                {
                    sum += lu.L[i, j] * vectorZ[j];
                }

                vectorZ[i] = vectorB[i] - sum;
            }

            var vectorX = new List<double>(vectorZ) {[dim - 1] = vectorZ[dim - 1] / lu.U[dim - 1, dim - 1]};
            for (int i = dim-1; i > 0; i--)
            {
                var sum = 0.0;
                for (int j = i; j < dim; j++)
                {
                    sum += lu.U[i - 1, j] * vectorX[j];
                }

                vectorX[i - 1] = (vectorZ[i - 1] - sum) / lu.U[i - 1, i - 1];
            }


            return vectorX;
        }

        private List<double> SwapVector(List<double> inputVector, Stack<int> stack)
        {
            while (stack.Count != 0)
            {
                var firstIndex = stack.Pop();
                var secondIndex = stack.Pop();

                var temp = inputVector[firstIndex];
                inputVector[firstIndex] = inputVector[secondIndex];
                inputVector[secondIndex] = temp;
            }

            return inputVector;
        }
    }
}
