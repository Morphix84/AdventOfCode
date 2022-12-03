using SheepTools.Extensions;
using SheepTools.Model;
using Xunit;

namespace SheepTools.Test.Model;

public class PointTest
{
    [Fact]
    public void Equal()
    {
        var a = new Point(0, 0);
        var b = new Point(0, 0);
        var c = new Point(0, 1);

        Assert.Equal(a, b);
        Assert.NotEqual(a, c);
        Assert.True(a.Equals(b));
        Assert.True(a == b);
        Assert.True(a != c);

        HashSet<Point> set = new() { a };
        Assert.False(set.Add(b));
        Assert.True(set.Add(c));
    }

    [Fact]
    public void ToStringTest()
    {
        var p = new Point("Id", 0, 0);

        Assert.Equal($"[{p.X}, {p.Y}]", p.ToString());
        Assert.Equal("Id", p.Id);
    }

    [Fact]
    public void DistanceTo()
    {
        var a = new Point(0, 0);
        var b = new Point(1, 1);

        var distance = a.DistanceTo(b);

        Assert.True(distance.DoubleEquals(Math.Sqrt(2)));
    }

    [Fact]
    public void ManhattanDistance()
    {
        var a = new Point(0, 0);
        var b = new Point(0, 1);
        var c = new Point(1, 1);

        var distanceAB = a.ManhattanDistance(b);
        Assert.Equal(1, distanceAB);

        var distanceAC = a.ManhattanDistance(c);
        Assert.Equal(2, distanceAC);
    }

    [Fact]
    public void MoveChar()
    {
        var startPoint = new Point(0, 0);

        var newPoint = startPoint.Move('^', 2);
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(0, newPoint.X);
        Assert.Equal(2, newPoint.Y);

        newPoint = startPoint.Move('v');
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(0, newPoint.X);
        Assert.Equal(-1, newPoint.Y);

        newPoint = startPoint.Move('<', -2);
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(2, newPoint.X);
        Assert.Equal(0, newPoint.Y);

        newPoint = startPoint.Move('>', -3);
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(-3, newPoint.X);
        Assert.Equal(0, newPoint.Y);
    }

    [Fact]
    public void MoveDirection()
    {
        var startPoint = new Point(0, 0);

        var newPoint = startPoint.Move(Direction.Up);
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(0, newPoint.X);
        Assert.Equal(1, newPoint.Y);

        newPoint = startPoint.Move(Direction.Down, -1);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(0, newPoint.X);
        Assert.Equal(1, newPoint.Y);

        newPoint = startPoint.Move(Direction.Left, 2);
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(-2, newPoint.X);
        Assert.Equal(0, newPoint.Y);

        newPoint = startPoint.Move(Direction.Right, 3);
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(3, newPoint.X);
        Assert.Equal(0, newPoint.Y);
    }

    [Theory]
    [InlineData(0, 0, 90, 1, 0, 0, 1)]
    [InlineData(0, 0, 90, 0, 1, -1, 0)]
    [InlineData(0, 0, 90, -1, 0, 0, -1)]
    [InlineData(0, 0, 90, 0, -1, 1, 0)]
    [InlineData(0, 0, 180, 1, 1, -1, -1)]
    [InlineData(0, 0, 180, 1, -1, -1, 1)]
    [InlineData(0, 0, 180, -1, 1, 1, -1)]
    [InlineData(0, 0, 180, -1, -1, 1, 1)]
    public void RotateCounterclockwise(int x0, int y0, int angle, int x1, int y1, int expectedX, int expectedY)
    {
        var pivot = new Point(x0, y0);
        var pointToBeRotated = new Point(x1, y1);

        var result = pointToBeRotated.RotateCounterclockwise(pivot, angle);

        Assert.Equal(expectedX, result.X, 4);
        Assert.Equal(expectedY, result.Y, 4);
    }

    [Theory]
    [InlineData(0, 0, 90, 1, 0, 0, -1)]
    [InlineData(0, 0, 90, 0, -1, -1, 0)]
    [InlineData(0, 0, 90, -1, 0, 0, 1)]
    [InlineData(0, 0, 90, 0, 1, 1, 0)]
    [InlineData(0, 0, 180, 1, 1, -1, -1)]
    [InlineData(0, 0, 180, 1, -1, -1, 1)]
    [InlineData(0, 0, 180, -1, 1, 1, -1)]
    [InlineData(0, 0, 180, -1, -1, 1, 1)]
    public void RotateClockwise(int x0, int y0, int angle, int x1, int y1, int expectedX, int expectedY)
    {
        var pivot = new Point(x0, y0);
        var pointToBeRotated = new Point(x1, y1);

        var result = pointToBeRotated.RotateClockwise(pivot, angle);

        Assert.Equal(expectedX, result.X, 4);
        Assert.Equal(expectedY, result.Y, 4);
    }

    [Fact]
    public void CalculateClosestManhattanPoint()
    {
        var a = new Point(0, 0);
        var b = new Point(-1, -1);
        var c = new Point(2, 2);
        var d = new Point(1, 2);
        var e = new Point(-2, 1);

        var result = a.CalculateClosestManhattanPoint(new[] { b, c, d, e });

        Assert.Equal(b, result);
    }

    [Fact]
    public void CalculateClosestManhattanPointNotTied()
    {
        var a = new Point(0, 0);
        var b = new Point(-1, -1);
        var c = new Point(2, 2);
        var d = new Point(1, 2);
        var e = new Point(-2, 1);
        var f = new Point(1, 1);

        var result = a.CalculateClosestManhattanPointNotTied(new[] { b, c, d, e, f });

        Assert.Null(result);
    }

    [Fact]
    public void GeneratePointRangeIteratingOverYFirstInt()
    {
        var xRange = RangeHelpers.GenerateRange(0, 10);
        var yRange = RangeHelpers.GenerateRange(0, 10);

        var pointRange = Point.GeneratePointRangeIteratingOverYFirst(xRange, yRange).ToList();
        var expectedResult = pointRange
            .OrderBy(p => p.X)
            .ThenBy(p => p.Y)
            .ToList();

        Assert.Equal(expectedResult, pointRange);
    }

    [Fact]
    public void GeneratePointRangeIteratingOverXFirstInt()
    {
        var xRange = RangeHelpers.GenerateRange(0, 10);
        var yRange = RangeHelpers.GenerateRange(0, 10);

        var pointRange = Point.GeneratePointRangeIteratingOverXFirst(xRange, yRange).ToList();
        var expectedResult = pointRange
            .OrderBy(p => p.Y)
            .ThenBy(p => p.X)
            .ToList();

        Assert.Equal(expectedResult, pointRange);
    }

    [Fact]
    public void GeneratePointRangeIteratingOverYFirstDouble()
    {
        var xRange = RangeHelpers.GenerateRange(0, 10).Select(x => (double)x);
        var yRange = RangeHelpers.GenerateRange(0, 10).Select(y => (double)y);

        var pointRange = Point.GeneratePointRangeIteratingOverYFirst(xRange, yRange).ToList();
        var expectedResult = pointRange
            .OrderBy(p => p.X)
            .ThenBy(p => p.Y)
            .ToList();

        Assert.Equal(expectedResult, pointRange);
    }

    [Fact]
    public void GeneratePointRangeIteratingOverXFirstDouble()
    {
        var xRange = RangeHelpers.GenerateRange(0, 10).Select(x => (double)x);
        var yRange = RangeHelpers.GenerateRange(0, 10).Select(y => (double)y);

        var pointRange = Point.GeneratePointRangeIteratingOverXFirst(xRange, yRange).ToList();
        var expectedResult = pointRange
            .OrderBy(p => p.Y)
            .ThenBy(p => p.X)
            .ToList();

        Assert.Equal(expectedResult, pointRange);
    }
}
