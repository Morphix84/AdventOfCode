namespace SheepTools.Model;

/// <summary>
/// Tree node record class with string as key.
/// See the generic <see cref="TreeNode{TKey}"/> for more information.
/// </summary>
public record Node : TreeNode<string>
{
    /// <inheritdoc/>
    public Node(string id) : base(id)
    {
    }

    /// <inheritdoc/>
    public Node(string id, Node child) : base(id, child)
    {
    }

    /// <inheritdoc/>
    public Node(string id, IEnumerable<Node> children) : base(id, children)
    {
    }

    /// <inheritdoc/>
    public Node(Node parent, string id) : base(parent, id)
    {
    }
}
