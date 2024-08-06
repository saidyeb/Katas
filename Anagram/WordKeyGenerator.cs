using System.Text;

namespace Anagram;

public interface IWordKeyGenerator
{
    string ComputeKey(string word);
}

public class WordKeyGenerator : IWordKeyGenerator
{
    private const int NumberOfAlphabets = 26;
    private const char QuotationCharacter = '\'';
    
    public string ComputeKey(string word)
    {
        var alphabetLowerCases = new int[NumberOfAlphabets];
        var alphabetUpperCases = new int[NumberOfAlphabets];
        var singleQuotation = 0;
        var specialCharacter = 0;
        
        foreach (var c in word)
        {
            if (c == QuotationCharacter) singleQuotation++;
            else if (char.IsLetter(c) && char.IsLower(c)) alphabetLowerCases[c - 'a']++;
            else if (char.IsLetter(c) && char.IsUpper(c)) alphabetUpperCases[c - 'A']++;
            else specialCharacter++;
        }

        var builder = new StringBuilder()
            .Append(singleQuotation.ToString())
            .Append(specialCharacter.ToString());
            
        AppendAlphabets(builder, alphabetLowerCases, alphabetUpperCases);
            
        return builder.ToString();
    }

    private static void AppendAlphabets(StringBuilder builder, int[] alphabetLowerCases, int[] alphabetUpperCases)
    {
        for (var i = 0; i < NumberOfAlphabets; i++)
        {
            builder.Append(alphabetLowerCases[i]);
            builder.Append(alphabetUpperCases[i]);
        }
    }
}