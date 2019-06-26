using System.Collections.Generic;
using System.Linq;
using NumMethLab1.Vector;
using static NumMethLab1.MatrixConstants;

namespace NumMethLab1.Solutions
{
    public class TridiagonalSolution
    {
        private List<double> a;
        private List<double> b;
        private List<double> c;
        private List<double> d;

        public TridiagonalSolution(List<double> a, List<double> b, List<double> c, List<double> d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public List<double> GetAnswer()
        {
            var n = d.Count;
            var p = Enumerable.Repeat(0.0, n).ToList();
            var q = Enumerable.Repeat(0.0, n).ToList();

            p[0] = -c[0] / b[0];
            q[0] = d[0] / b[0];

            for (int i = 1; i < n; ++i)
            {
                p[i] = -c[i] / (a[i] * p[i - 1] + b[i]);
                q[i] = (d[i] - a[i] * q[i - 1]) / (a[i] * p[i - 1] + b[i]);
            }

            var x = Enumerable.Repeat(0.0,n).ToList();
            x[n - 1] = q[n - 1];
            for (int i = n - 1; i >0; --i)
            {
                x[i-1] = p[i-1]*x[i]+q[i-1];
                
            }
            

            return x;
        }
    }
}

