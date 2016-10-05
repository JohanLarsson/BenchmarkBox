namespace BenchmarkBox
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using BenchmarkDotNet.Attributes;

    public class EnumDescription
    {
        private static readonly Dictionary<Foo, string> Cache = new Dictionary<Foo, string> { { Foo.Bar, "meh" } };

        [Benchmark(Baseline = true)]
        public string DictionaryLookup()
        {
            return Cache[Foo.Bar];
        }

        [Benchmark()]
        public string Reflection()
        {
            string description;
            if (TryGetDescription(Foo.Baz, out description))
            {
                return description;
            }

            return null;
        }

        public static bool TryGetDescription(Enum value, out string description)
        {
            description = value.GetType()
                .GetField(value.ToString())
                ?.GetCustomAttribute<DescriptionAttribute>()
                ?.Description;
            return description != null;
        }

        public enum Foo
        {
            Bar,
            [Description("meh")]
            Baz
        }
    }
}