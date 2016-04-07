namespace BenchmarkBox
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;

    using BenchmarkDotNet.Attributes;

    public class SetFieldBenchmarks
    {
        private static readonly FieldInfo ValueFieldInfo = typeof(SetFieldBenchmarks).GetField(nameof(Value));
        private static readonly Action<SetFieldBenchmarks, string> Setter = CreateSetter(ValueFieldInfo);
        private static readonly Action<SetFieldBenchmarks, string> SetterDelegate = ValueFieldInfo.CreateSetterDelegate<SetFieldBenchmarks, string>();

        public string Value;

        [Benchmark(Baseline = true)]
        public void Direct()
        {
            this.Value = "";
        }

        [Benchmark]
        public void FieldInfo()
        {
            var fieldInfo = this.GetType().GetField(nameof(Value));
            fieldInfo.SetValue(this, "");
        }

        [Benchmark]
        public void CachedFieldInfo()
        {
            ValueFieldInfo.SetValue(this, "");
        }

        [Benchmark]
        public void CachedDelegate()
        {
            SetterDelegate.Invoke(this, "");
        }

        [Benchmark]
        public void CreateAndInvokeDelegateDynamicMethod()
        {
            var setterDelegate = ValueFieldInfo.CreateSetterDelegate<SetFieldBenchmarks, string>();
            setterDelegate.Invoke(this, "");
        }

        [Benchmark]
        public void CreateAndInvokeExpression()
        {
            var setter = CreateSetter(ValueFieldInfo);
            setter(this, "");
        }

        [Benchmark]
        public void InvokeCachedExpression()
        {
            Setter(this, "");
        }

        private static Action<SetFieldBenchmarks, string> CreateSetter(FieldInfo fieldInfo)
        {
            var source = Expression.Parameter(typeof(SetFieldBenchmarks));
            var fieldExp = Expression.Field(source, fieldInfo);
            var value = Expression.Parameter(typeof(string));
            var assign = Expression.Assign(fieldExp, value);
            var setter = Expression.Lambda<Action<SetFieldBenchmarks, string>>(assign, source, value).Compile();
            return setter;
        }
    }
}
