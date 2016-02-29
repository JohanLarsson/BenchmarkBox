using BenchmarkDotNet.Running;

namespace BenchmarkBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
