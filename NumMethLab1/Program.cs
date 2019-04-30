using System;
using System.Collections.Generic;
using NumMethLab1.Services;
using NumMethLab1.Solutions;
using static NumMethLab1.MatrixConstants;
using matrix = NumMethLab1.Matrix.Matrix;

namespace NumMethLab1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ReadingService.ReadLab1();
            Lab4();
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

        private static void Lab3()
        {
            var A = new matrix(Lab3Matrix);
            var b = new List<double>(Lab3Vector);


            var solution = new SimpleIterationSolution(A, b);
            var answer = solution.GetAnswer();

            Console.WriteLine("A:");
            A.Print();
            Console.WriteLine();
            Console.WriteLine("b:");
            Print(b);
            Console.WriteLine("X1:");
            Print(answer);

            var solution2 = new SeidelSolution(A, b);
            var answer2 = solution2.GetAnswer();
            Console.WriteLine("X2:");
            Print(answer2);

            var answer3 = solution2.GetAnswer2();
            Console.WriteLine("X3:");
            Print(answer3);
        }

        private static void Lab4()
        {
            var A = new matrix(Lab4Matrix);
            var answer = new RotationMethod(A).GetAnswer();
            Console.WriteLine("U matrix:");
            answer.Print();
        }

        private static void Print(List<double> inputList) => inputList.ForEach(Console.WriteLine);
    }
}