namespace BenchmarkBox
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection.Emit;
    using BenchmarkDotNet.Attributes;

    public class AddBenchmarks
    {
        private static readonly Func<int, int, int> CachedEmit = EmitAdder();
        private static readonly Func<int, int, int> CachedExpression = ExpressionAdder();
        private static readonly Func<int, int, int> Cached = (x, y) => x + y;

        [Benchmark]
        public int Func() => Cached(1, 2);

        [Benchmark]
        public int Emit() => CachedEmit(1, 2);

        [Benchmark]
        public int ExpressionCompiled() => CachedExpression(1, 2);


        [Benchmark]
        public int Dynamic() => (dynamic) 1 + (dynamic) 2;

        static Func<int, int, int> EmitAdder()
        {
            var method = new DynamicMethod("op_add", typeof(int), new[] { typeof(int), typeof(int) });
            var gen = method.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ldarg_1);
            gen.Emit(OpCodes.Add);
            gen.Emit(OpCodes.Ret);
            return (Func<int, int, int>)method.CreateDelegate(typeof(Func<int, int, int>));
        }

        static Func<int, int, int> ExpressionAdder()
        {
            var x = Expression.Parameter(typeof(int), "x");
            var y = Expression.Parameter(typeof(int), "y");
            return Expression.Lambda<Func<int, int, int>>(Expression.Add(x, y), x, y)
                                 .Compile();
        }
    }
}
