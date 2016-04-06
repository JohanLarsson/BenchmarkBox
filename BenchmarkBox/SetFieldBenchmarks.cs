namespace BenchmarkBox
{
    using System;
    using System.Reflection;

    using BenchmarkDotNet.Attributes;

    public class SetFieldBenchmarks
    {
        private static readonly FieldInfo ValueFieldInfo = typeof(SetFieldBenchmarks).GetField(nameof(Value));
        //private static readonly ISetter Setter = ValueFieldInfo.CreateSetter();
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
        public void CreateAndInvokeDelegate()
        {
            var setterDelegate = ValueFieldInfo.CreateSetterDelegate<SetFieldBenchmarks, string>();
            setterDelegate.Invoke(this, "");
        }
    }
}
