public class CovertStringToCamelCase
{
    public static string ToCamelCase(string str)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != '-' && str[i] != '_') sb.Append(str[i]);
            else sb.Append(char.ToUpper(str[++i]));
        }
    return sb.ToString();   
    }
}