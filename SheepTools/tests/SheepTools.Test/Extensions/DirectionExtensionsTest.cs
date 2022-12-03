using SheepTools.Extensions;
using SheepTools.Model;
using Xunit;

namespace SheepTools.Test.Extensions;

public class DirectionExtensionsTest
{
    [Theory]
    [InlineData(Direction.Up, Direction.Left)]
    [InlineData(Direction.Right, Direction.Up)]
    [InlineData(Direction.Down, Direction.Right)]
    [InlineData(Direction.Left, Direction.Down)]
    public void TurnLeft(Direction input, Direction expected)
    {
        Assert.Equal(expected, input.TurnLeft());
    }

    [Theory]
    [InlineData(Direction.Up, Direction.Right)]
    [InlineData(Direction.Right, Direction.Down)]
    [InlineData(Direction.Down, Direction.Left)]
    [InlineData(Direction.Left, Direction.Up)]
    public void TurnRight(Direction input, Direction expected)
    {
        Assert.Equal(expected, input.TurnRight());
    }

    [Theory]
    [InlineData(Direction.Up, Direction.Down)]
    [InlineData(Direction.Right, Direction.Left)]
    [InlineData(Direction.Down, Direction.Up)]
    [InlineData(Direction.Left, Direction.Right)]
    public void Turn180(Direction input, Direction expected)
    {
        Assert.Equal(expected, input.Turn180());
    }

    [Theory]
    [InlineData(Direction.Up, Direction.Down)]
    [InlineData(Direction.Right, Direction.Left)]
    [InlineData(Direction.Down, Direction.Up)]
    [InlineData(Direction.Left, Direction.Right)]
    public void Opposite(Direction input, Direction expected)
    {
        Assert.Equal(expected, input.Opposite());
    }
}
