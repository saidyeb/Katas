namespace Anagram;

public interface IAnagramChecker
{
    IEnumerable<string> GroupAnagrams(IEnumerable<string> words);
}