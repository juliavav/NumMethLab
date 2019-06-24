using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethLab3.Helpers
{
    public static class IntervalHelpers
    {
        public static int FindI(double[] x, double X)
        {
            int i;
            for (i = 0; i < x.Length; i++)
            {
                if (X < x[i + 1] && X >= x[i])
                {
                    break;
                }
            }

            return i;
        }
    }
}
