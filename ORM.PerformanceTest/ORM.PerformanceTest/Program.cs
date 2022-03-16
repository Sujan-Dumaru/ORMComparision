using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using ORM.PerformanceTest.Benchmarks;

namespace ORM.PerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ManualConfig.Create(DefaultConfig.Instance)
                .WithOptions(ConfigOptions.JoinSummary)
                .WithOptions(ConfigOptions.DisableLogFile);

            var summary = BenchmarkRunner.Run(new[]
                {
                    BenchmarkConverter.TypeToBenchmarks(typeof(BenchmarkDapper), config),
                    //BenchmarkConverter.TypeToBenchmarks(typeof(BenchmarkDapperSimpleCrud), config),
                    BenchmarkConverter.TypeToBenchmarks(typeof(BenchmarkNhibernate), config),
                });
        }
    }
}
