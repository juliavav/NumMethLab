using System;
using System.Collections.Generic;
using System.Linq;

namespace NumMethLab1.Vector
{
    public static class ListExtension
    {
        public static void Print(this List<double> inputList) => inputList.ForEach(Console.WriteLine);

        public static double RateC(this List<double> inputList) => inputList.Max(Math.Abs);

        public static double Rate2(this List<double> inputList)
        {
            double sum = 0.0;
            foreach (var element in inputList)
            {
                sum += Math.Pow(element, 2);
            }

            return Math.Pow(sum, 0.5);
        }

        public static List<double> Multiply(this List<double> inputList, int number) => inputList.Select(item => item * number).ToList();

        public static List<double> Multiply(this List<double> inputList, double number) => inputList.Select(item => item * number).ToList();

        public static List<double> Sum(this List<double> firstList, List<double> secondList) => Enumerable.Range(0, firstList.Count).Select(i => firstList[i] + secondList[i]).ToList();

        public static List<double> Difference(this List<double> firstList, List<double> secondList) => Enumerable.Range(0, firstList.Count).Select(i => firstList[i] - secondList[i]).ToList();
        
    }
}
