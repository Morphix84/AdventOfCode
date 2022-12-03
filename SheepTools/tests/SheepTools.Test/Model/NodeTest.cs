using SheepTools.Model;
using Xunit;

namespace SheepTools.Test.Model;

public class NodeTest
{
    private record CustomNode : TreeNode<DateTime>
    {
        public CustomNode(DateTime id) : base(id)
        {
        }

        public CustomNode(DateTime id, TreeNode<DateTime> child) : base(id, child)
        {
        }
    }

    [Fact]
    public void ShouldNotHaveDefaultKey()
    {
        Assert.Throws<ArgumentException>(() => new CustomNode(default));
    }

    [Fact]
    public void ShouldNotHaveItselfAsChild()
    {
        var customNode = new CustomNode(DateTime.Now);

        Assert.Throws<ArgumentException>(() => new CustomNode(customNode.Id, customNode));
    }

    [Fact]
    public void NodeEqual()
    {
        var a = new Node("#1");
        var b = new Node("#1");
        var c = new Node("");
        var d = new Node("3");

        Assert.Equal(a, b);
        Assert.True(a.Equals(b));
        Assert.True(a == b);
        Assert.NotEqual(a, c);
        Assert.NotEqual(a, d);
        Assert.NotEqual(c, d);
        Assert.True(c != d);

        HashSet<Node> set = new() { a };
        Assert.False(set.Add(b));
        Assert.True(set.Add(c));
        Assert.True(set.Add(d));
    }

    [Fact]
    public void CustomNodeEqual()
    {
        DateTime now = DateTime.Now;

        CustomNode a = new(now);
        CustomNode b = new(now);
        CustomNode c = new(DateTime.Now);
        CustomNode d = new(now.AddSeconds(1));

        Assert.Equal(a, b);
        Assert.True(a.Equals(b));
        Assert.True(a == b);
        Assert.NotEqual(a, c);
        Assert.NotEqual(a, d);
        Assert.NotEqual(c, d);
        Assert.True(c != d);

        HashSet<CustomNode> set = new() { a };
        Assert.False(set.Add(b));
        Assert.True(set.Add(c));
        Assert.True(set.Add(d));
    }

    [Fact]
    public void DescendantsCount()
    {
        var d = new CustomNode(DateTime.Now);
        var c = new CustomNode(DateTime.Now, d);
        var b = new CustomNode(DateTime.Now, c);
        var a = new CustomNode(DateTime.Now, b);

        Assert.Equal(0, d.DescendantsCount());
        Assert.Equal(0, d.GrandChildrenCount());
        Assert.Equal(1, c.DescendantsCount());
        Assert.Equal(1, c.GrandChildrenCount());
        Assert.Equal(2, b.DescendantsCount());
        Assert.Equal(2, b.GrandChildrenCount());
        Assert.Equal(3, a.DescendantsCount());
        Assert.Equal(3, a.GrandChildrenCount());
    }

    /// <summary>
    /// See https://adventofcode.com/2019/day/6, part 1
    /// </summary>
    [Fact]
    public void RelationshipsCount()
    {
        var nodes = GenerateTestGraphWithChildren();

        var com = nodes.Single(n => n.Id == "COM");
        var result = com.RelationshipsCount();

        Assert.Equal(42, result);
    }

    /// <summary>
    /// See https://adventofcode.com/2019/day/6, part 2
    /// </summary>
    [Fact]
    public void DistanceTo()
    {
        var nodes = GenerateTestGraphWithChildren();

        var k = nodes.Single(n => n.Id == "K");
        var d = nodes.Single(n => n.Id == "D");
        var i = nodes.Single(n => n.Id == "I");

        var result = d.DistanceTo(k, 0) + d.DistanceTo(i, 0);

        Assert.Equal(4, result);
        Assert.Equal(4, d.DistanceTo(k, 1));

        Assert.Equal(int.MaxValue, k.DistanceTo(d, 0));
        Assert.Equal(int.MaxValue, i.DistanceTo(d, 0));
        Assert.Equal(int.MaxValue, k.DistanceTo(i, 0));
        Assert.Equal(int.MaxValue, i.DistanceTo(k, 0));
    }

    [Fact]
    public void GetCommonAncestor()
    {
        var nodes = GenerateTestGraphWithParent();

        var d = nodes.Single(n => n.Id == "D");
        var e = nodes.Single(n => n.Id == "E");
        var f = nodes.Single(n => n.Id == "F");
        var l = nodes.Single(n => n.Id == "L");

        Assert.Equal(d.Id, d.GetCommonAncestor(nodes, d).Id);
        Assert.Equal(d.Id, d.GetCommonAncestor(nodes, e).Id);
        Assert.Equal(d.Id, d.GetCommonAncestor(nodes, f).Id);
        Assert.Equal(e.Id, f.GetCommonAncestor(nodes, l).Id);
        Assert.Equal(e.Id, l.GetCommonAncestor(nodes, f).Id);
    }

    /// <summary>
    /// https://adventofcode.com/2019/day/6
    /// </summary>
    /// <returns></returns>
    private static ICollection<Node> GenerateTestGraphWithChildren()
    {
        var nodeList = new List<Node>();

        var l = new Node("L");
        var i = new Node("I");
        var h = new Node("H");
        var f = new Node("F");
        var k = new Node("K", l);
        var j = new Node("J", k);
        var g = new Node("G", h);
        var e = new Node("E", new[] { f, j });
        var d = new Node("D", new[] { e, i });
        var c = new Node("C", d);
        var b = new Node("B", new[] { c, g });
        var com = new Node("COM", b);
        b.Children.Add(g);
        e.Children.Add(j);
        d.Children.Add(i);

        nodeList.AddRange(new[] { com, b, c, d, e, f, g, h, i, j, k, l });

        return nodeList;
    }

    /// <summary>
    /// https://adventofcode.com/2019/day/6
    /// </summary>
    /// <returns></returns>
    private static ICollection<Node> GenerateTestGraphWithParent()
    {
        var nodeList = new List<Node>();

        var com = new Node("COM");
        var b = new Node(com, "B");
        var c = new Node(b, "C");
        var d = new Node(c, "D");
        var e = new Node(d, "E");
        var f = new Node(e, "F");
        var g = new Node(b, "G");
        var h = new Node(g, "H");
        var i = new Node(d, "I");
        var j = new Node(e, "J");
        var k = new Node(j, "K");
        var l = new Node(k, "L");

        nodeList.AddRange(new[] { com, b, c, d, e, f, g, h, i, j, k, l });

        return nodeList;
    }
}
