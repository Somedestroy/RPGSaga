using System.Linq;
public class DuplicateEncoder
{
    public static string DuplicateEncode(string word)
    {
        return new string(word.ToLower().Select(b => word.ToLower().Count(c => b == c) == 1? '(' : ')').ToArray());
    }
}