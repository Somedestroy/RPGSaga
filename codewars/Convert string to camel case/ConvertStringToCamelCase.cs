public class CovertStringToCamelCase
{
    public static string ToCamelCase(string str)
    {
        if (str.Length == 1) return str;
        var words = str.Split('_', '-');
        var startWord = words[0];
        var endWords = words.Skip(1).Select(word => char.ToUpper(word[0]) + word.Substring(1)).ToArray();
        return $"{startWord}{string.Join(string.Empty, endWords)}";
  }
}