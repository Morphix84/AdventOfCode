using SheepTools.Model;
using Xunit;

namespace SheepTools.Test;

public class LinearInterpolationTest
{
    [Fact]
    public void Interpolate()
    {
        const double x0 = 0, x1 = 10;
        const double y0 = 0, y1 = 10;

        const double x = 5;

        var y = LinearInterpolation.InterpolateLinearly(x, x0, x1, y0, y1);
        var anotherY0 = LinearInterpolation.InterpolateLinearly(x0, x0, x1, y0, y1);
        var anotherY1 = LinearInterpolation.InterpolateLinearly(x1, x0, x1, y0, y1);

        Assert.Equal(x, y);
        Assert.Equal(y0, anotherY0);
        Assert.Equal(y1, anotherY1);
    }

    [Fact]
    public void InterpolateVertical()
    {
        const double x0 = 5, x1 = 5;
        const double y0 = 0, y1 = 10;

        const double x = 20;

        var y = LinearInterpolation.InterpolateLinearly(x, x0, x1, y0, y1);

        Assert.Equal(0.5 * (y0 + y1), y);
    }

    [Fact]
    public void InterpolatePoint()
    {
        var p1 = new Point(1, 0);
        var p2 = new Point(11, 10);

        const double x = 8;

        var p3 = LinearInterpolation.InterpolateYLinearly(x, p1, p2);
        var p4 = LinearInterpolation.InterpolateXLinearly(p3.Y, p1, p2);

        Assert.Equal(x, p3.X);
        Assert.Equal(x - 1, p3.Y);
        Assert.Equal(p3, p4);
    }
}
