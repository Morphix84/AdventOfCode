using Xunit;

namespace SheepTools.XUnit.Test;

public class AsssertTest
{
    [Fact]
    public void DoesNotThrowAction()
    {
        var list = new List<int> { 0 };

        Asssert.DoesNotThrow(() => list.Clear());
        Assert.Throws<Xunit.Sdk.NullException>(() => Asssert.DoesNotThrow(() => list.Insert(1, 1)));
    }

    [Fact]
    public void DoesNotThrowFunc()
    {
        var list = new List<int> { 1 };

        Asssert.DoesNotThrow(() => list.Count);
        Assert.Throws<Xunit.Sdk.NullException>(() => Asssert.DoesNotThrow(() => list[2]));
    }

    [Fact]
    public async Task DoesNotThrowAsync()
    {
        var list = new List<int> { 2 };

        await Asssert.DoesNotThrowAsync(() => Task.FromResult(list.Count)).ConfigureAwait(false);
        await Assert.ThrowsAsync<Xunit.Sdk.NullException>(() => Asssert.DoesNotThrowAsync(() => Task.FromResult(list[3]))).ConfigureAwait(false);
    }
}
