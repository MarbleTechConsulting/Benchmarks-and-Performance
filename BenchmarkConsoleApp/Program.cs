using BenchmarkDotNet.Running;
using Benchmarks.Linq;
using Benchmarks.String;

internal class Program
{
    private static void Main(string[] args)
    {
        _ = BenchmarkRunner.Run(typeof(StringConcatenation));
        _ = BenchmarkRunner.Run(typeof(LinqLookup));

        Console.WriteLine("Hello, World!");
    }
}