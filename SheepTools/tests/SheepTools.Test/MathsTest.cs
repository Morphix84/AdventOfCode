using Xunit;

namespace SheepTools.Test;

public class MathsTest
{
    [Theory]
    [InlineData(2, 2, 2)]
    [InlineData(2, 3, 6)]
    [InlineData(2, 4, 4)]
    [InlineData(40, 12, 120)]
    public void LeastCommonMultiple(ulong a, ulong b, ulong result)
    {
        Assert.Equal(result, Maths.LeastCommonMultiple(a, b));
    }

    [Theory]
    [InlineData(new ulong[] { 1, 2, 3 }, 6)]
    [InlineData(new ulong[] { 2, 4, 8 }, 8)]
    [InlineData(new ulong[] { 2, 3, 9 }, 18)]
    [InlineData(new ulong[] { 4, 6, 10, 30 }, 60)]
    [InlineData(new ulong[] { 9, 60, 64 }, 2880)]
    [InlineData(new ulong[] { 240, 492, 768 }, 157440)]
    public void LeastCommonMultipleEnumerable(ulong[] input, ulong result)
    {
        Assert.Equal(result, Maths.LeastCommonMultiple(input));
    }

    [Fact]
    public void ShouldNotAttemptLcdWith0AsArgument()
    {
        Assert.Throws<ArgumentException>(() => Maths.LeastCommonMultiple(0, 0));
        Assert.Throws<ArgumentException>(() => Maths.LeastCommonMultiple(3, 0));
        Assert.Throws<ArgumentException>(() => Maths.LeastCommonMultiple(new ulong[] { 0, 3 }));
    }

    [Theory]
    [InlineData(13, 1, 1)]
    [InlineData(13, 13, 13)]
    [InlineData(60, 72, 12)]
    [InlineData(13 * 17, 13 * 34, 13 * 17)]
    public void GreatestCommonDivisor(ulong a, ulong b, ulong result)
    {
        Assert.Equal(result, Maths.GreatestCommonDivisor(a, b));
    }

    [Theory]
    [InlineData(new ulong[] { 1, 2, 3 }, 1)]
    [InlineData(new ulong[] { 9, 60, 99 }, 3)]
    [InlineData(new ulong[] { 12, 60, 64 }, 4)]
    [InlineData(new ulong[] { 240, 492, 768 }, 12)]
    public void GreatestCommonDivisorEnumerable(ulong[] input, ulong result)
    {
        Assert.Equal(result, Maths.GreatestCommonDivisor(input));
    }

    [Fact]
    public void ShouldNotAttemptGcdWith0AsArgument()
    {
        Assert.Throws<ArgumentException>(() => Maths.GreatestCommonDivisor(0, 3));
        Assert.Throws<ArgumentException>(() => Maths.GreatestCommonDivisor(3, 0));
        Assert.Throws<ArgumentException>(() => Maths.GreatestCommonDivisor(new ulong[] { 0, 3 }));
    }
}
