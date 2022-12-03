namespace SheepTools.Model;

/// <summary>
/// Generic tree node record class.
/// Tree: undirected graph in which any two vertices are connected by exactly one path,
/// or equivalently a connected acyclic undirected graph.
/// That's to say, it can be transversed recursively due its lack of cycles: a node only has one parent
/// Only Id property is taken into account for Equality (both Equals and GetHashCode())
/// </summary>
/// <typeparam name="TKey"></typeparam>
public record TreeNode<TKey> : GenericNode<TKey>
    where TKey : notnull
{
    public TKey ParentId { get; set; } = default!;

    /// <summary>
    /// Parent
    /// </summary>
    public TreeNode<TKey>? Parent { get; set; }

    /// <summary>
    /// Direct descendants
    /// </summary>
    public ICollection<TreeNode<TKey>> Children { get; set; }

    /// <inheritdoc/>
    public TreeNode(TKey id) : base(id)
    {
        Children = new HashSet<TreeNode<TKey>>();
    }

    /// <summary>
    /// Initialize with one of its children
    /// </summary>
    /// <param name="id"></param>
    /// <param name="child">One of their descendants</param>
    /// <exception cref="ArgumentException">When provided child's key is the same as TreeNode key</exception>
    public TreeNode(TKey id, TreeNode<TKey> child) : base(id)
    {
        if (id.Equals(child.Id))
        {
            throw new ArgumentException("A node cannot be its own child");
        }

        Children = new HashSet<TreeNode<TKey>> { child };
    }

    /// <summary>
    /// Initialize with a number of its descendants
    /// </summary>
    /// <param name="id"></param>
    /// <param name="children">Multiple descendants</param>
    /// <exception cref="ArgumentException">When provided child's key is the same as TreeNode key</exception>
    public TreeNode(TKey id, IEnumerable<TreeNode<TKey>> children) : base(id)
    {
        if (children.Select(c => c.Id).Contains(id))
        {
            throw new ArgumentException("A node cannot be its own child");
        }

        Children = new HashSet<TreeNode<TKey>>(children);
    }

    /// <summary>
    /// Initialize with its parent
    /// </summary>
    /// <param name="parent">Node parent</param>
    /// <param name="id"></param>
    /// <exception cref="ArgumentException">When provided child's key is the same as TreeNode key</exception>
    public TreeNode(TreeNode<TKey> parent, TKey id) : base(id)
    {
        if (parent.Id.Equals(id))
        {
            throw new ArgumentException("A node cannot be its own parent");
        }

        Parent = parent;
        ParentId = parent.Id;
        Children = new HashSet<TreeNode<TKey>>();
    }

    /// <summary>
    /// Number of descendants.
    /// Requires nodes children to be populated
    /// </summary>
    /// <returns></returns>
    public virtual int DescendantsCount()
    {
        return Children.Count
            + Children.Select(child => child.DescendantsCount()).Sum();
    }

    /// <summary>
    /// Number of children of the children of (the children of) my children.
    /// Requires nodes children to be populated
    /// Equals to <see cref="DescendantsCount()"/>
    /// </summary>
    /// <returns></returns>
    public virtual int GrandChildrenCount() => DescendantsCount();

    /// <summary>
    /// Number of relationships between this node and its descendants
    /// </summary>
    /// <returns></returns>
    public virtual int RelationshipsCount()
    {
        return Children.Count
               + Children.Select(child => child.DescendantsCount()).Sum()
               + Children.Select(child => child.RelationshipsCount()).Sum();
    }

    /// <summary>
    /// Distance to childNode.
    /// Requires nodes children to be populated.
    /// int.MaxValue if childNode is not among this node descendants
    /// </summary>
    /// <param name="childNode"></param>
    /// <param name="initialDistance"></param>
    /// <returns></returns>
    public virtual int DistanceTo(TreeNode<TKey> childNode, int initialDistance)
    {
        if (Children.Contains(childNode))
        {
            return ++initialDistance;
        }
        else
        {
            int existingDistance = Children.Count > 0
                ? Children.Min(child =>
                    child.DistanceTo(childNode, initialDistance))
                : int.MaxValue;

            return existingDistance == int.MaxValue
                ? int.MaxValue
                : existingDistance + 1;
        }
    }

    /// <summary>
    /// Common ancestor of two nodes.
    /// Requires node parents to be populated
    /// </summary>
    /// <param name="nodes"></param>
    /// <param name="otherNode"></param>
    /// <exception cref="NotFoundException"></exception>
    /// <returns></returns>
    public virtual TreeNode<TKey> GetCommonAncestor(IEnumerable<TreeNode<TKey>> nodes, TreeNode<TKey> otherNode)
    {
        var identifiers = new HashSet<TKey>();

        TreeNode<TKey>? commonAncestor = null;

        void transverseBackwards(IEnumerable<TreeNode<TKey>> nodes, ref HashSet<TKey> identifiers, TreeNode<TKey> currentNode)
        {
            while (currentNode.ParentId != null && !currentNode.ParentId.Equals(default(TKey)))
            {
                if (!identifiers.Add(currentNode.Id))
                {
                    commonAncestor = currentNode;
                    break;
                }

                currentNode = nodes.Single(node => node.Id.Equals(currentNode.ParentId));
            }
        }

        transverseBackwards(nodes, ref identifiers, this);
        transverseBackwards(nodes, ref identifiers, otherNode);

#pragma warning disable S2589 // Boolean expressions should not be gratuitous - False Positive (see https://github.com/SonarSource/sonar-dotnet/issues/3701)
        if (commonAncestor is null)
#pragma warning restore S2589 // Boolean expressions should not be gratuitous
        {
            throw new NotFoundException($"We couldn't find any common ancestors between nodes {Id} and {otherNode.Id}");
        }

        return commonAncestor;
    }

    #region Equals override

    public override bool Equals(TreeNode<TKey>? other) => base.Equals(other);

#pragma warning disable RCS1132 // Remove redundant overriding member. - https://github.com/JosefPihrt/Roslynator/issues/744
    public override int GetHashCode() => base.GetHashCode();
#pragma warning restore RCS1132 // Remove redundant overriding member.

    #endregion
}
