public class Snail
{
    public static int[] Snail(int[][] array)
   {
      int[] result = new int[array.Length * array.Length];
      if (array.Length == 1) 
        {
        return array[0];
        }
      int index = 0;
      int rowStart = 0;
      int rowEnd = array.Length -1;
      int columnStart = 0;
      int columnEnd = array.Length -1;
      for(int i = 0; i < array.Length/2; i++)
        {
          for(int row = rowStart; row <= rowEnd; row++)
            {
              result[index++] = array[columnStart][row];
            }
          columnStart++;
          for(int column = columnStart; column <= columnEnd; column++)
            {
              result[index++] = array[column][rowEnd];
            }
          rowEnd--;

          for(int row = rowEnd; row >= rowStart; row--)
            {
              result[index++] = array[columnEnd][row];
            }
          columnEnd--;
        
          for(int column = columnEnd; column >= columnStart; column--)
            {
              result[index++] = array[column][rowStart];
            }
          rowStart++;
         
        }
     if (array.Length % 2 != 0)
       result[index] = array[rowStart][columnStart];
     
     return result;
   }
}