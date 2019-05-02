using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using matrix = NumMethLab1.Matrix.Matrix;
using static System.Math;

namespace NumMethLab1.Vector
{
    public class Vector : IEnumerable<double>
    {
        public List<double> Elements { get; set; }
        public int Length => Elements.Count;

        public Vector(int n)
        {
            Elements = Enumerable.Repeat(0.0, n).ToList();
        }

        public Vector(List<double> list)
        {
            Elements = list;
        }

        public Vector(Vector vector)
        {
            Elements = new List<double>();

            foreach (var t in vector)
            {
                Elements.Add(t);
            }
        }

        public double this[int i]
        {
            get => Elements[i];
            set => Elements[i] = value;
        }

        public static double ScalarMultiply(Vector a, Vector b)
        {
            var result = 0.0;
            for (int i = 0; i < a.Length; i++)
            {
                result += a[i] * b[i];
            }

            return result;
        }

        public double RateC()
        {
            return Elements.RateC();
        }

        public double Rate2()
        {
            return Elements.Rate2();
        }
        public matrix Transpose()
        {
            var dim = Elements.Count;
            var tempElements = matrix.ZerosMatrix(dim,1);
            for (int i = 0; i < tempElements.RowCount; i++)
            {
                    tempElements[i, 0] = Elements[i];
            }
            return tempElements;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.Elements.Sum(b.Elements));
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.Elements.Difference(b.Elements));
        }

        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.Elements.Multiply(b));
        }

        public static Vector operator *(Vector a, int b)
        {
            return new Vector(a.Elements.Multiply(b));
        }

        public static Vector IdentityVector(int identityNumber, int size)
        {
            var identityVector = new Vector(size) {[identityNumber] = 1};
            return identityVector;
        }

        public void Print()
        {
            this.Elements.Print();
        }
        IEnumerator<double> IEnumerable<double>.GetEnumerator()
        {
            foreach (var item in Elements)
                yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this.AsEnumerable();
        }
    }
}
