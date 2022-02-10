public class FindTheMissingLetter
{
    public static char FindMissingLetter(char[] array)
    {
        char result = new char();
        for (int i = 0; i < array.Length-1; i++)
        {
            if ((int)(array[i+1] - array[i]) != 1)
            {
                result = (char)(array[i] + 1);
            }
        }
        return result;
    }
}