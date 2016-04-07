namespace BenchmarkBox
{
    using BenchmarkDotNet.Running;

    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main()
        {
            //var types = new[]
            //                {
            //                    typeof(SetFieldBenchmarks),
            //                    typeof(SetPropertyBenchmarks),
            //                    typeof(EqualsBenchmarks),
            //                    typeof(AllocationBenchmarks),
            //                    typeof(RaisePropertyChangedBenchmarks)
            //                };
            //var switcher = new BenchmarkSwitcher( types);
            //switcher.Run();
            //var summary = BenchmarkRunner.Run<EqualsBenchmarks>();
            //var summary = BenchmarkRunner.Run<SetPropertyBenchmarks>();
            //var summary = BenchmarkRunner.Run<SetFieldBenchmarks>();
            //var summary = BenchmarkRunner.Run<RaisePropertyChangedBenchmarks>();
            //var summary = BenchmarkRunner.Run<AllocationBenchmarks>();

            //var summary = BenchmarkRunner.Run<EmitBenchmarks>();
            var summary = BenchmarkRunner.Run<DictionaryLookup>();
        }
    }
}
