namespace BenchmarkBox
{
    using BenchmarkDotNet.Attributes;
    using Moq;
    using NSubstitute;

    public class MoqBenchmarks
    {
        [Benchmark(Baseline = true)]
        public object SubstituteForFoo()
        {
            return Substitute.For<IFoo>();
        }

        [Benchmark]
        public object SubstituteForFooValueReturns()
        {
            return Substitute.For<IFoo>().Value.Returns(1);
        }

        [Benchmark]
        public object MockOfIFoo()
        {
            return Mock.Of<IFoo>();
        }

        [Benchmark]
        public object MockOfIFooWithExpression()
        {
            return Mock.Of<IFoo>(x => x.Value == 1);
        }

        public interface IFoo
        {
            int Value { get; }
        }

        private class Foo : IFoo
        {
            public Foo(int value)
            {
                Value = value;
            }

            public int Value { get; }
        }
    }
}