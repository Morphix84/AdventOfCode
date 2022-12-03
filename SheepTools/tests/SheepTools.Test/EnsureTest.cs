using SheepTools.Model;
using SheepTools.XUnit;
using Xunit;

namespace SheepTools.Test;

public class EnsureTest
{
#pragma warning disable CA1805 // Do not initialize unnecessarily - Intended for the purpose of the test
    private static readonly EnsureTest? NullInstance = null;
#pragma warning restore CA1805 // Do not initialize unnecessarily

    [Fact]
    public void Equal()
    {
        var date = new DateTime(1111, 1, 1);
        DateTime otherDate(int n = 0) => new(date.Ticks + n);

        Asssert.DoesNotThrow(() => Ensure.Equal(date, otherDate()));
        Assert.Throws<ValidationException>(() => Ensure.Equal(date, otherDate(1)));
        Assert.Throws<ValidationException>(() => Ensure.Equal(NullInstance, new EnsureTest()));
        Assert.Throws<ValidationException>(() => Ensure.Equal(new EnsureTest(), NullInstance));
        Assert.Throws<ValidationException>(() => Ensure.Equal(NullInstance, NullInstance));
    }

    [Fact]
    public void EqualsTest()
    {
        var date = new DateTime(1111, 1, 1);
        DateTime otherDate(int n = 0) => new(date.Ticks + n);

        Asssert.DoesNotThrow(() => Ensure.Equals(date, otherDate()));
        Assert.Throws<ValidationException>(() => Ensure.Equals(date, otherDate(1)));
        Assert.Throws<ValidationException>(() => Ensure.Equals(NullInstance, new EnsureTest()));
        Assert.Throws<ValidationException>(() => Ensure.Equals(new EnsureTest(), NullInstance));
        Assert.Throws<ValidationException>(() => Ensure.Equal(NullInstance, NullInstance));
    }

    [Fact]
    public void NotEqual()
    {
        var date = new DateTime(2222, 1, 1);
        DateTime otherDate(int n = 0) => new(date.Ticks + n);

        Asssert.DoesNotThrow(() => Ensure.NotEqual(date, otherDate(-1)));
        Assert.Throws<ValidationException>(() => Ensure.NotEqual(date, otherDate()));
        Assert.Throws<ValidationException>(() => Ensure.NotEqual(NullInstance, new EnsureTest()));
        Assert.Throws<ValidationException>(() => Ensure.NotEqual(new EnsureTest(), NullInstance));
        Assert.Throws<ValidationException>(() => Ensure.NotEqual(NullInstance, NullInstance));
    }

    [Fact]
    public void NotEquals()
    {
        var date = new DateTime(2222, 1, 1);
        DateTime otherDate(int n = 0) => new(date.Ticks + n);

        Asssert.DoesNotThrow(() => Ensure.NotEquals(date, otherDate(-1)));
        Assert.Throws<ValidationException>(() => Ensure.NotEquals(date, otherDate()));
        Assert.Throws<ValidationException>(() => Ensure.NotEquals(NullInstance, new EnsureTest()));
        Assert.Throws<ValidationException>(() => Ensure.NotEquals(new EnsureTest(), NullInstance));
        Assert.Throws<ValidationException>(() => Ensure.NotEquals(NullInstance, NullInstance));
    }

    [Fact]
    public void True()
    {
        Asssert.DoesNotThrow(() => Ensure.True(true));
        Assert.Throws<ValidationException>(() => Ensure.True(false));
        Assert.Throws<ValidationException>(() => Ensure.True(null));
    }

    [Fact]
    public void False()
    {
        Asssert.DoesNotThrow(() => Ensure.False(false));
        Assert.Throws<ValidationException>(() => Ensure.False(true));
        Assert.Throws<ValidationException>(() => Ensure.False(null));
    }

    [Fact]
    public void Null()
    {
        Point? nullPoint = null;

        Asssert.DoesNotThrow(() => Ensure.Null(nullPoint));
        Assert.Throws<ValidationException>(() => Ensure.Null(new Point(1, 2)));
    }

    [Fact]
    public void NotNull()
    {
        Point? nullPoint = null;

        Asssert.DoesNotThrow(() => Ensure.NotNull(new Point(1, 2)));
        Assert.Throws<ValidationException>(() => Ensure.NotNull(nullPoint));
    }

    [Fact]
    public void NotNullParams()
    {
        Asssert.DoesNotThrow(() => Ensure.NotNull(new Point(1, 2), 3));
        Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(null, 3));
        Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(new Point(1, 2), 1, null));
        Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(new Point(1, 2), "", null));
    }

    [Fact]
    public void Empty()
    {
        Asssert.DoesNotThrow(() => Ensure.Empty(string.Empty));
        Assert.Throws<ValidationException>(() => Ensure.Empty(" "));
        Assert.Throws<ValidationException>(() => Ensure.Empty(null));
    }

    [Fact]
    public void NotEmpty()
    {
        Asssert.DoesNotThrow(() => Ensure.NotEmpty(" "));
        Asssert.DoesNotThrow(() => Ensure.NotEmpty(null));
        Assert.Throws<ValidationException>(() => Ensure.NotEmpty(string.Empty));
    }

    [Fact]
    public void NullOrEmpty()
    {
        Asssert.DoesNotThrow(() => Ensure.NullOrEmpty(string.Empty));
        Asssert.DoesNotThrow(() => Ensure.NullOrEmpty(null));
        Assert.Throws<ValidationException>(() => Ensure.NullOrEmpty(" "));
    }

    [Fact]
    public void NotNullOrEmpty()
    {
        Asssert.DoesNotThrow(() => Ensure.NotNullOrEmpty(" "));
        Assert.Throws<ValidationException>(() => Ensure.NotNullOrEmpty(string.Empty));
        Assert.Throws<ValidationException>(() => Ensure.NotNullOrEmpty(null));
    }

    [Fact]
    public void NullOrWhiteSpace()
    {
        Asssert.DoesNotThrow(() => Ensure.NullOrWhiteSpace(string.Empty));
        Asssert.DoesNotThrow(() => Ensure.NullOrWhiteSpace(null));
        Asssert.DoesNotThrow(() => Ensure.NullOrWhiteSpace(" "));
        Assert.Throws<ValidationException>(() => Ensure.NullOrWhiteSpace("*"));
    }

    [Fact]
    public void NotNullOrWhiteSpace()
    {
        Asssert.DoesNotThrow(() => Ensure.NotNullOrWhiteSpace("*"));
        Assert.Throws<ValidationException>(() => Ensure.NotNullOrWhiteSpace(string.Empty));
        Assert.Throws<ValidationException>(() => Ensure.NotNullOrWhiteSpace(null));
        Assert.Throws<ValidationException>(() => Ensure.NotNullOrWhiteSpace(" "));
    }

    [Fact]
    public void EmptyEnumerable()
    {
        Asssert.DoesNotThrow(() => Ensure.Empty(Array.Empty<string>()));
        Assert.Throws<ValidationException>(() => Ensure.Empty(new string[] { string.Empty }));
        Assert.Throws<ValidationException>(() => Ensure.Empty(null));
    }

    [Fact]
    public void NotEmptyEnumerable()
    {
        Asssert.DoesNotThrow(() => Ensure.NotEmpty(new string?[] { null }));
        Asssert.DoesNotThrow(() => Ensure.NotEmpty(null));
        Assert.Throws<ValidationException>(() => Ensure.NotEmpty(Array.Empty<string>()));
    }

    [Fact]
    public void NullOrEmptyEnumerable()
    {
        Asssert.DoesNotThrow(() => Ensure.NullOrEmpty(Array.Empty<string>()));
        Asssert.DoesNotThrow(() => Ensure.NullOrEmpty(null));
        Assert.Throws<ValidationException>(() => Ensure.NullOrEmpty(new string[] { string.Empty }));
    }

    [Fact]
    public void NotNullOrEmptyEnumerable()
    {
        Asssert.DoesNotThrow(() => Ensure.NotNullOrEmpty(new string?[] { null }));
        Assert.Throws<ValidationException>(() => Ensure.NotNullOrEmpty(Array.Empty<string>()));
        Assert.Throws<ValidationException>(() => Ensure.NotNullOrEmpty(null));
    }

    [Fact]
    public void Count()
    {
        IEnumerable<string>? nullEnumerable = null;

        Asssert.DoesNotThrow(() => Ensure.Count(1, new string?[] { null }));
        Assert.Throws<ValidationException>(() => Ensure.Count(1, Array.Empty<string>()));
        Assert.Throws<ValidationException>(() => Ensure.Count(1, nullEnumerable));
    }

    [Fact]
    public void CountWithPredicate()
    {
        IEnumerable<string>? nullEnumerable = null;
        static bool predicate(string? str) => str is null;

        Asssert.DoesNotThrow(() => Ensure.Count(1, new string?[] { null }, predicate));
        Assert.Throws<ValidationException>(() => Ensure.Count(1, new string[] { string.Empty }, predicate));
        Assert.Throws<ValidationException>(() => Ensure.Count(1, Array.Empty<string>(), predicate));
        Assert.Throws<ValidationException>(() => Ensure.Count(1, nullEnumerable, predicate));
    }
}
