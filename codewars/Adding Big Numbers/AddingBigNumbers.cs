using System;
using System.Collections.Generic;
public class AddingBigNumbers
{
  public static string Add(string a, string b)
  {
    int resultLength = Math.Max(a.Length, b.Length);
    int temp = 0;
    List<char> result = new List<char>();
    
    string first = a.PadLeft(resultLength, '0');
    string second = b.PadLeft(resultLength, '0');
    
    for(int index = (resultLength-1); index >= 0; index--)
    {
      if (((int)Char.GetNumericValue(first[index]) + (int)Char.GetNumericValue(second[index]) + temp) < 10)
        {
          result.Add((char)((int)Char.GetNumericValue(first[index]) + (int)Char.GetNumericValue(second[index]) + temp + 48));
          temp = 0;
        }
      else
        {
          result.Add((char)((int)Char.GetNumericValue(first[index]) + (int)Char.GetNumericValue(second[index]) + temp + 38));
          temp = 1;
        }
    }
    if (temp == 1)
    {
        result.Add((char)(temp + 48));
    }
    result.Reverse();
    
    return new string(result.ToArray());
  }
}