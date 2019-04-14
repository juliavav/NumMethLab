using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using matrix=NumMethLab1.Matrix.Matrix;

namespace NumMethLab1.Solutions
{
    public class LuSolution
    {
        private readonly matrix matrix;
        private readonly List<double> vector;
        private List<double> answer;

        public LuSolution(matrix matrix, List<double> vector)
        {
            this.matrix = matrix;
            this.vector = vector;
        }

        public List<double> GetAnswer()
        {
            
        }

    }
}
