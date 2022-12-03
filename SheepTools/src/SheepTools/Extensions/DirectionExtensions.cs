using SheepTools.Model;

namespace SheepTools.Extensions;

public static class DirectionExtensions
{
    public static Direction TurnLeft(this Direction direction)
    {
        return (Direction)(((int)direction + 3) % 4);
    }

    public static Direction TurnRight(this Direction direction)
    {
        return (Direction)(((int)direction + 1) % 4);
    }

    public static Direction Turn180(this Direction direction)
    {
        return (Direction)(((int)direction + 2) % 4);
    }

    public static Direction Opposite(this Direction direction) => Turn180(direction);
}
