namespace BenchmarkBox
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using BenchmarkDotNet.Attributes;

    public class ExpressionBenchmarks
    {
        public string Text { get; set; }

        [Benchmark(Baseline = true)]
        public int Func()
        {
            return Func<ExpressionBenchmarks, int>(x => x.Text.Length);
        }

        [Benchmark()]
        public int Expression()
        {
            return Expression<ExpressionBenchmarks, int>(x => x.Text.Length);
        }

        [Benchmark()]
        public int CompileExpression()
        {
            return CompileExpression<ExpressionBenchmarks, int>(x => x.Text.Length);
        }

        [Benchmark()]
        public int ParseExpression()
        {
            return ParseExpression<ExpressionBenchmarks, int>(x => x.Text.Length);
        }

        private static int Func<TSource, TValue>(Func<TSource, TValue> func)
        {
            return func.GetHashCode();
        }

        private static int Expression<TSource, TValue>(Expression<Func<TSource, TValue>> func)
        {
            return func.GetHashCode();
        }

        private static int CompileExpression<TSource, TValue>(Expression<Func<TSource, TValue>> func)
        {
            return func.Compile().GetHashCode();
        }

        private static int ParseExpression<TSource, TValue>(Expression<Func<TSource, TValue>> expr)
        {
            MemberExpression me;
            switch (expr.Body.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    me = ((UnaryExpression)expr.Body).Operand as MemberExpression;
                    break;
                default:
                    me = expr.Body as MemberExpression;
                    break;
            }

            var hash = 0;
            while (me != null)
            {
                hash += ((PropertyInfo)me.Member).Name.Length;
                me = me.Expression as MemberExpression;
            }

            return hash;
        }
    }
}
