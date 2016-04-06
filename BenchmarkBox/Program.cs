namespace BenchmarkBox
{
    using BenchmarkDotNet.Running;

    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main()
        {
            //var summary = BenchmarkRunner.Run<EqualsBenchmarks>();
            var summary = BenchmarkRunner.Run<SetPropertyBenchmarks>();
            //var summary = BenchmarkRunner.Run<RaisePropertyChangedBenchmarks>();
            //var summary = BenchmarkRunner.Run<AllocationBenchmarks>();
        }
    }
}
