namespace BenchmarkBox
{
using System;
using System.Windows;
using BenchmarkDotNet.Attributes;

public class DependencyPropertyBoxing
{
    private Foo foo;

    [STAThread]
    [GlobalSetup]
    public void Setup()
    {
        this.foo = new Foo();
    }

    [STAThread]
    [Benchmark(Baseline = true)]
    public bool Vanilla()
    {
        return this.foo.Vanilla = !this.foo.Vanilla;
    }

    [STAThread]
    [Benchmark]
    public bool Boxing()
    {
        return this.foo.Boxing = !this.foo.Boxing;
    }

    [STAThread]
    [Benchmark]
    public bool Ternary()
    {
        return this.foo.Ternary = !this.foo.Ternary;
    }

    internal static class BooleanBoxes
    {
        internal static readonly object True = true;
        internal static readonly object False = false;

        internal static object Box(bool value)
        {
            return value ? True : False;
        }
    }

    public class Foo : DependencyObject
    {
        public static readonly DependencyProperty VanillaProperty = DependencyProperty.Register(
            "Vanilla",
            typeof(bool),
            typeof(Foo),
            new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty BoxingProperty = DependencyProperty.Register(
            "Boxing",
            typeof(bool),
            typeof(Foo),
            new PropertyMetadata(BooleanBoxes.False));

        public static readonly DependencyProperty TernaryProperty = DependencyProperty.Register(
            "Ternary", typeof(bool), typeof(Foo), new PropertyMetadata(default(bool)));

        public bool Ternary
        {
            get { return (bool)this.GetValue(TernaryProperty); }
            set { this.SetValue(TernaryProperty, value ? BooleanBoxes.True : BooleanBoxes.False); }
        }

        public bool Vanilla
        {
            get { return (bool)this.GetValue(VanillaProperty); }
            set { this.SetValue(VanillaProperty, value); }
        }

        public bool Boxing
        {
            get { return (bool)this.GetValue(BoxingProperty); }
            set { this.SetValue(BoxingProperty, BooleanBoxes.Box(value)); }
        }
    }
}
}
