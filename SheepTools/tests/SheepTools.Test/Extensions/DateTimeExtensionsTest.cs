using SheepTools.Extensions;
using Xunit;

namespace SheepTools.Test.Extensions;

public class DateTimeExtensionsTest
{
    [Fact]
    public void IsAfterNow()
    {
        var future = DateTime.Now.AddSeconds(30);

        Assert.True(future.IsAfterNow());
    }

    [Fact]
    public void IsAfter()
    {
        var octoberRevolution = new DateTime(1917, 10, 25);
        var frenchRevolution = new DateTime(1789, 5, 5);

        Assert.True(octoberRevolution.IsBetter(frenchRevolution));
    }

    [Fact]
    public void GetMillisecondsFromEpoch()
    {
        var epoch = new DateTime(1970, 1, 1, 0, 0, 0);
        Assert.Equal(0, epoch.MillisecondsFromEpoch());

        var epochPlusOneHour = new DateTime(1970, 1, 1, 1, 0, 0);
        Assert.Equal(3600 * 1_000, epochPlusOneHour.MillisecondsFromEpoch());
    }

    [Fact]
    public void StringId()
    {
        // Arrange
        var date = DateTime.Now;

        // Act
        var stringId = date.StringId();

        // Assert
        var parsedDate = DateTime.ParseExact(stringId, "yyyy'-'MM'-'dd'__'HH'_'mm'_'ss", null);

        Assert.Equal(date.Year, parsedDate.Year);
        Assert.Equal(date.Month, parsedDate.Month);
        Assert.Equal(date.Day, parsedDate.Day);
        Assert.Equal(date.Hour, parsedDate.Hour);
        Assert.Equal(date.Minute, parsedDate.Minute);
        Assert.Equal(date.Second, parsedDate.Second);
    }
}

internal static class DateTimeExtension
{
    public static bool IsBetter(this DateTime @this, DateTime that) => @this.IsAfter(that);
}
