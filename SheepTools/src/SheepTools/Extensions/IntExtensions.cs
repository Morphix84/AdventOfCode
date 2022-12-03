namespace SheepTools.Extensions;

public static class IntExtensions
{
    public static int Factorial(this int n)
    {
        return n > 0
            ? n * Factorial(n - 1)
            : 1;
    }

    public static int Clamp(this int value, int min, int max)
    {
        if (value <= min)
        {
            return min;
        }
        else if (value >= max)
        {
            return max;
        }
        else
        {
            return value;
        }
    }
}
