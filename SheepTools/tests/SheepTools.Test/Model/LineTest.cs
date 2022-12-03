using SheepTools.Model;
using Xunit;

namespace SheepTools.Test.Model;

public class LineTest
{
    [Fact]
    public void Equal()
    {
        var a = new Point(0, 0);
        var b = new Point(1, 1);
        var c = new Point(2, 2);
        var d = new Point(-1, 0);

        var line1 = new Line(a, b);
        var line2 = new Line(a, c);
        var line3 = new Line(b, c);
        var line4 = new Line(a, d);

        Assert.Equal(line1, line2);
        Assert.Equal(line1, line3);
        Assert.Equal(line2, line3);

        Assert.True(line1.Equals(line2));
        Assert.True(line1.Equals(line3));
        Assert.True(line2.Equals(line3));

        Assert.True(line1 == line2);
        Assert.True(line1 == line3);
        Assert.True(line2 == line3);

        Assert.NotEqual(line1, line4);
        Assert.NotEqual(line2, line4);
        Assert.NotEqual(line3, line4);

        Assert.True(line1 != line4);
        Assert.True(line2 != line4);
        Assert.True(line3 != line4);

        var set = new HashSet<Line>() { line1 };
        Assert.False(set.Add(line2));
        Assert.True(set.Add(line4));
    }

    [Fact]
    public void Equal_InfiniteM()
    {
        var a = new Point(0, 0);
        var b = new Point(0, 1);
        var c = new Point(0, 2);
        var d = new Point(-1, 0);
        var e = new Point(-1, -1);

        var line1 = new Line(a, b);
        var line2 = new Line(a, c);
        var line3 = new Line(b, c);
        var line4 = new Line(a, d);
        var line5 = new Line(d, e);

        Assert.Equal(line1, line2);
        Assert.Equal(line1, line3);
        Assert.Equal(line2, line3);

        Assert.NotEqual(line1, line4);
        Assert.NotEqual(line2, line4);
        Assert.NotEqual(line3, line4);
        Assert.NotEqual(line1, line5);

        var set = new HashSet<Line>() { line1 };
        Assert.False(set.Add(line2));
        Assert.True(set.Add(line4));
        Assert.True(set.Add(line5));
    }

    [Fact]
    public void Equal_0M()
    {
        var a = new Point(3, 2);
        var b = new Point(-3, 2);
        var c = new Point(5, 2);
        var d = new Point(3, 3);
        var e = new Point(-3, 3);

        var line1 = new Line(a, b);
        var line2 = new Line(a, c);
        var line3 = new Line(b, c);
        var line4 = new Line(a, d);
        var line5 = new Line(d, e);

        Assert.Equal(line1, line2);
        Assert.Equal(line1, line3);
        Assert.Equal(line2, line3);

        Assert.NotEqual(line1, line4);
        Assert.NotEqual(line2, line4);
        Assert.NotEqual(line3, line4);
        Assert.NotEqual(line1, line5);

        var set = new HashSet<Line>() { line1 };
        Assert.False(set.Add(line2));
        Assert.True(set.Add(line4));
        Assert.True(set.Add(line5));
    }

    [Fact]
    public void ToStringTest()
    {
        var a = new Point(0, 0);
        var b = new Point(1, 1);
        var line = new Line("I'm just a poor line", a, b);

        Assert.Equal($"[y = {line.Y0} + ({line.M}) * (X - {line.X0}]", line.ToString());
        Assert.Equal("I'm just a poor line", line.Id);
    }
}
