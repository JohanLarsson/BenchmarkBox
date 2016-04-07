namespace BenchmarkBox
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;

    using BenchmarkDotNet.Attributes;

    public class EmitBenchmarks
    {
        public int value;
        private static readonly Type Accessor;

        static EmitBenchmarks()
        {
            var type = typeof(EmitBenchmarks);
            var assemblyName = new AssemblyName("Emit");
            var asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = asmBuilder.DefineDynamicModule("FieldAccessors");
            var typeBuilder = moduleBuilder.DefineType($"{assemblyName.Name}.{type.Name}", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Abstract | TypeAttributes.Sealed);
            var field = type.GetField(nameof(value), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var setMethod = typeBuilder.DefineMethod($"set_{field.Name}", MethodAttributes.Public | MethodAttributes.Static, null, new[] { field.DeclaringType, field.FieldType });
            var ilGenerator = setMethod.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Stfld, field);
            ilGenerator.Emit(OpCodes.Ret);

            var getterMethod = typeBuilder.DefineMethod($"get_{field.Name}", MethodAttributes.Public | MethodAttributes.Static, field.FieldType, new[] { field.DeclaringType });
            ilGenerator = getterMethod.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldfld, field);
            ilGenerator.Emit(OpCodes.Ret);
            Accessor = typeBuilder.CreateType();
        }

        //[Benchmark(Baseline = true)]
        //public MethodInfo GetMethodInfo()
        //{
        //    return typeof(EmitBenchmarks).GetMethod(nameof(this.GetMethodInfo));
        //}

        [Benchmark(Baseline = true)]
        public Func<EmitBenchmarks, object> GetAction()
        {
            return (Func<EmitBenchmarks, object>)typeof(EmitBenchmarks).GetMethod(nameof(this.GetAction)).CreateDelegate(typeof(Func<EmitBenchmarks, object>));
        }

        //[Benchmark]
        //public MethodInfo GetDynamicMethodInfo()
        //{
        //    return Accessor.GetMethod("get_value");
        //}

        [Benchmark]
        public Func<EmitBenchmarks, int> GetEmitAction()
        {
            return (Func<EmitBenchmarks, int>)Accessor.GetMethod("get_value").CreateDelegate(typeof(Func<EmitBenchmarks, int>));
        }
    }
}
