using System.Collections.Generic;
using static NumMethLab1.MatrixConstants;

namespace NumMethLab1.Solutions
{
    class TridiagonalSolution
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


            double p0 = -c[0] / b[0];
            double q0 = d[0] / b[0];

            p.Add(p0);
            q.Add(q0);

            for (int i = 1; i < N; ++i)
            {
                p0 = -c[i] / (b[i] + a[i] * p[i - 1]);
                q0 = (d[i] - a[i] * q[i - 1]) / (b[i] + a[i] * p[i - 1]);
                p.Add(p0);
                q.Add(q0);
            }

            var x = new List<double>();
            double xN = q[N - 1];
            x.Insert(0, xN);
            for (int i = N - 2; i > 0; --i)
            {
                xN = -c[i] * x[0] / (b[i] + a[i] * p[i - 1]) + (d[i] - a[i] * q[i - 1]) / (b[i] + a[i] * p[i - 1]);
                x.Insert(0, xN);
            }

            return x;
        }
    }
}

