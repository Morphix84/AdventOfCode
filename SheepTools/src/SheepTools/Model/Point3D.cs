namespace SheepTools.Model;

/// <summary>
/// 3D Point record class
/// </summary>
public record Point3D
{
    public double X { get; set; }

    public double Y { get; set; }

    public double Z { get; set; }

    public string? Id { get; set; }

    public Point3D(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Point3D(string id, double x, double y, double z)
        : this(x, y, z)
    {
        Id = id;
    }

    public virtual double DistanceTo(Point3D otherPoint)
    {
        return Math.Sqrt(
            Math.Pow(otherPoint.X - X, 2)
            + Math.Pow(otherPoint.Y - Y, 2)
            + Math.Pow(otherPoint.Z - Z, 2));
    }

    public override string ToString()
    {
        return $"[{X}, {Y}, {Z}]";
    }

    #region Equals override

    public virtual bool Equals(Point3D? other)
    {
        if (other is null)
        {
            return false;
        }

        return X == other.X && Y == other.Y && Z == other.Z;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z, Id);
    }

    #endregion
}
