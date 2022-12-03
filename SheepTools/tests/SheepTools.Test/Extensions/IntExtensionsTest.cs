using SheepTools.Extensions;
using Xunit;

namespace SheepTools.Test.Extensions;

public class IntExtensionsTest
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 6)]
    [InlineData(4, 24)]
    [InlineData(5, 120)]
    public void Factorial(int n, int result)
    {
        Assert.Equal(result, n.Factorial());
    }

    [Theory]
    [InlineData(int.MinValue, -3)]
    [InlineData(-99999999, -3)]
    [InlineData(-4, -3)]
    [InlineData(-3, -3)]
    [InlineData(-2, -2)]
    [InlineData(-1, -1)]
    [InlineData(0, 0)]
    [InlineData(+1, +1)]
    [InlineData(+2, +2)]
    [InlineData(+3, +3)]
    [InlineData(+4, +3)]
    [InlineData(+99999999, +3)]
    [InlineData(int.MaxValue, +3)]
    public void Clamp(int n, int result)
    {
        const int minValue = -3;
        const int maxValue = +3;

        Assert.Equal(result, n.Clamp(minValue, maxValue));
    }
}
