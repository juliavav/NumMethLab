﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NumMethLab1.Matrix;
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
            Lab1();
            Lab3();
            Lab4();
            Lab5();
            Console.ReadLine();
        }

        private static void Lab1()
        {
            ReadingService.ReadLab1();
            var A = new matrix(Lab1Matrix);
            Console.WriteLine("A:");
            A.Print();
            var b = new List<double>(Lab1Vector);

            var solution = new LuSolution(new matrix(A), b);
            var answer = solution.GetAnswer();
            var inverse = A.Inverse();
            var determinant = A.Determinant();

            
            Console.WriteLine();
            Console.WriteLine("b:");
            Print(Lab1Vector.ToList());
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
            ReadingService.ReadLab3();
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
            ReadingService.ReadLab4();
            var A = new matrix(Lab4Matrix);
            var answer = new RotationMethod(A).GetAnswer();
            Console.WriteLine("U matrix:");
            answer.Print();
        }

        private static void Lab5()
        {
            ReadingService.ReadLab5();
            var A = new matrix(Lab5Matrix);
            var answer = new QrMethod(A).GetAnswer();
            Console.WriteLine("Eigenvalues");
            Print(answer);
        }

        private static void Print(List<double> inputList) => inputList.ForEach(Console.WriteLine);

        private static void Print(List<Complex> inputList) => inputList.ForEach(item => Console.WriteLine("({0}, {1}i)",item.Real,item.Imaginary));
    }
}