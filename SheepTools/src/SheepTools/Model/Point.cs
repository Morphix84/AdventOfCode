namespace SheepTools.Model;

/// <summary>
/// Point record class
/// </summary>
public record Point
{
    public double X { get; set; }

    public double Y { get; set; }

    public string? Id { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public Point(string id, double x, double y)
    {
        Id = id;
        X = x;
        Y = y;
    }

    public virtual double ManhattanDistance(Point point)
    {
        return Math.Abs(point.X - X) + Math.Abs(point.Y - Y);
    }

    public virtual double DistanceTo(Point otherPoint)
    {
        return Math.Sqrt(
            Math.Pow(otherPoint.X - X, 2)
            + Math.Pow(otherPoint.Y - Y, 2));
    }

    public virtual Point Move(char direction, double distance = 1)
    {
        return direction switch
        {
            '>' => this with { X = X + distance },
            '<' => this with { X = X - distance },
            '^' => this with { Y = Y + distance },
            'v' => this with { Y = Y - distance },
            _ => throw new ArgumentException("Supported directions: >, <, ^, v")
        };
    }

    public virtual Point Move(Direction direction, double distance = 1)
    {
        return direction switch
        {
            Direction.Right => this with { X = X + distance },
            Direction.Left => this with { X = X - distance },
            Direction.Up => this with { Y = Y + distance },
            Direction.Down => this with { Y = Y - distance },
            _ => throw new NotSupportedException($"Direction {direction} isn't supported yet")
        };
    }

    public virtual Point RotateCounterclockwise(Point pivot, double angle, bool isRadians = false)
    {
        if (!isRadians)
        {
            angle = Math.PI * angle / 180;
        }

        var sinAngle = Math.Sin(angle);
        var cosAngle = Math.Cos(angle);

        double deltaX = X - pivot.X;
        double deltaY = Y - pivot.Y;

        return new Point(
            x: pivot.X
                + (cosAngle * deltaX)
                - (sinAngle * deltaY),
            y: pivot.Y
                + (sinAngle * deltaX)
                + (cosAngle * deltaY));
    }

    public virtual Point RotateClockwise(Point pivot, double angle, bool isRadians = false)
    {
        if (!isRadians)
        {
            angle = Math.PI * angle / 180;
        }

        var sinAngle = Math.Sin(angle);
        var cosAngle = Math.Cos(angle);

        var deltaX = X - pivot.X;
        var deltaY = Y - pivot.Y;

        return new Point(
            x: pivot.X
                + (cosAngle * deltaX)
                + (sinAngle * deltaY),
            y: pivot.Y
                - (sinAngle * deltaX)
                + (cosAngle * deltaY));
    }

    public virtual Point CalculateClosestManhattanPoint(ICollection<Point> candidatePoints)
    {
        Dictionary<Point, double> pointDistanceDictionary = new();

        foreach (Point point in candidatePoints)
        {
            pointDistanceDictionary.Add(point, ManhattanDistance(point));
        }

        return pointDistanceDictionary.OrderBy(pair => pair.Value)
            .First().Key;
    }

    /// <summary>
    /// Returns null if there are multiple points at min Manhattan distance
    /// </summary>
    /// <param name="candidatePoints"></param>
    /// <returns></returns>
    public virtual Point? CalculateClosestManhattanPointNotTied(ICollection<Point> candidatePoints)
    {
        Dictionary<Point, double> pointDistanceDictionary = new();

        foreach (Point point in candidatePoints)
        {
            pointDistanceDictionary.Add(point, ManhattanDistance(point));
        }

        var orderedDictionary = pointDistanceDictionary.OrderBy(pair => pair.Value);

        return pointDistanceDictionary.Values.Count(distance => distance == orderedDictionary.First().Value) == 1
            ? orderedDictionary.First().Key
            : null;
    }

    public static IEnumerable<Point> GeneratePointRangeIteratingOverYFirst(IEnumerable<double> xRange, IEnumerable<double> yRange)
    {
        foreach (double x in xRange)
        {
            foreach (double y in yRange)
            {
                yield return new Point(x, y);
            }
        }
    }

    public static IEnumerable<Point> GeneratePointRangeIteratingOverYFirst(IEnumerable<int> xRange, IEnumerable<int> yRange)
    {
        return GeneratePointRangeIteratingOverYFirst(xRange.Select(x => (double)x), yRange.Select(y => (double)y));
    }

    public static IEnumerable<Point> GeneratePointRangeIteratingOverXFirst(IEnumerable<double> xRange, IEnumerable<double> yRange)
    {
        foreach (double y in yRange)
        {
            foreach (double x in xRange)
            {
                yield return new Point(x, y);
            }
        }
    }

    public static IEnumerable<Point> GeneratePointRangeIteratingOverXFirst(IEnumerable<int> xRange, IEnumerable<int> yRange)
    {
        return GeneratePointRangeIteratingOverXFirst(xRange.Select(x => (double)x), yRange.Select(y => (double)y));
    }

    public override string ToString()
    {
        return $"[{X}, {Y}]";
    }

    #region Equals override

    public virtual bool Equals(Point? other)
    {
        if (other is null)
        {
            return false;
        }

        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Id);
    }
    #endregion
}
