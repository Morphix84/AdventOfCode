namespace SheepTools;

public static class RangeHelpers
{
    /// <summary>
    /// [minValue, maxValue]
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static IEnumerable<int> GenerateRange(int minValue, int maxValue)
    {
        return Enumerable.Range(minValue, maxValue - minValue + 1);
    }
}
