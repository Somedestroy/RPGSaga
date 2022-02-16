using System;
using System.Collections.Generic;
public class AddingBigNumbers
{
  public static string Add(string a, string b)
  {
    int resultLength = Math.Max(a.Length, b.Length);
    int temp = 0;
    List<char> result = new List<char>();
    const int convertToCharFactor1 = 48;
    const int convertToCharFactor2 = 38;
    string first = a.PadLeft(resultLength, '0');
    string second = b.PadLeft(resultLength, '0');
    
    for(int index = (resultLength-1); index >= 0; index--)
    {
      //In this part we consider the case when the sum of two numbers will be less than 10. To convert result to char we use the first factor(e.g. 7 + 2 + 0 + 48 = 57 => 9) 
      if (((int)Char.GetNumericValue(first[index]) + (int)Char.GetNumericValue(second[index]) + temp) < 10)
        {
          result.Add((char)((int)Char.GetNumericValue(first[index]) + (int)Char.GetNumericValue(second[index]) + temp + convertToCharFactor1));
          temp = 0;
        }
        //In this part we consider the case when the sum of two number will be more than 10. We use second factor (e.g. 7 + 4 + 0 + 38 = 49 => 1). In the next condition we add the remainder. 
      else
        {
          result.Add((char)((int)Char.GetNumericValue(first[index]) + (int)Char.GetNumericValue(second[index]) + temp + convertToCharFactor2));
          temp = 1;
        }
    }
    //Remainder
    if (temp == 1)
    {
        result.Add((char)(temp + convertToCharFactor1));
    }
    result.Reverse();
    
    return new string(result.ToArray());
  }
}