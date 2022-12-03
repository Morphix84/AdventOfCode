namespace SheepTools.Model;

/// <summary>
/// Generic node record class with a non default <typeparamref name="TKey"/>.
/// </summary>
/// <typeparam name="TKey">Generic key</typeparam>
public record GenericNode<TKey>
    where TKey : notnull
{
    public TKey Id { get; set; }

    /// <summary>
    /// Identifier cannot have TKey's default value
    /// </summary>
    /// <param name="id"></param>
    public GenericNode(TKey id)
    {
        if (id is null || id.Equals(default(TKey)))
        {
            throw new ArgumentException($"Id cannot be {id} (default value)");
        }

        Id = id;
    }

    #region Equals override

    public virtual bool Equals(TreeNode<TKey>? other)
    {
        if (other is null)
        {
            return false;
        }

        return Id.GetType() == typeof(TKey) && Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    #endregion
}
