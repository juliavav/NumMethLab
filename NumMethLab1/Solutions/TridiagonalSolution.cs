using System.Collections.Generic;
using System.Linq;
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
            var p = new List<double>();
            var q = new List<double>();
            var n = d.Count;

            double p0 = -c[0] / b[0];
            double q0 = d[0] / b[0];

            p.Add(p0);
            q.Add(q0);

            for (int i = 1; i < n; ++i)
            {
                p0 = -c[i] / (b[i] + a[i] * p[i - 1]);
                q0 = (d[i] - a[i] * q[i - 1]) / (b[i] + a[i] * p[i - 1]);
                p.Add(p0);
                q.Add(q0);
            }

            var x = Enumerable.Repeat(0.0,n).ToList();
            double xN = q[n - 1];
            x[n - 1] = q[n - 1];
            for (int i = n - 2; i > -1; --i)
            {
                x[i] = p[i]*x[i+1]+q[i];
                
            }

            return x;
        }
    }
}

