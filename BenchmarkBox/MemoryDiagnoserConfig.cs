[assembly: BenchmarkDotNet.Attributes.Config(typeof(BenchmarkBox.MemoryDiagnoserConfig))]
namespace BenchmarkBox
{
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;

    public class MemoryDiagnoserConfig : ManualConfig
    {
        public MemoryDiagnoserConfig()
        {
            this.Add(MemoryDiagnoser.Default);
        }
    }
}