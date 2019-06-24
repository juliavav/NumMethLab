using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumMethLab3.Solutions;
using static NumMethLab3.Constants;

namespace NumMethLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //lab1();
            //lab2();
            lab5();
            Console.ReadLine();
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
            //var spline = new SplineInterpolation();
        }

        static void lab2()
        {
            var spline = new SplineInterpolation(Fi2, Xi2);
            spline.GetAnswer(X2);
        }
        static void lab3()
        {
            var minSquare = new MinSquareMethod(Fi3,Xi3);
            minSquare.GetAnswer(2);
            minSquare.GetAnswer(3);
        }

        static void lab4()
        {
            var derivative = new Derivative(Fi4,Xi4);
            Console.WriteLine(derivative.First(X4));
            Console.WriteLine(derivative.Second(X4));
        }

        static void lab5()
        {
            var integral = new Integration(Functions.f5, X51,X52, H1,H2);
            integral.RoungeRomberg();
            Console.WriteLine("H={0}",H1);
            Console.WriteLine("Rectangle={0}",integral.Rectangle(H1));
            Console.WriteLine("Trapeze={0}", integral.Trapeze(H1));
            Console.WriteLine("Simpson={0}", integral.Simpson(H1));

            Console.WriteLine("H={0}", H2);
            Console.WriteLine("Rectangle={0}", integral.Rectangle(H2));
            Console.WriteLine("Trapeze={0}", integral.Trapeze(H2));
            Console.WriteLine("Simpson={0}", integral.Simpson(H2));
        }
    }
}
