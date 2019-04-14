using NumMethLab1.Solutions;
using System;
using System.Collections.Generic;
using matrix = NumMethLab1.Matrix.Matrix;

namespace NumMethLab1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Lab1();
            Console.ReadLine();
            Console.Clear();
            Console.ReadLine();
        }

        private static void Lab1()
        {
            var A = new matrix(MatrixConstants.Lab1Matrix);
            var b = new List<double>(MatrixConstants.Lab1Vector);

            var solution = new LuSolution(A, b);
            var answer = solution.GetAnswer();
            var inverse = A.Inverse();
            var determinant = A.Determinant();

            Console.WriteLine("A:");
            A.Print();
            Console.WriteLine();
            Console.WriteLine("b:");
            Print(b);
            Console.WriteLine();
            Console.WriteLine("A^(-1):");
            inverse.Print();
            Console.WriteLine();
            Console.WriteLine("X:");
            Print(answer);
            Console.WriteLine();
            Console.WriteLine("Det(A) = {0}", determinant);
        }

        private static void Print(List<double> inputList) => inputList.ForEach(Console.WriteLine);
    }
}