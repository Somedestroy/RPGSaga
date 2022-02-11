public class ValidParantheses
{
    public static bool ValidParantheses(string input)
    {
        int count = 0;
        for (int i = 0; i< input.Length; i++)
        {
            if (input[i] == '(')
            {
                count++;
            }
            else if (input[j] == ')')
            {
                count --;
            }
            if (count < 0)
            {
                return false;
            }
        }
        return count > 0? false : true; 
    }
}