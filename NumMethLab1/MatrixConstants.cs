using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethLab1
{
    public static class MatrixConstants
    {
        public static double[,] Lab1Matrix = { { 1, 2, 3 }, { 1, 8, 3 }, { 8, 2, 9 } };
        public static double[] Lab1Vector = {1, 22, 3};

        public static List<double> a = new List<double>{ 0, -5, -5, -9, 1 };
        public static List<double> b = new List<double> { 8, 22, -11, -15, 7 };
        public static List<double> c = new List<double> { 4, 8, 1, 1, 0 };
        public static List<double> d = new List<double> { 48, 125, -43, 18, -23 };

        public const int N = 5;

        public const double Eps = 0.0000001;

        public static double[,] Lab3Matrix = {{20, 5, 7, 1}, {-1, 13, 0, -7}, {4, -6, 17, 5}, {-9, 8, 4, -25}};
        public static double[] Lab3Vector = { -117,-1,49,-21};

        public static double[,] Lab4Matrix = { { 0,-7,7 }, { -7, -9, -5 }, { 7,-5,-1 }};

        public static double[,] Lab5Matrix = { { 5, 8, -2 }, { 7, -2, -4 }, { 5, 8, -1 } };
        public const double Lab5Eps = 0.01;
        //public static double[,] Lab5Matrix = { {  9,  0,  2, -6,  1},
        //    { -6,  4,  4, -4, -6},
        //    { -2, -7,  5,  8, -2},
        //    {  2, -9,  5, -1,  6},
        //    {  1, -1,  5,  8,  4}
        //};
        //public static double[,] Lab5Matrix = { { 1, 3, 1 }, { 1, 1, 4 }, { 4, 3, 1 } };
    }
}
