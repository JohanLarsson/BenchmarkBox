namespace BenchmarkBox
{
    using System;
    using System.Reflection;
    using BenchmarkDotNet.Attributes;

    public class SetPropertyBenchmarks
    {
        private static readonly PropertyInfo ValuePropertyInfo = typeof(SetPropertyBenchmarks).GetProperty(nameof(Value));
        private static readonly ISetter Setter = ValuePropertyInfo.CreateSetter();
        private static readonly Action<SetPropertyBenchmarks, string> SetterDelegate = ValuePropertyInfo.CreateSetterDelegate<SetPropertyBenchmarks, string>();

        public string Value { get; set; }

        [Benchmark(Baseline = true)]
        public void Direct()
        {
            Value = "";
        }

        [Benchmark]
        public void PropertyInfo()
        {
            var propertyInfo = this.GetType().GetProperty(nameof(Value));
            propertyInfo.SetValue(this, "");
        }

        [Benchmark]
        public void CachedPropertyInfo()
        {
            ValuePropertyInfo.SetValue(this, "");
        }

        [Benchmark]
        public void Dynamic()
        {
            var self = (dynamic)this;
            self.Value = "";
        }

        [Benchmark]
        public void Action()
        {
            Action<string> action = x => this.Value = x;
            action("");
        }

        [Benchmark]
        public void DynamicInvoke()
        {
            var action = Delegate.CreateDelegate(typeof(Action<SetPropertyBenchmarks, string>), ValuePropertyInfo.SetMethod);
            action.DynamicInvoke(this, "hej");
        }

        [Benchmark]
        public void CachedDelegate()
        {
            SetterDelegate.Invoke(this, "");
        }

        [Benchmark]
        public void CreateAndInvokeDelegate()
        {
            var setterDelegate = ValuePropertyInfo.CreateSetterDelegate<SetPropertyBenchmarks, string>();
            setterDelegate.Invoke(this, "");
        }

        [Benchmark]
        public void CachedSetter()
        {
            Setter.SetValue(this, "");
        }

        [Benchmark]
        public void CreateAndInvokeSetter()
        {
            var setter = ValuePropertyInfo.CreateSetter();
            setter.SetValue(this, "");
        }
    }
}