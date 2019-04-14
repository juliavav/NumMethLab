using System;
using System.Linq;
using NumMethLab1.Matrix;
using matrix=NumMethLab1.Matrix.Matrix;

namespace NumMethLab1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var a = new double[3, 3];
            a[0, 0] = 1;
            a[1, 1] = 1;
            a[2, 2] = 1;
            double[,] b = {{1, 2, 3}, {1, 2, 3}, {1, 2, 2}};
            var A = new matrix(a);
            var B = new matrix(b);

            var result1 = Enumerable.Range(0, B.ColumnCount).Select(i => B[i, i]).Aggregate((x, y) => x * y);

            double[,] c = {{10, 1, 1}, {2, 10, 1}, {2, 2, 10}};

            var C = new matrix(c);
            var result = new LuDecomposition(C);

            result.LU.Print();
            Console.ReadLine();
        }
    }
}