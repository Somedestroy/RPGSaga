using System;
using System.Collections.Generic;
using System.Linq;

public class Intervals
{
    public static int SumIntervals((int, int)[] intervals)
    {
      List<int> result = new List<int>();
      foreach (var interval in intervals)
        {
          for (int index = interval.Item1; index < interval.Item2; index++)
            {
              result.Add(index);
            }
        }
      return result.Distinct().Count();
    }
}