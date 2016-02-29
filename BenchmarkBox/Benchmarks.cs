using System.Reflection;

namespace BenchmarkBox
{
    using System;
    using BenchmarkDotNet.Attributes;

    public class BenchmarkReflection
    {
        private static readonly PropertyInfo cachedPropertyInfo = typeof(BenchmarkReflection).GetProperty(nameof(Value));

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
            cachedPropertyInfo.SetValue(this, "");
        }

        //[Benchmark]
        //public void Dynamic()
        //{
        //    var self = (dynamic)this;
        //    self.Value = "";
        //}

        //[Benchmark]
        //public void Action()
        //{
        //    Action<string> action = x => this.Value = x;
        //    action("");
        //}

        //[Benchmark]
        //public void HomegrownDelegate()
        //{
        //    var methodInfo = GetType().GetProperty(nameof(Value)).SetMethod;
        //    var action = (Action<Benchmarks, string>)Delegate.CreateDelegate(typeof(Action<Benchmarks, string>), methodInfo);
        //    action(this, "");
        //}

        //[Benchmark]
        //public void HomegrownExpressionAction()
        //{
        //    var propertyInfo = GetType().GetProperty(nameof(Value));
        //    var parameter = Expression.Parameter(typeof(string), "x");
        //    var memberExpression = Expression.MakeMemberAccess(Expression.Constant(this), propertyInfo);
        //    var action = Expression.Lambda<Action<string>>(
        //        Expression.Assign(memberExpression, parameter),
        //        parameter).Compile();
        //    action("");
        //}
    }
}