namespace BenchmarkBox
{
    using System;
    using BenchmarkDotNet.Attributes;

    public class UnitVectorBenchmarks
    {
        [Benchmark(Baseline = true)]
        public double CreateUnitVectorReturnX()
        {
            return new UnitVector(1, 2).X;
        }

        [Benchmark]
        public double CreateCheckedUnitVectorReturnX()
        {
            return new CheckedUnitVector(1, 2).X;
        }

        [Benchmark]
        public double CreateCheckedUnitVectorNullableReturnX()
        {
            return new CheckedUnitVectorNullable(1, 2).X;
        }

        [Benchmark]
        public double Return1()
        {
            return 1;
        }

        public struct UnitVector
        {
            public readonly double X;
            public readonly double Y;

            public UnitVector(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        public struct CheckedUnitVector
        {
            private readonly double x;
            private readonly double y;

            public CheckedUnitVector(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public double X
            {
                get
                {
                    ThrowIfZero();
                    return this.x;
                }
            }

            public double Y
            {
                get
                {
                    ThrowIfZero();
                    return this.y;
                }
            }

            private void ThrowIfZero()
            {
                if (this.x == 0 && this.y == 0)
                {
                    throw new InvalidOperationException("Unitvector has zero length.");
                }
            }
        }

        public struct CheckedUnitVectorNullable
        {
            private readonly double? x;
            private readonly double? y;

            public CheckedUnitVectorNullable(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public double X => this.x.Value;

            public double Y => this.y.Value;
        }
    }
}
