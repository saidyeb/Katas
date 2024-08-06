using Microsoft.Extensions.DependencyInjection;

namespace Anagram.UnitTests;

public class AnagramCheckerOrderByTests
{
    private AnagramCheckerOrderBy _anagramChecker;

    [SetUp]
    public void Setup()
    {
        _anagramChecker = ServiceProviderHelper.Provider.GetRequiredService<AnagramCheckerOrderBy>();
    }
    
    [Test]
    public void GroupAnagramsMustFind20683SetsOfAnagramsOnTotalOf48162Words()
    {
        const int expectedNumberOfAnagrams = 20683;
        var words = File.ReadAllLines("./Resource/wordlist.txt").Where(x => x != string.Empty).ToArray();
       
        var actualAnagrams = _anagramChecker.GroupAnagrams(words).ToList();

        actualAnagrams.Should().NotBeEmpty();
        actualAnagrams.Should().HaveCount(expectedNumberOfAnagrams);
    }
}