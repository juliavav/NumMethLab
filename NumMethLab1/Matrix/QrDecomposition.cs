using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using matrix = NumMethLab1.Matrix.Matrix;
using vector = NumMethLab1.Vector.Vector;

namespace NumMethLab1.Matrix
{
    class QrDecomposition
    {
        private readonly Matrix a;
        private readonly int dim;
        
        public QrDecomposition(Matrix a)
        {
            this.a = a;
            dim = a.ColumnCount;
            //Decompose();
        }

        //private Matrix Decompose()
        //{

        //}

        //private Matrix GetHouseholderMatrix(vector v)
        //{

        //}

        //private vector CountV(vector b)
        //{
             
        //}
    }
}
