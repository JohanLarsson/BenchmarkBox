using System;
using System.Reflection;

namespace BenchmarkBox
{
    using System.Reflection.Emit;

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
            return (Action<TSource, TValue>)Delegate.CreateDelegate(typeof(Action<TSource, TValue>), property.SetMethod);
        }

        // http://stackoverflow.com/a/16222886/1069200
        internal static Action<TSource, TValue> CreateSetterDelegate<TSource, TValue>(this FieldInfo field)
        {
            string methodName = $"{field.ReflectedType.FullName}.set_{field.Name}";
            var setterMethod = new DynamicMethod(methodName, null, new[] { typeof(TSource), typeof(TValue) }, true);
            var ilGenerator = setterMethod.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Stfld, field);
            ilGenerator.Emit(OpCodes.Ret);
            return (Action<TSource, TValue>)setterMethod.CreateDelegate(typeof(Action<TSource, TValue>));
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