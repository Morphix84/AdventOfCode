using SheepTools.Model;

namespace SheepTools;

public static class RangeHelpers
{
    public static int DirectionToInt(Direction dir)
    {
        switch (dir)
        {
            case Direction.Right: return 0;
            case Direction.Down: return 1;
            case Direction.Left: return 2;
            case Direction.Up: return 3;
        }
        throw new InvalidOperationException();
    }

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
