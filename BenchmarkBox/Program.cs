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
            //BenchmarkRunner.Run<EqualsBenchmarks>();
            //BenchmarkRunner.Run<SetPropertyBenchmarks>();
            //BenchmarkRunner.Run<SetFieldBenchmarks>();
            //BenchmarkRunner.Run<RaisePropertyChangedBenchmarks>();
            //BenchmarkRunner.Run<AllocationBenchmarks>();

            //BenchmarkRunner.Run<EmitBenchmarks>();
            //BenchmarkRunner.Run<DictionaryLookup>();
            //BenchmarkRunner.Run<ThreadLocalBenchmarks>();
            BenchmarkRunner.Run<RotateVector>();
        }
    }
}
