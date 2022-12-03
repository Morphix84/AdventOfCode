namespace SheepTools;

public static class Maths
{
    /// <summary>
    /// lcm calculated based on an interative implementation of the Euclidean Algorithm
    /// </summary>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static ulong LeastCommonMultiple(this IEnumerable<ulong> enumerable)
    {
        return enumerable.Aggregate(LeastCommonMultiple);
    }

    /// <summary>
    /// lcm calculated based on an interative implementation of the Euclidean Algorithm
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static ulong LeastCommonMultiple(ulong a, ulong b)
    {
        // Dividing first to avoid overflows
        return a / GreatestCommonDivisor(a, b) * b;
    }

    /// <summary>
    /// gcd calculated using the Euclidean Algorithm (iterative implementation)
    /// </summary>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static ulong GreatestCommonDivisor(this IEnumerable<ulong> enumerable)
    {
        var result = enumerable.ElementAt(0);
        for (int i = 1; i < enumerable.Count(); i++)
        {
            result = GreatestCommonDivisor(enumerable.ElementAt(i), result);

            if (result == 1)
            {
                return 1;
            }
        }

        return result;
    }

    /// <summary>
    /// gcd calculated using the Euclidean Algorithm (iterative implementation)
    /// </summary>
    /// <param name="a">Greater than 0</param>
    /// <param name="b">Greater than 0</param>
    /// <returns></returns>
    public static ulong GreatestCommonDivisor(ulong a, ulong b)
    {
        if (a == 0 || b == 0)
        {
            throw new ArgumentException("Arguments are expected to be greater than 0");
        }

        while (b != 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }
}
