namespace BenchmarkBox
{
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using BenchmarkDotNet.Attributes;

    public class TaskBenchmarks
    {
        [Benchmark(Baseline = true)]
        public ConfiguredTaskAwaitable<int> TaskRunConfigureAwaitFalse() => Task.Run(() => 1).ConfigureAwait(false);

        [Benchmark]
        public ConfiguredTaskAwaitable<int> TaskRunConfigureAwaitTrue() => Task.Run(() => 1).ConfigureAwait(true);
    }
}