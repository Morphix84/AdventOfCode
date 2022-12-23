namespace SheepTools.Model;

/// <summary>
/// Lightweight <see cref="Point"/> record class, based on <see cref="int"/> and without Id.
/// </summary>
public record IntPoint
{
    public int X { get; set; }

    public int Y { get; set; }

    public IntPoint(int x, int y)
    {
        X = x;
        Y = y;
    }

    public virtual double ManhattanDistance(IntPoint point)
    {
        return Math.Abs(point.X - X) + Math.Abs(point.Y - Y);
    }

    public virtual double DistanceTo(IntPoint otherPoint)
    {
        return Math.Sqrt(
            Math.Pow(otherPoint.X - X, 2)
            + Math.Pow(otherPoint.Y - Y, 2));
    }

    public virtual IntPoint Move(char direction, int distance = 1)
    {
        return direction switch
        {
            '>' => this with { X = X + distance },
            '<' => this with { X = X - distance },
            '^' => this with { Y = Y - distance },
            'v' => this with { Y = Y + distance },
            _ => throw new ArgumentException("Supported directions: >, <, ^, v")
        };
    }

    public virtual IntPoint Move(Direction direction, int distance = 1)
    {
        return direction switch
        {
            Direction.Right => this with { X = X + distance },
            Direction.Left => this with { X = X - distance },
            Direction.Up => this with { Y = Y - distance },
            Direction.Down => this with { Y = Y + distance },
            _ => throw new NotSupportedException($"Direction {direction} isn't supported yet")
        };
    }

    public virtual IntPoint RotateCounterclockwise(IntPoint pivot, double angle, bool isRadians = false)
    {
        if (!isRadians)
        {
            angle = Math.PI * angle / 180;
        }

        var sinAngle = Math.Sin(angle);
        var cosAngle = Math.Cos(angle);

        double deltaX = X - pivot.X;
        double deltaY = Y - pivot.Y;

        return new IntPoint(
            x: Convert.ToInt32(
                pivot.X
                + (cosAngle * deltaX)
                - (sinAngle * deltaY)),
            y: Convert.ToInt32(
                pivot.Y
                + (sinAngle * deltaX)
                + (cosAngle * deltaY)));
    }

    public virtual IntPoint RotateClockwise(IntPoint pivot, double angle, bool isRadians = false)
    {
        if (!isRadians)
        {
            angle = Math.PI * angle / 180;
        }

        var sinAngle = Math.Sin(angle);
        var cosAngle = Math.Cos(angle);

        var deltaX = X - pivot.X;
        var deltaY = Y - pivot.Y;

        return new IntPoint(
            x: Convert.ToInt32(
                pivot.X
                + (cosAngle * deltaX)
                + (sinAngle * deltaY)),
            y: Convert.ToInt32(
                pivot.Y
                - (sinAngle * deltaX)
                + (cosAngle * deltaY)));
    }

    public static IEnumerable<IntPoint> GeneratePointRangeIteratingOverYFirst(IEnumerable<int> xRange, IEnumerable<int> yRange)
    {
        foreach (var x in xRange)
        {
            foreach (var y in yRange)
            {
                yield return new IntPoint(x, y);
            }
        }
    }

    public static IEnumerable<IntPoint> GeneratePointRangeIteratingOverXFirst(IEnumerable<int> xRange, IEnumerable<int> yRange)
    {
        foreach (var y in yRange)
        {
            foreach (var x in xRange)
            {
                yield return new IntPoint(x, y);
            }
        }
    }

    public override string ToString()
    {
        return $"[{X}, {Y}]";
    }
}
