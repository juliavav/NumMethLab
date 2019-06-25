using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumMethLab4.Solutions;
using  static  NumMethLab4.Functions;

namespace NumMethLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            lab1();
            Console.ReadLine();
        }

        public static void lab1()
        {
            var cauchy = new CauchyProblem(f1, y01, yD01, a1, b1, h1, solution1);
            cauchy.RungeRomberg();
        }
    }
}
