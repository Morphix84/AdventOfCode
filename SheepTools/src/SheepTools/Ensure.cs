using SheepTools.Extensions;

namespace SheepTools;

/// <summary>
/// Assert-style class
/// </summary>
public static class Ensure
{
    private const string DefaultMessage = "Assertion failed";

    /// <summary>
    /// Checks that two items are equal, and throws an exception otherwise.
    /// Equals() method is used.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="otherItem"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void Equal<T>(T item, T otherItem, string message = DefaultMessage)
    {
        if (item is null || otherItem is null || !item.Equals(otherItem))
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that two items are equal, and throws an exception otherwise.
    /// Equals() method is used.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="otherItem"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void Equals<T>(T item, T otherItem, string message = DefaultMessage) => Equal(item, otherItem, message);

    /// <summary>
    /// Checks that two items are not equal, and throws an exception otherwise.
    /// Equals() method is used.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="otherItem"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void NotEqual<T>(T item, T otherItem, string message = DefaultMessage)
    {
        if (item == null || otherItem == null || item.Equals(otherItem))
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that two items are not equal, and throws an exception otherwise.
    /// Equals() method is used.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="otherItem"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void NotEquals<T>(T item, T otherItem, string message = DefaultMessage) => NotEqual(item, otherItem, message);

    /// <summary>
    /// Checks that boolean is true, and throws an exception otherwise.
    /// </summary>
    /// <param name="boolean"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void True(bool? boolean, string message = DefaultMessage)
    {
        if (boolean != true)
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that boolean is true, and throws an exception otherwise.
    /// </summary>
    /// <param name="boolean"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void False(bool? boolean, string message = DefaultMessage)
    {
        if (boolean != false)
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that item is null, and throws an exception otherwise.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void Null<T>(T item, string message = DefaultMessage)
    {
        if (item != null)
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that item is not null, and throws an exception otherwise.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void NotNull<T>(T item, string message = DefaultMessage)
    {
        if (item == null)
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that none of the arguments is null.
    /// </summary>
    /// <param name="objects"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void NotNull(params object?[] objects)
    {
        foreach (var obj in objects)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(objects), "At least one of the arguments is null");
            }
        }
    }

    /// <summary>
    /// Checks that str is empty, and throws an exception otherwise.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void Empty(string? str, string message = DefaultMessage)
    {
        if (!str.IsEmpty())
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that an enumerable is empty, and throws an exception otherwise.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void Empty<T>(IEnumerable<T>? enumerable, string message = DefaultMessage)
    {
        if (enumerable?.Any() != false)
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that str is not empty, and throws an exception otherwise.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void NotEmpty(string? str, string message = DefaultMessage)
    {
        if (str.IsEmpty())
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that an enumerable is not empty, and throws an exception otherwise.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void NotEmpty<T>(IEnumerable<T>? enumerable, string message = DefaultMessage)
    {
        if (enumerable?.Any() != true)
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that str is null or empty, and throws an exception otherwise.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    public static void NullOrEmpty(string? str, string message = DefaultMessage)
    {
        if (!str.IsNullOrEmpty())
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that an enumerable is null or empty, and throws an exception otherwise.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void NullOrEmpty<T>(IEnumerable<T>? enumerable, string message = DefaultMessage)
    {
        if (enumerable?.Any() == true)
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that str is not null or empty, and throws an exception otherwise.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void NotNullOrEmpty(string? str, string message = DefaultMessage)
    {
        if (str?.IsNullOrEmpty() != false)
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that an enumerable is not null or empty, and throws an exception otherwise.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void NotNullOrEmpty<T>(IEnumerable<T>? enumerable, string message = DefaultMessage)
    {
        if (enumerable?.Any() == false)
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that str is null, empty or whitespace, and throws an exception otherwise.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void NullOrWhiteSpace(string? str, string message = DefaultMessage)
    {
        if (!string.IsNullOrWhiteSpace(str))
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that str is not null, empty or whitespace, and throws an exception otherwise.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void NotNullOrWhiteSpace(string? str, string message = DefaultMessage)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that the size of an enumerable is the expected one, and throws an exception otherwise.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="expectedCount"></param>
    /// <param name="enumerable"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void Count<T>(int expectedCount, IEnumerable<T>? enumerable, string message = DefaultMessage)
    {
        if (enumerable?.Count() != expectedCount)
        {
            throw new ValidationException(message);
        }
    }

    /// <summary>
    /// Checks that the size of an enumerable is the expected one, and throws an exception otherwise.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="expectedCount"></param>
    /// <param name="enumerable"></param>
    /// <param name="predicate"></param>
    /// <param name="message"></param>
    /// <exception cref="ValidationException"></exception>
    public static void Count<T>(int expectedCount, IEnumerable<T>? enumerable, Func<T, bool> predicate, string message = DefaultMessage)
    {
        if (enumerable?.Count(predicate) != expectedCount)
        {
            throw new ValidationException(message);
        }
    }
}
