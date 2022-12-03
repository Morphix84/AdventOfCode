using SheepTools.Extensions;
using SheepTools.Model;
using Xunit;

namespace SheepTools.Test.Model;

public class Point3DTest
{
    [Fact]
    public void Equal()
    {
        Point3D a = new(0, 0, 0);
        Point3D b = new(0, 0, 0);
        Point3D c = new(0, 1, 0);

        Assert.Equal(a, b);
        Assert.True(a.Equals(b));
        Assert.NotEqual(a, c);
        Assert.True(a == b);
        Assert.True(a != c);

        HashSet<Point3D> set = new() { a };
        Assert.False(set.Add(b));
        Assert.True(set.Add(c));
    }

    [Fact]
    public void ToStringTest()
    {
        var p = new Point3D("Id", 0, 0, 0);

        Assert.Equal($"[{p.X}, {p.Y}, {p.Z}]", p.ToString());
        Assert.Equal("Id", p.Id);
    }

    [Fact]
    public void DistanceTo()
    {
        var a = new Point3D(0, 0, 0);
        var b = new Point3D(0, 0, 1);
        var c = new Point3D(0, 1, 1);
        var d = new Point3D(1, 1, 1);

        var distanceAB = a.DistanceTo(b);
        Assert.True(distanceAB.DoubleEquals(1));

        var distanceAC = a.DistanceTo(c);
        Assert.True(distanceAC.DoubleEquals(Math.Sqrt(2)));

        var distanceAD = a.DistanceTo(d);
        Assert.True(distanceAD.DoubleEquals(Math.Sqrt(3)));
    }
}
