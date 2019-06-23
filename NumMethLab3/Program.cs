using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumMethLab3.Solutions;

namespace NumMethLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            lab1();
        }

        static void lab1()
        {
            var lagrange = new LagrangeInterpolation(Functions.f1, Constants.Xi);
            var newton = new NewtonInterpolation(Functions.f1, Constants.Xi);
            Console.WriteLine($"Ln({Constants.X}) = {lagrange.GetResult(Constants.X)}");
            Console.WriteLine();
            Console.WriteLine($"Pn({Constants.X}) = {newton.GetResult(Constants.X)}");
            Console.WriteLine();
            Console.WriteLine($"ln({Constants.X}) = {Math.Log(Constants.X)}");
            Console.ReadLine();
            var spline = new SplineInterpolation();
        }
    }
}
