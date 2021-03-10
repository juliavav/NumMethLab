using NumMethLab2.Solutions;
using System;
using System.Linq;
using NumMethLab1.Vector;
using static NumMethLab2.Solutions.FunctionMethods;

namespace NumMethLab2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"Eps ={Constants.Eps}");
            Lab1();
            Console.WriteLine();
            Constants.Eps = 0.001;
            Console.WriteLine($"Eps ={Constants.Eps}");
            Lab1();
            Console.WriteLine();
            Constants.Eps = 0.0001;
            Console.WriteLine($"Eps ={Constants.Eps}");
            Lab1();
            Console.WriteLine();
            Constants.Eps = 0.00001;
            Console.WriteLine($"Eps ={Constants.Eps}");
            Lab1();
            Console.ReadLine();
            Lab2();
            Console.ReadLine();
        }

        private static void Lab1()
        {
            var newton = new NewtonMethod(F, Df, Constants.A, Constants.B);
            Console.WriteLine(newton.GetAnswer());

            var simple = new SimpleIterations(F, Phi, Dphi, Constants.A, Constants.B);
            Console.WriteLine(simple.GetAnswer());

            //var simpleV2 = new SimpleIterationsV2(F, Phi, Dphi, Constants.Av2, Constants.Bv2);
            //Console.WriteLine(simpleV2.GetAnswer());
        }

        private static void Lab2()
        {
            var newton = new NewtonMethodSystem(Fi,J,Constants.Ai,Constants.Bi);
            newton.GetAnswer().ToList().Print();

            var simple = new SimpleIterationsSystem(PhiX, DphiX, Constants.Ai, Constants.Bi);
            //Console.WriteLine(simple.GetAnswer());
            simple.GetAnswer().ToList().Print();
        }
    }
}