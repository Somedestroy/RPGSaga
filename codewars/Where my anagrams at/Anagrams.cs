public class Anagrams
{
    public List<string> Anagrams(string word, List<string> words)
    {
        List<string> result = new List<string>();
        foreach (var item in words)
        {
        if (string.Concat(item.OrderBy(c => c)) == string.Concat(word.OrderBy(b => b)))
          {
            result.Add(item);
          }
        }
    return result;
    }
}