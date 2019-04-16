using System;
using System.Collections.Generic;
using System.Linq;

namespace NumMethLab1.Vector
{
    public static class ListExtension
    {
        public static void Print(this List<double> inputList) => inputList.ForEach(Console.WriteLine);

        public static double RateC(this List<double> inputList) => inputList.Max(Math.Abs);

        public static List<double> Multiply(this List<double> inputList, int number) => inputList.Select(item => item * number).ToList();

        public static List<double> Multiply(this List<double> inputList, double number) => inputList.Select(item => item * number).ToList();

        public static List<double> Sum(this List<double> firstList, List<double> secondList) => Enumerable.Range(0, firstList.Count).Select(i => firstList[i] + secondList[i]).ToList();

        public static List<double> Difference(this List<double> firstList, List<double> secondList) => Enumerable.Range(0, firstList.Count).Select(i => firstList[i] - secondList[i]).ToList();

    }
}
