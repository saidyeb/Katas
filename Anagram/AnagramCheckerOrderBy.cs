namespace Anagram;

public class AnagramCheckerOrderBy : IAnagramChecker
{
    public IEnumerable<string> GroupAnagrams(IEnumerable<string> words)
    {
        var anagrams = new Dictionary<string, string>();

        foreach (var word in words)
        {
            var wordOrdered = new string(word.OrderBy(c => c).ToArray());

            if (!anagrams.TryAdd(wordOrdered, word))
            {
                anagrams[wordOrdered] += " " + word;
            }
        }

        return anagrams.Values.Where(x => x.Contains(" "));
    }
}