using Moq;
using SheepTools.Extensions;
using Xunit;

namespace SheepTools.Test.Extensions;

public class EnumerableExtensionsTest
{
    protected virtual void Foo() => throw new NotSupportedException();

    [Fact]
    public void ForEachList()
    {
        // Arrange
        var mock = new Mock<EnumerableExtensionsTest>();
        IEnumerable<EnumerableExtensionsTest> list = new List<EnumerableExtensionsTest> { mock.Object, mock.Object, mock.Object };

        // Act
        list.ForEach(str => str.Foo());

        // Assert
        mock.Verify(m => m.Foo(), Times.Exactly(list.Count()));
    }

    [Fact]
    public void ForEachEnumerable()
    {
        // Arrange
        var mock = new Mock<EnumerableExtensionsTest>();
        var enumerable = new HashSet<EnumerableExtensionsTest> { mock.Object, mock.Object, mock.Object };

        // Act
        enumerable.ForEach(str => str.Foo());

        // Assert
        mock.Verify(m => m.Foo(), Times.Exactly(enumerable.Count));
    }

    [Fact]
    public void IsNullOrEmpty()
    {
        var emptyEnumerable = Enumerable.Empty<double>();
        Assert.True(emptyEnumerable.IsNullOrEmpty());

        IEnumerable<double>? nullEnumerable = null;
        Assert.True(nullEnumerable.IsNullOrEmpty());

        var notNullOrEmptyEnumerable = new List<double> { Math.PI };
        Assert.False(notNullOrEmptyEnumerable.IsNullOrEmpty());
    }

    [Fact]
    public void IntersectAll()
    {
        var listOfListsOfChars = new List<List<char>>
            {
                new List<char> { 'a', 'b', 'c' },
                new List<char> { 'a', 'a', 'c' },
                new List<char> { 'a' }
            };
        var charIntersection = listOfListsOfChars.IntersectAll();
        Assert.Single(charIntersection);
        Assert.Equal('a', charIntersection.Single());

        var listOfListsOfInt = new List<List<int>>
            {
                new List<int> { 1 },
                new List<int> { 2 },
            };
        var intIntersection = listOfListsOfInt.IntersectAll();
        Assert.Empty(intIntersection);

        Assert.Empty(new List<List<double>>().IntersectAll());
    }

    [Fact]
    public void IntersectAllString()
    {
        var listOfStrings = new List<string>
            {
                "abc",
                "aac",
                "a"
            };

        var intersection = listOfStrings.IntersectAll();
        Assert.Equal('a', intersection.Single());
        Assert.Single(intersection);
    }
}
