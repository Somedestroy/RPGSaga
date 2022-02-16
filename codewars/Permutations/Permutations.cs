using System;
using System.Collections.Generic;
using System.Linq;

class Permutations
{

  static List<string> result;
  public static List<string> SinglePermutations(string s)
  {
    result = new List<string>();
    Permutation(s, 0, s.Length - 1);
    return result.Distinct().ToList();
  }  
    public static void Permutation(string str, int start, int end)
    {
       if (start == end)
        {
          result.Add(str); 
        }
      else
        {
          for (int i = start; i <= end; i++)
          {  
            str = Swap(str, start, i);
            Permutation(str, start+1, end);
            str = Swap(str, start, i);
          }
        }
    }
    public static string Swap(string input, int i, int j)
    {
      char temp;
      char[] charArray = input.ToCharArray();
      temp = charArray[i];
      charArray[i] = charArray[j];
      charArray[j] = temp;
      return new string(charArray);
    }    
}