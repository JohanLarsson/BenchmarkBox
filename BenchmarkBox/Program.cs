namespace BenchmarkBox
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using BenchmarkDotNet.Reports;
    using BenchmarkDotNet.Running;

    public class Program
    {
        private static readonly string ProjectDirectory = Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName);

        public static string BenchmarksDirectory { get; } = Path.Combine(ProjectDirectory, "Benchmarks");

        private static string ArtifactsDirectory { get; } = Path.Combine(ProjectDirectory, "BenchmarkDotNet.Artifacts", "results");

        public static void Main()
        {
            foreach (var summary in RunSingle<DistinctByBenchmarks>())
            {
                CopyResult(summary.Title);
            }
        }

        private static IEnumerable<Summary> RunAll()
        {
            var switcher = new BenchmarkSwitcher(typeof(Program).Assembly);
            var summaries = switcher.Run(new[] { "*" });
            return summaries;
        }

        private static IEnumerable<Summary> RunSingle<T>()
        {
            var summaries = new[] { BenchmarkRunner.Run<T>() };
            return summaries;
        }

        private static void CopyResult(string name)
        {
            Console.WriteLine($"DestinationDirectory: {BenchmarksDirectory}");
            if (Directory.Exists(BenchmarksDirectory))
            {
                var sourceFileName = Path.Combine(ArtifactsDirectory, name + "-report-github.md");
                var destinationFileName = Path.Combine(BenchmarksDirectory, name + ".md");
                Console.WriteLine($"Copy: {sourceFileName} -> {destinationFileName}");
                File.Copy(sourceFileName, destinationFileName, overwrite: true);
            }
        }
    }
}
