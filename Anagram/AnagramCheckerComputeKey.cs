namespace Anagram;

public class AnagramCheckerComputeKey(IWordKeyGenerator wordKeyGenerator) : IAnagramChecker
{
    public IEnumerable<string> GroupAnagrams(IEnumerable<string> words)
    {
        var anagramGroups = new Dictionary<string, List<string>>();

        foreach (var word in words)
        {
            var wordKey = wordKeyGenerator.ComputeKey(word);

            if (anagramGroups.TryGetValue(wordKey, out var anagrams))
            {
                anagrams.Add(word);
            }
            else
            {
                anagramGroups.Add(wordKey, [word]);
            }
        }
        
        var twoWordAnagrams = anagramGroups.Values.Where(x => x.Count > 1);

        return twoWordAnagrams.Select(x => string.Join(" ", x));
    }
}