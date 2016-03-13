namespace BenchmarkBox
{
    using BenchmarkDotNet.Running;

    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SetPropertyBenchmarks>();
            //var summary = BenchmarkRunner.Run<RaisePropertyChangedBenchmarks>();
            //var summary = BenchmarkRunner.Run<AllocationBenchmarks>();
        }
    }
}
