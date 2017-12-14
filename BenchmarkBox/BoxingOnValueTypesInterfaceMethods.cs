namespace BenchmarkBox
{
    using System;
    using System.Collections.Generic;
    using BenchmarkDotNet.Attributes;

    // https://www.youtube.com/watch?v=fI1XGVIQjkA
    public class BoxingOnValueTypesInterfaceMethods
    {
        private enum BarEnum
        {
            A,
            B
        }


        struct Foo1 : IEquatable<Foo1>
        {
            public BarEnum Bar { get; }
            public Foo1(BarEnum en)
            {
                Bar = en;
            }

            public bool Equals(Foo1 foo) => this.Bar.Equals(foo.Bar);
            public override int GetHashCode() => Bar.GetHashCode();
        }

        struct Foo2 : IEquatable<Foo2>
        {
            private static readonly EqualityComparer<BarEnum> ec = EqualityComparer<BarEnum>.Default;

            public BarEnum Bar { get; }
            public Foo2(BarEnum en)
            {
                Bar = en;
            }

            public bool Equals(Foo2 foo) => ec.Equals(this.Bar, foo.Bar);
            public override int GetHashCode() => ec.GetHashCode(this.Bar);
        }

        [Benchmark]
        public int GetHashCodeMethod()
        {
            var f = new Foo1();
            return f.GetHashCode();
        }

        [Benchmark]
        public int GetHashCodeComparer()
        {
            var f = new Foo2();
            return f.GetHashCode();
        }

        [Benchmark]
        public bool EqualsMethod()
        {
            var f1 = new Foo1(BarEnum.A);
            var f2 = new Foo1(BarEnum.B);
            return f1.Equals(f2);
        }

        [Benchmark]
        public bool EqualsComparer()
        {
            var f1 = new Foo2(BarEnum.A);
            var f2 = new Foo2(BarEnum.B);
            return f1.Equals(f2);
        }
    }
}