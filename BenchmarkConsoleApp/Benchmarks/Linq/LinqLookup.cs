using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Linq
{
    [MemoryDiagnoser]
    [SimpleJob(launchCount: 10, warmupCount: 10, iterationCount: 10, invocationCount: 10)]
    public class LinqLookup
    {
        [Params(10, 100, 1000)]
        public int dictionarySize = 0;

        public IDictionary<int, string> dict = new Dictionary<int, string>();

        [GlobalSetup]
        public void Setup()
        {
            dict = new Dictionary<int, string>();
            for (int i = 0; i < dictionarySize; i++)
            {
                dict.Add(i, i.ToString());
            }
        }

        [Benchmark(Baseline = true)]
        public void ContainsKeysThenLookUpOrDefault()
        {
            _ = dict.ContainsKey(dictionarySize / 2) ? dict[dictionarySize / 2] : null;
        }

        [Benchmark]
        public void TryGetValueOrDefault()
        {
            _ = dict.TryGetValue(dictionarySize / 2, out var val) ? val : null;
        }
    }
}
