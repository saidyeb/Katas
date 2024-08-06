using Microsoft.Extensions.DependencyInjection;

namespace Anagram.UnitTests;

[TestFixture]
public class AnagramCheckerComputeKeyTests
{
    private AnagramCheckerComputeKey _anagramChecker;

    [SetUp]
    public void Setup()
    {
        _anagramChecker = ServiceProviderHelper.Provider.GetRequiredService<AnagramCheckerComputeKey>();
    }
    
    [Test]
    public void GroupAnagramsMustExcludeSingleAnagrams()
    {
        string[] words = ["a"];

        var actualAnagrams = _anagramChecker.GroupAnagrams(words).ToList();

        actualAnagrams.Should().BeEmpty();
    }
    
    [Test]
    public void GroupAnagramsMustGroupDistinctAnagrams()
    {
        string[] anagrams1 = ["dad", "add"];
        string[] anagrams2 = ["ok", "ko"];
        string[] words = [..anagrams1, ..anagrams2];

        var actualAnagrams = _anagramChecker.GroupAnagrams(words).ToList();

        actualAnagrams.Should().NotBeEmpty();
        actualAnagrams.Should().ContainEquivalentOf(string.Join(" ", anagrams1));
        actualAnagrams.Should().ContainEquivalentOf(string.Join(" ", anagrams2));
    }
    
    [Test]
    public void GroupAnagramsMustDifferentiateSensitiveCaseAnagrams()
    {
        string[] anagramLowerCases = ["dad", "add"];
        string[] anagramUpperCases = ["DAD", "ADD"];
        string[] words = [..anagramLowerCases, ..anagramUpperCases];

        var actualAnagrams = _anagramChecker.GroupAnagrams(words).ToList();

        actualAnagrams.Should().NotBeEmpty();
        actualAnagrams.Should().ContainEquivalentOf(string.Join(" ", anagramLowerCases));
        actualAnagrams.Should().ContainEquivalentOf(string.Join(" ", anagramUpperCases));
        actualAnagrams.Should().NotContainEquivalentOf(string.Join(" ", words));
    }
    
    [Test]
    public void GroupAnagramsMustDifferentiateAnagramWithSingleQuotationAndAnagramWithOnlyAlphabets()
    {
        string[] anagramWithOnlyAlphabets = ["dad", "add"];
        string[] anagramWithSingleQuotations = ["dad's", "add's"];
        string[] words = [..anagramWithOnlyAlphabets, ..anagramWithSingleQuotations];

        var actualAnagrams = _anagramChecker.GroupAnagrams(words).ToList();

        actualAnagrams.Should().NotBeEmpty();
        actualAnagrams.Should().ContainEquivalentOf(string.Join(" ", anagramWithOnlyAlphabets));
        actualAnagrams.Should().ContainEquivalentOf(string.Join(" ", anagramWithSingleQuotations));
        actualAnagrams.Should().NotContainEquivalentOf(string.Join(" ", words));
    }
    
    [Test]
    public void GroupAnagramsMustGroupAllAnagramsWithSingleQuotation()
    {
        string[] words = [
            "ABC'S",
            "CAB'S",
            "SCAB'",
            "BACS'",
            "CABS'",
            "A'CBS",
            "S'CAB",
            "'BACS",
            "'SCAB",
            "B'SAC",
            "C'SAB"
        ];

        var actualAnagrams = _anagramChecker.GroupAnagrams(words).ToList();
        
        actualAnagrams.Should().NotBeEmpty();
        actualAnagrams.Should().ContainEquivalentOf(string.Join(" ", words));
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