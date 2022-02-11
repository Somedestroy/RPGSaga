public class ArrayDeepCount
{
    public int DeepCount(object a)
    {

        int length = 0;
        foreach(var item in a as Array)
        {
            length++;
            if (item as Array)
            {
                length += DeepCount(item as Array);
            }
        }   
    return length;
    }
}