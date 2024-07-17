using BenchmarkDotNet.Running;
using Benchmarks.String;

internal class Program
{
    private static void Main(string[] args)
    {
        _ = BenchmarkRunner.Run(typeof(StringConcatenation));

        Console.WriteLine("Hello, World!");
    }
}