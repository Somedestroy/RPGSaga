public class Anagrams
{
    public List<string> Anagrams(string word, List<string> words)
    {
        List<string> result = new List<string>();
        string orderedWord = string.Concat(word.OrderBy(b => b));
        foreach (var item in words)
        {
        if (orderedWord == string.Concat(item.OrderBy(c => c)))
          {
            result.Add(item);
          }
        }
    return result;
    }
}