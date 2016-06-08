namespace BenchmarkBox
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    using BenchmarkDotNet.Attributes;

    using Newtonsoft.Json;

    public class DeepCopy
    {
        private readonly Stream cachedStream;
        private readonly BinaryFormatter cachedFormatter;
        private readonly Person[] persons;

        public DeepCopy()
        {
            this.cachedStream = new MemoryStream();
            this.cachedFormatter = new BinaryFormatter();
            this.persons = Enumerable.Repeat(new Person(1, "Travis"), 1000).ToArray();
        }

        [Benchmark(Baseline = true)]
        public object CloneCached()
        {
            this.cachedStream.Position = 0;
            var person = new Person(1, "Travis");
            this.cachedFormatter.Serialize(this.cachedStream, person);
            this.cachedStream.Position = 0;
            return (Person)this.cachedFormatter.Deserialize(this.cachedStream);
        }

        [Benchmark]
        public object Clone1000Cached()
        {
            this.cachedStream.Position = 0;
            this.cachedFormatter.Serialize(this.cachedStream, this.persons);
            this.cachedStream.Position = 0;
            return this.cachedFormatter.Deserialize(this.cachedStream);
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
                return formatter.Deserialize(stream);
            }
        }

        [Benchmark]
        public object CloneJson()
        {
            var person = new Person(1, "Travis");
            var serialized = JsonConvert.SerializeObject(person);
            return JsonConvert.DeserializeObject<Person>(serialized);
        }

        [Benchmark]
        public object Clone1000()
        {
            IFormatter formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, this.persons);
                stream.Position = 0;
                return formatter.Deserialize(stream);
            }
        }


        [Benchmark]
        public object Clone1000Json()
        {
            var serialized = JsonConvert.SerializeObject(this.persons);
            return JsonConvert.DeserializeObject<Person[]>(serialized);
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