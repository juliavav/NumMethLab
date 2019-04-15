using System;
using System.Collections.Generic;
using NumMethLab1.Solutions;
using static NumMethLab1.MatrixConstants;
using matrix = NumMethLab1.Matrix.Matrix;

namespace NumMethLab1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Lab2();
            Console.ReadLine();
            Console.Clear();
            Lab1();
            Console.ReadLine();
        }

        private static void Lab1()
        {
            var A = new matrix(Lab1Matrix);
            var b = new List<double>(Lab1Vector);

            var solution = new LuSolution(A, b);
            var answer = solution.GetAnswer();
            var inverse = A.Inverse();
            var determinant = A.Determinant();

            Console.WriteLine("A:");
            A.Print();
            var temp = A.RateC();
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

        private static void Lab2()
        {
            var answer = new TridiagonalSolution(a,b,c,d).GetAnswer();
            Console.WriteLine("a:");
            Console.WriteLine("b:");
            Console.WriteLine("c:");
            Console.WriteLine("d:");

            Console.WriteLine("answer:");
            Print(answer);
        }

        private static void Print(List<double> inputList) => inputList.ForEach(Console.WriteLine);
    }
}