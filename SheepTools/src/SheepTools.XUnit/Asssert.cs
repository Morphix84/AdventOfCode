using Xunit;

namespace SheepTools.XUnit;

public static class Asssert
{
    /// <summary>
    /// Asserts that no exception is thrown
    /// </summary>
    /// <param name="action"></param>
    /// <exception cref="Xunit.Sdk.NullException">When any exception is thrown</exception>
    public static void DoesNotThrow(Action action)
    {
        var exception = Record.Exception(action);
        Assert.Null(exception);
    }

    /// <summary>
    /// Asserts that no exception is thrown
    /// </summary>
    /// <param name="predicate"></param>
    /// <exception cref="Xunit.Sdk.NullException">When any exception is thrown</exception>
    public static void DoesNotThrow(Func<object> predicate)
    {
        var exception = Record.Exception(predicate);
        Assert.Null(exception);
    }

    /// <summary>
    /// Asserts that no exception is thrown
    /// </summary>
    /// <param name="predicate"></param>
    /// <exception cref="Xunit.Sdk.NullException">When any exception is thrown</exception>
    public static async Task DoesNotThrowAsync(Func<Task> predicate)
    {
        var exception = await Record.ExceptionAsync(predicate).ConfigureAwait(false);
        Assert.Null(exception);
    }
}
