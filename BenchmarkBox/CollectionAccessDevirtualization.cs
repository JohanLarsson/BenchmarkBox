using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace BenchmarkBox
{
    sealed class ConcreteList<T> : List<T>
    {
        /// <inheritdoc />
        public ConcreteList()
        {
        }

        /// <inheritdoc />
        public ConcreteList(int capacity) : base(capacity)
        {
        }

        /// <inheritdoc />
        public ConcreteList(IEnumerable<T> collection) : base(collection)
        {
        }
    }

    public class CollectionAccessDevirtualization
    {
        private static readonly IList<int> iface = new ConcreteList<int>(Enumerable.Range(0, 1000000));
        private static readonly List<int> concrete = new ConcreteList<int>(Enumerable.Range(0, 1000000));
        private static readonly ConcreteList<int> sealedConcrete = new ConcreteList<int>(Enumerable.Range(0, 1000000));
        private static readonly List<int> indices = Shuffled(new Random(42), Enumerable.Range(0, 1000000));
        private static int value;

        private static List<TElement> Shuffled<TElement>(Random rand, IEnumerable<TElement> collection)
        {
            var list = collection.ToList();
            int n = list.Count;
            while(n > 1)
            {
                n--;
                var k = rand.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

        [Benchmark]
        public int Interface()
        {
            value = 0;
            foreach(var i in indices)
            {
                value += iface[i];
            }

            return value;
        }

        [Benchmark]
        public int Concrete()
        {
            value = 0;
            foreach(var i in indices)
            {
                value += concrete[i];
            }

            return value;
        }

        [Benchmark(Baseline = true)]
        public int SealedConcrete()
        {
            value = 0;
            foreach(var i in indices)
            {
                value += sealedConcrete[i];
            }

            return value;
        }
    }
}
