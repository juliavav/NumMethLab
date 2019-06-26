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

        public static void lab2()
        {
            var boundary = new BoundaryProblem(func2,y02,yD02,alpha,beta,delta,gamma,a2,b2,h2,solution2,p,q,f);
            boundary.RungeRomberg();
        }
    }
}
