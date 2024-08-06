using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using Perfolizer.Horology;

namespace Anagram.Benchmark;

[ShortRunJob]
[Config(typeof(Config))]
public class AnagramCheckerBenchmark
{
    private readonly IAnagramChecker _anagramChecker = new AnagramCheckerComputeKey(new WordKeyGenerator());
    private readonly IAnagramChecker _anagramCheckerOrderBy = new AnagramCheckerOrderBy();

    private readonly string[] _words = ReadAllWordsFromResourceFile();
    
    [Benchmark]
    public List<string> GroupAnagram() => _anagramChecker.GroupAnagrams(_words).ToList();    
    
    [Benchmark]
    public List<string> GroupAnagramOrderBy() => _anagramCheckerOrderBy.GroupAnagrams(_words).ToList();
    
    private static string[] ReadAllWordsFromResourceFile()
    {
        return File.ReadAllLines("./Resource/wordlist.txt").Where(x => x.Length > 1).ToArray();
    }
    
    private class Config : ManualConfig
    {
        public Config()
        {
            SummaryStyle = SummaryStyle.Default.WithTimeUnit(TimeUnit.Millisecond);
        }
    }
}