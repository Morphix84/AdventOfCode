using SheepTools.Helpers;
using Xunit;

namespace SheepTools.Test.Extensions;

public class NumericExtensionsTest
{
    [Theory]
    [InlineData(int.MinValue, 3)]
    [InlineData(0, 3)]
    [InlineData(1, 3)]
    [InlineData(3, 3)]
    [InlineData(4, 4)]
    [InlineData(5, 5)]
    [InlineData(7, 5)]
    [InlineData(int.MaxValue, 5)]
    public void ClampInt(int n, int result)
    {
        const int min = 3;
        const int max = 5;

        Assert.Equal(result, n.Clamp(min, max));
    }

    [Theory]
    [InlineData(short.MinValue, 3)]
    [InlineData(0, 3)]
    [InlineData(1, 3)]
    [InlineData(3, 3)]
    [InlineData(4, 4)]
    [InlineData(5, 5)]
    [InlineData(7, 5)]
    [InlineData(short.MaxValue, 5)]
    public void ClampShort(short n, short result)
    {
        const short min = 3;
        const short max = 5;

        Assert.Equal(result, n.Clamp(min, max));
    }

    [Theory]
    [InlineData(long.MinValue, 3)]
    [InlineData(0, 3)]
    [InlineData(1, 3)]
    [InlineData(3, 3)]
    [InlineData(4, 4)]
    [InlineData(5, 5)]
    [InlineData(7, 5)]
    [InlineData(long.MaxValue, 5)]
    public void ClampLong(long n, long result)
    {
        const long min = 3;
        const long max = 5;

        Assert.Equal(result, n.Clamp(min, max));
    }

    [Theory]
    [InlineData(uint.MinValue, 3)]
    [InlineData(0, 3)]
    [InlineData(1, 3)]
    [InlineData(3, 3)]
    [InlineData(4, 4)]
    [InlineData(5, 5)]
    [InlineData(7, 5)]
    [InlineData(uint.MaxValue, 5)]
    public void ClampUint(uint n, uint result)
    {
        const uint min = 3;
        const uint max = 5;

        Assert.Equal(result, n.Clamp(min, max));
    }

    [Theory]
    [InlineData(ulong.MinValue, 3)]
    [InlineData(0, 3)]
    [InlineData(1, 3)]
    [InlineData(3, 3)]
    [InlineData(4, 4)]
    [InlineData(5, 5)]
    [InlineData(7, 5)]
    [InlineData(ulong.MaxValue, 5)]
    public void ClampUlong(ulong n, ulong result)
    {
        const ulong min = 3;
        const ulong max = 5;

        Assert.Equal(result, n.Clamp(min, max));
    }

    [Theory]
    [InlineData(float.MinValue, 3.01)]
    [InlineData(0, 3.01)]
    [InlineData(1, 3.01)]
    [InlineData(3.02, 3.02)]
    [InlineData(4, 4)]
    [InlineData(4.98, 4.98)]
    [InlineData(5, 4.99)]
    [InlineData(float.MaxValue, 4.99)]
    public void ClampFloat(float n, float result)
    {
        const float min = 3.01f;
        const float max = 4.99f;

        Assert.Equal(result, n.Clamp(min, max));
    }

    [Theory]
    [InlineData(double.MinValue, 3.01)]
    [InlineData(0, 3.01)]
    [InlineData(1, 3.01)]
    [InlineData(3.02, 3.02)]
    [InlineData(4, 4)]
    [InlineData(4.98, 4.98)]
    [InlineData(5, 4.99)]
    [InlineData(double.MaxValue, 4.99)]
    public void ClampDouble(double n, double result)
    {
        const double min = 3.01;
        const double max = 4.99;

        Assert.Equal(result, n.Clamp(min, max));
    }

    [Fact]
    public void ClampDateTime()
    {
        DateTime min = new(2019, 10, 25);
        DateTime max = new(2019, 10, 30);

        Dictionary<DateTime, DateTime> numberExpectedClampedValuePair = new()
        {
            [DateTime.MinValue] = min,
            [new DateTime(2019, 10, 24, 23, 0, 0)] = min,
            [new DateTime(2019, 10, 25, 1, 0, 0)] = new DateTime(2019, 10, 25, 1, 0, 0),
            [new DateTime(2019, 10, 30, 0, 0, 1)] = max,
            [DateTime.MaxValue] = max
        };

        foreach (var pair in numberExpectedClampedValuePair)
        {
            Assert.Equal(pair.Value, pair.Key.Clamp(min, max));
        }
    }
}
