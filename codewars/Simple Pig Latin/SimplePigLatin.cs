public class SimplePigLatin
{
  public static string PigIt(string str)
  {
    string [] splittedStr  = str.Split(' ');
    string result = "";
    foreach (string word in splittedStr)
      {
        if (word.Length > 1)
          {
            result += word.Substring(1) + word[0] + "ay ";
          }
        else
          {
            result += word[0] + " ";
          }
      }
    return result.Trim();
  }
}