using System.Linq;

public class MovingZeroesToTheEnd
{
    public static int[] MoveZeroes(int[] arr)
    {
        return arr.OrderBy(b => b == 0).ToArray.ToArray();
    }
}