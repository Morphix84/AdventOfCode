using SheepTools.Extensions;
using SheepTools.Model;
using Xunit;

namespace SheepTools.Test.Model;

public class IntPointTest
{
    [Fact]
    public void Equal()
    {
        var a = new IntPoint(0, 0);
        var b = new IntPoint(0, 0);
        var c = new IntPoint(0, 1);

        Assert.Equal(a, b);
        Assert.NotEqual(a, c);
        Assert.True(a.Equals(b));
        Assert.True(a == b);
        Assert.True(a != c);

        HashSet<IntPoint> set = new() { a };
        Assert.False(set.Add(b));
        Assert.True(set.Add(c));
    }

    [Fact]
    public void ToStringTest()
    {
        var p = new IntPoint(0, 0);

        Assert.Equal($"[{p.X}, {p.Y}]", p.ToString());
    }

    [Fact]
    public void DistanceTo()
    {
        var a = new IntPoint(0, 0);
        var b = new IntPoint(1, 1);

        var distance = a.DistanceTo(b);

        Assert.True(distance.DoubleEquals(Math.Sqrt(2)));
    }

    [Fact]
    public void ManhattanDistance()
    {
        var a = new IntPoint(0, 0);
        var b = new IntPoint(0, 1);
        var c = new IntPoint(1, 1);

        var distanceAB = a.ManhattanDistance(b);
        Assert.Equal(1, distanceAB);

        var distanceAC = a.ManhattanDistance(c);
        Assert.Equal(2, distanceAC);
    }

    [Fact]
    public void MoveChar()
    {
        var startPoint = new IntPoint(0, 0);

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
        var startPoint = new IntPoint(0, 0);

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
        var pivot = new IntPoint(x0, y0);
        var pointToBeRotated = new IntPoint(x1, y1);
        var expectedPoint = new IntPoint(expectedX, expectedY);

        var result = pointToBeRotated.RotateCounterclockwise(pivot, angle);

        Assert.Equal(expectedPoint, result);
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
        var pivot = new IntPoint(x0, y0);
        var pointToBeRotated = new IntPoint(x1, y1);
        var expectedPoint = new IntPoint(expectedX, expectedY);

        var result = pointToBeRotated.RotateClockwise(pivot, angle);

        Assert.Equal(expectedPoint, result);
    }

    [Fact]
    public void GeneratePointRangeIteratingOverYFirst()
    {
        var xRange = RangeHelpers.GenerateRange(0, 10);
        var yRange = RangeHelpers.GenerateRange(0, 10);

        var pointRange = IntPoint.GeneratePointRangeIteratingOverYFirst(xRange, yRange).ToList();
        var expectedResult = pointRange
            .OrderBy(p => p.X)
            .ThenBy(p => p.Y)
            .ToList();

        Assert.Equal(expectedResult, pointRange);
    }

    [Fact]
    public void GeneratePointRangeIteratingOverXFirst()
    {
        var xRange = RangeHelpers.GenerateRange(0, 10);
        var yRange = RangeHelpers.GenerateRange(0, 10);

        var pointRange = IntPoint.GeneratePointRangeIteratingOverXFirst(xRange, yRange).ToList();
        var expectedResult = pointRange
            .OrderBy(p => p.Y)
            .ThenBy(p => p.X)
            .ToList();

        Assert.Equal(expectedResult, pointRange);
    }
}
