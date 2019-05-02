using System;
using NumMethLab2.Solutions;
using static NumMethLab2.Solutions.FunctionMethods;

namespace NumMethLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Eps ={Constants.Eps}");
            Lab1();
            Constants.Eps = 0.001;
            Console.WriteLine($"Eps ={Constants.Eps}");
            Lab1();
            Constants.Eps = 0.0001;
            Console.WriteLine($"Eps ={Constants.Eps}");
            Lab1();
            Constants.Eps = 0.00001;
            Console.WriteLine($"Eps ={Constants.Eps}");
            Lab1();
            Console.ReadLine();
        }

        private static void Lab1()
        {
            var newton = new NewtonMethod(F, Df, Constants.A, Constants.B);
            Console.WriteLine(newton.GetAnswer());

            var simple = new SimpleIterations(F,Df,Phi,Dphi,Constants.A,Constants.B);
            Console.WriteLine(simple.GetAnswer());
        }
    }
}
