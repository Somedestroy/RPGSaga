public class FindDigitalRoot
{
    public int DigitalRoot(long n)
    {
        if ((n /10) == 0) return n;
        long sum = 0;
        while (n != 0)
        {
            sum += n % 10;
            n /= 10;
        }
    return DigitalRoot(sum);
    }
}