public class FindDigitalRoot
{
    public int DigitalRoot(long n)
    {
<<<<<<< HEAD
        if ((n /10) == 0) return n;
        long sum = 0;
        while (n != 0)
=======
        if (n < 10) return (int)n;
        long sum = 0;
        while (n > 0)
>>>>>>> 1495b2d44133d48b4ed18d81b2bbeefe0a5c46d1
        {
            sum += n % 10;
            n /= 10;
        }
    return DigitalRoot(sum);
    }
}