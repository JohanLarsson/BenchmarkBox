namespace BenchmarkBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;
    using BenchmarkDotNet.Attributes;

    public class ExpressionBenchmarks
    {

        private static readonly OpCode[] Codes = { OpCodes.Ldarg_1, OpCodes.Callvirt, OpCodes.Ret };

        private static readonly Type[] GenericTypeArguments = new Type[0];

        public string Text { get; set; }

        [Benchmark(Baseline = true)]
        public int Func()
        {
            return Func<ExpressionBenchmarks, int>(x => x.Text.Length);
        }

        [Benchmark]
        public int ParseFunc()
        {
            Func<ExpressionBenchmarks, int> func = x => x.Text.Length;
            return GetProperties(func).Count;
        }

        [Benchmark]
        public int Expression()
        {
            return Expression<ExpressionBenchmarks, int>(x => x.Text.Length);
        }

        [Benchmark]
        public int CompileExpression()
        {
            return CompileExpression<ExpressionBenchmarks, int>(x => x.Text.Length);
        }

        [Benchmark]
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

        public static IReadOnlyList<PropertyInfo> GetProperties<TSource, TValue>(Func<TSource, TValue> path)
        {
            var il = path.Method.GetMethodBody().GetILAsByteArray();
            var offset = 0;
            var opCode = GetOpCode(il, ref offset);
            if (opCode != OpCodes.Ldarg_1)
            {
                throw new InvalidOperationException();
            }

            var properties = new List<PropertyInfo>();
            while (offset < il.Length)
            {
                opCode = GetOpCode(il, ref offset);
                if (opCode == OpCodes.Ret)
                {
                    if (offset != il.Length)
                    {
                        throw new InvalidOperationException();
                    }

                    return properties;
                }

                if (opCode == OpCodes.Callvirt)
                {
                    var metaDataToken = BitConverter.ToInt32(il, offset);
                    var method =
                        path.Method.Module.ResolveMethod(
                            metaDataToken,
                            GenericTypeArguments,
                            null);

                    properties.Add(method.DeclaringType.GetProperty(method.Name.Substring(4)));
                    offset += 4;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(opCode), opCode, "Illegal op code");
                }
            }

            throw new InvalidOperationException();
        }

        private static OpCode GetOpCode(byte[] il, ref int offset)
        {
            var code = (short)il[offset++];
            if (code == 0xfe)
            {
                code = (short)(il[offset++] | 0xfe00);
            }

            foreach (var opCode in Codes)
            {
                if (code == opCode.Value)
                {
                    return opCode;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(code), code, "not supported code");
        }
    }
}
