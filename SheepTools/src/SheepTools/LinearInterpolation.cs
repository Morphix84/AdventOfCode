using SheepTools.Model;

namespace SheepTools;

public static class LinearInterpolation
{
    public static double InterpolateLinearly(double x, double x0, double x1, double y0, double y1)
    {
        if ((x1 - x0) == 0)
        {
            return (y0 + y1) / 2;
        }
        return y0 + ((x - x0) * (y1 - y0) / (x1 - x0));
    }

    public static Point InterpolateYLinearly(double x, Point p1, Point p2)
    {
        var y = InterpolateLinearly(x, p1.X, p2.X, p1.Y, p2.Y);

        return new Point(x, y);
    }

    public static Point InterpolateXLinearly(double y, Point p1, Point p2)
    {
        var x = InterpolateLinearly(y, p1.Y, p2.Y, p1.X, p2.X);

        return new Point(x, y);
    }
}
