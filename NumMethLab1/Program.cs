using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumMethLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] a = new double[3,3];
            a[0, 0] = 1;
            a[1,1] = 1;
            a[2, 2] = 1;
            double[,] b = {{1, 2, 3}, {1, 2, 3}};
            Matrix A = new Matrix(a);
            Matrix B = new Matrix(b);

            double[,] c = {{10, 1, 1}, {2, 10, 1}, {2, 2, 10}};

            Matrix C = new Matrix(c);
            var result = new LuDecomposition(C);

            result.LU.Print();
            Console.ReadLine();

        }
    }
}
