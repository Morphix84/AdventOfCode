using SheepTools.Extensions;
using Xunit;

namespace SheepTools.Test.Extensions;

public class CollectionExtensionsTest
{
    [Fact]
    public void AddRangeCollection()
    {
        // Arrange
        var existingCollection = new HashSet<int> { 1, 2, 3 };
        var initialCollection = existingCollection.ToList();
        var itemsToAdd = new List<int> { 4, 5, 6 };

        // Act
        existingCollection.AddRange(itemsToAdd);

        // Assert
        Assert.Equal(initialCollection.Concat(itemsToAdd).ToList(), existingCollection);
    }

    [Fact]
    public void AddRangeList()
    {
        // Arrange
        ICollection<int> existingCollection = new List<int> { 1, 2, 3 };
        var initialCollection = existingCollection.ToList();
        var itemsToAdd = new List<int> { 4, 5, 6 };

        // Act
        existingCollection.AddRange(itemsToAdd);

        // Assert
        Assert.Equal(initialCollection.Concat(itemsToAdd).ToList(), existingCollection);
    }

    [Fact]
    public void RemoveAllList()
    {
        // Arrange
        ICollection<int> existingList = new List<int> { 1, 2, 3, 4, 5, 6 };
        var initialList = existingList.ToList();
        var evens = existingList.Where(n => n % 2 == 0).ToList();

        // Act
        existingList.RemoveAll(n => n % 2 == 0);

        // Assert
        Assert.Equal(initialList.Except(evens).ToList(), existingList);
    }

    [Fact]
    public void RemoveAllCollection()
    {
        // Arrange
        var existingCollection = new HashSet<int> { 1, 2, 3, 4, 5, 6 };
        var initialCollection = existingCollection.ToList();
        var evens = existingCollection.Where(n => n % 2 == 0).ToList();

        // Act
        existingCollection.RemoveAll(n => n % 2 == 0);

        // Assert
        Assert.Equal(initialCollection.Except(evens).ToList(), existingCollection);
    }
}
