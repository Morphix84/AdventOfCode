using SheepTools.Extensions;
using Xunit;

namespace SheepTools.Test.Extensions;

public class DictionaryExtensionsTest
{
    [Fact]
    public void AddOrUpdate_AddValue()
    {
        static string Update(int n, string str) => $"{n}_{str}_{n}";

        var existingDictionary = new Dictionary<int, string>
        {
            [1] = "foo"
        };

        const int key = 2;
        const string value = "bar";

        Assert.Equal(
            value,
            existingDictionary.AddOrUpdate(
                key,
                value,
                Update));

        const string newValue = "fooz";

        Assert.Equal(
            Update(key, value),
            existingDictionary.AddOrUpdate(
                key,
                newValue,
                Update));
    }

    [Fact]
    public void AddOrUpdate_AddMethod()
    {
        static string Add(int n) => $"{n}_{n}";
        static string Update(int n, string str) => $"{n}_{str}_{n}";

        var existingDictionary = new Dictionary<int, string>
        {
            [1] = "foo"
        };

        const int key = 2;

        Assert.Equal(
            Add(key),
            existingDictionary.AddOrUpdate(
                key,
                Add,
                Update));

        Assert.Equal(
            Update(key, Add(key)),
            existingDictionary.AddOrUpdate(
                key,
                Add,
                Update));
    }

    [Fact]
    public void AddOrUpdate_AddMethodWithFactoryArgument()
    {
        static string Add(int n, string seed) => $"{n}{seed}{n}";
        static string Update(int n, string str, string seed) => $"{n}{seed}{str}{seed}{n}";

        var existingDictionary = new Dictionary<int, string>
        {
            [1] = "foo"
        };

        const string seed = "__";
        const int key = 2;

        Assert.Equal(
            Add(key, seed),
            existingDictionary.AddOrUpdate(
                key,
                Add,
                Update,
                seed));

        Assert.Equal(
            Update(key, Add(key, seed), seed),
            existingDictionary.AddOrUpdate(
                key,
                Add,
                Update,
                seed));
    }
}
