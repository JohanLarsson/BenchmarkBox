using System;
using System.Reflection;

namespace BenchmarkBox
{
    internal static class MemberDelegates
    {
        internal static ISetter CreateSetter(this PropertyInfo propertyInfo)
        {
            var setter = typeof(Setter<,>).MakeGenericType(propertyInfo.DeclaringType, propertyInfo.PropertyType);
            var constructorInfo = setter.GetConstructor(new Type[] { typeof(PropertyInfo) });
            return (ISetter)constructorInfo.Invoke(new object[] { propertyInfo });
        }

        internal static Action<TSource, TValue> CreateSetterDelegate<TSource, TValue>(this PropertyInfo property)
        {
            return (Action<TSource, TValue>) Delegate.CreateDelegate(typeof (Action<TSource, TValue>), property.SetMethod);
        } 

        private class Setter<TSource, TValue> : ISetter
        {
            private readonly Action<TSource, TValue> setter;

            public Setter(PropertyInfo propertyInfo)
            {
                this.setter = (Action<TSource, TValue>)Delegate.CreateDelegate(typeof(Action<TSource, TValue>), propertyInfo.SetMethod);
            }

            public void SetValue(object source, object value)
            {
                this.SetValue((TSource)source, (TValue)value);
            }

            private void SetValue(TSource source, TValue value)
            {
                this.setter(source, value);
            }
        }
    }
}