using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.String
{
    [MemoryDiagnoser]
    [SimpleJob(launchCount: 10, warmupCount: 10, iterationCount: 10, invocationCount: 10)]
    public class StringConcatenation
    {
        [Benchmark(Baseline = true)]
        public string Concat_OneLine()
        {
           string val = "one" + "two" + "three" + "four" + "five";
           return val;
        }

        [Benchmark]
        public string Concat_MultiLine()
        {
           string val = "one";
           val += "two";
           val += "three";
           val += "four";
           val += "five";
           return val;
        }

        [Benchmark]
        public string Concat_StringBuilder()
        {
           StringBuilder val = new();
           val.Append("one");
           val.Append("two");
           val.Append("three");
           val.Append("four");
           val.Append("five");
           return val.ToString();
        }
    }
}