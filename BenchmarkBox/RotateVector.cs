namespace BenchmarkBox
{
    using System;
    using System.Windows;

    using BenchmarkDotNet.Attributes;

    public class RotateVector
    {
        [Benchmark]
        public double[] ArrayOfDoubles()
        {
            var v = new[] { 1.0, 2 };
            return RotateRadians(v, 1);
        }

        [Benchmark(Baseline = true)]
        public Vector Vector()
        {
            var v = new Vector(1, 2);
            return RotateRadians(v, 1);
        }

        private static Vector RotateRadians(Vector v, double radians)
        {
            var ca = Math.Cos(radians);
            var sa = Math.Sin(radians);
            return new Vector(ca * v.X - sa * v.Y, sa * v.X + ca * v.Y);
        }

        private static double[] RotateRadians(double[] v, double radians)
        {
            var ca = Math.Cos(radians);
            var sa = Math.Sin(radians);
            return new[] { ca * v[0] - sa * v[1], sa * v[0] + ca * v[1] };
        }
    }
}
