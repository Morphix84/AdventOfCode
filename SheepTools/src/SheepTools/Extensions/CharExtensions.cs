using SheepTools.Model;

namespace SheepTools.Extensions;

public static class CharExtensions
{
    public static Direction GetDirection(this char ch)
    {
        return ch switch
        {
            '^' => Direction.Up,
            'n' => Direction.Up,
            'v' => Direction.Down,
            's' => Direction.Down,
            '>' => Direction.Right,
            'e' => Direction.Right,
            '<' => Direction.Left,
            'w' => Direction.Left,
            _ => throw new ArgumentException("Supported directions: n, ^, s, v, e, >, w, <")
        };
    }
}
