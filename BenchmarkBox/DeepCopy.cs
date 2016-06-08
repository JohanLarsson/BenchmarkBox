namespace BenchmarkBox
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    using BenchmarkDotNet.Attributes;

    public class DeepCopy
    {
        private readonly Stream cachedStream;
        private readonly BinaryFormatter cachedFormatter;

        public DeepCopy()
        {
            this.cachedStream = new MemoryStream();
            this.cachedFormatter = new BinaryFormatter();
        }

        [Benchmark(Baseline = true)]
        public object CloneCached()
        {
            var person = new Person(1, "Travis");
            this.cachedFormatter.Serialize(this.cachedStream, person);
            this.cachedStream.Position = 0;
            return (Person)this.cachedFormatter.Deserialize(this.cachedStream);
        }

        [Benchmark]
        public object Clone()
        {
            var person = new Person(1, "Travis");
            IFormatter formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, person);
                stream.Position = 0;
                return (Person)formatter.Deserialize(stream);
            }
        }
    }

    [Serializable]
    public class Person
    {
        public Person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}