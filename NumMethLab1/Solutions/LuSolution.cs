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
             
            for (int i = 0; i < dim-1; i++)
            {
                for (int j = i+1; j < dim; j++)
                {
                    vectorZ[j] -= lu.L[j,i] * vectorZ[i];
                }
            }

            for (int i = dim-1; i >= 0; i--)
            {
                vectorZ[i] /= lu.U[i, i];
;                for (int j = i-1; j >= 0; j--)
                {
                    vectorZ[j] -= lu.U[j, i] * vectorZ[i];
                }
            }


            return vectorZ;
        }

        private List<double> SwapVector(List<double> inputVector, Queue<int> queue)
        {
            while (queue.Count != 0)
            {
                var firstIndex = queue.Dequeue();
                var secondIndex = queue.Dequeue();

                var temp = inputVector[firstIndex];
                inputVector[firstIndex] = inputVector[secondIndex];
                inputVector[secondIndex] = temp;
            }

            return inputVector;
        }
    }
}
