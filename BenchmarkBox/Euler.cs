namespace BenchmarkBox
{
    using System.Linq;
    using BenchmarkDotNet.Attributes;

    public class Euler
    {
        [Benchmark]
        public static int RangeWhereSum()
        {
            return Enumerable.Range(0, 1000)
                                .Where(it => it % 3 == 0 || it % 5 == 0)
                                .Sum();
        }

        [Benchmark]
        public static int LoopMod()
        {
            var total = 0;

            for (var i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    total += i;
                }
            }

            return total;
        }

        [Benchmark(Baseline = true)]
        public static int ThreeLoops()
        {
            var total = 0;
            var i = 3;
            while (i < 1000)
            {
                total += i;
                i += 3;
            }

            i = 5;
            while (i < 1000)
            {
                total += i;
                i += 15;
            }

            i = 10;
            while (i < 1000)
            {
                total += i;
                i += 15;
            }

            return total;
        }
    }
}
