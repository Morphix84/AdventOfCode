using SheepTools.Extensions;
using SheepTools.Model;
using Xunit;

namespace SheepTools.Test.Model;

public class CharExtensionsTest
{
    [Fact]
    public void GetDirection()
    {
        Assert.Equal(Direction.Up, '^'.GetDirection());
        Assert.Equal(Direction.Up, 'n'.GetDirection());
        Assert.Equal(Direction.Down, 'v'.GetDirection());
        Assert.Equal(Direction.Down, 's'.GetDirection());
        Assert.Equal(Direction.Right, '>'.GetDirection());
        Assert.Equal(Direction.Right, 'e'.GetDirection());
        Assert.Equal(Direction.Left, '<'.GetDirection());
        Assert.Equal(Direction.Left, 'w'.GetDirection());
    }
}
