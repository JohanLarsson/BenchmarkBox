namespace BenchmarkBox
{
    using System;
    using System.Reflection;
    using BenchmarkDotNet.Attributes;

    public class SetPropertyBenchmarks
    {
        private static readonly PropertyInfo cachedPropertyInfo = typeof(SetPropertyBenchmarks).GetProperty(nameof(Value));
        private static readonly Action<object, object> setAction = CreateSetDelegate(cachedPropertyInfo);

        public string Value { get; set; }

        [Benchmark(Baseline = true)]
        public void Direct()
        {
            Value = "";
        }

        //[Benchmark]
        //public void PropertyInfo()
        //{
        //    var propertyInfo = this.GetType().GetProperty(nameof(Value));
        //    propertyInfo.SetValue(this, "");
        //}

        //[Benchmark]
        //public void CachedPropertyInfo()
        //{
        //    cachedPropertyInfo.SetValue(this, "");
        //}

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
        //    var action = CreateSetDelegate(cachedPropertyInfo);
        //    action.DynamicInvoke(this, "");
        //}

        [Benchmark]
        public void CachedHomegrownDelegate()
        {
            setAction(this, "");
        }

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

        private static Action<SetPropertyBenchmarks, string> CreateSetAction(PropertyInfo propertyInfo)
        {
            return (Action<SetPropertyBenchmarks, string>)Delegate.CreateDelegate(typeof(Action<SetPropertyBenchmarks, string>), propertyInfo.SetMethod);
        }

        private static Action<object, object> CreateSetDelegate(PropertyInfo propertyInfo)
        {
            var type = typeof(Action<,>).MakeGenericType(propertyInfo.DeclaringType, propertyInfo.PropertyType);
            return (Action<object, object>)Delegate.CreateDelegate(type, propertyInfo.SetMethod);
        }
    }
}