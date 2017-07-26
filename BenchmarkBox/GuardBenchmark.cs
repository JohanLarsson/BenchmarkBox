namespace BenchmarkBox
{
    using System;
    using System.Linq.Expressions;
    using BenchmarkDotNet.Attributes;

    public class GuardBenchmark
    {
        private static readonly string Meh = "meh";

        [Benchmark(Baseline = true)]
        public string Vanilla()
        {
            return Meh ?? throw new ArgumentNullException(nameof(Meh));
        }

        [Benchmark]
        public string Expression()
        {
            return NotNull(() => Meh);
        }

        public static T NotNull<T>(Expression<Func<T>> parameterExpression)
            where T : class
        {
            var value = parameterExpression.Compile()();
            if (null == value)
            {
                string name = GetParameterName(parameterExpression);
                throw new ArgumentNullException(name);
            }

            return value;
        }

        private static string GetParameterName<T>(Expression<Func<T>> parameterExpression)
        {
            dynamic body = parameterExpression.Body;
            return body.Member.Name;
        }
    }
}
