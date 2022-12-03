using System.Collections;

namespace SheepTools.Extensions;

public static class StringHelpers
{
    /// <summary>
    /// str is empty
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsEmpty(this string? str)
    {
        return str?.Length == 0;
    }

    /// <summary>
    /// str consists exclusively of white-space characters
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsWhiteSpace(this string? str)
    {
        return str is not null && string.IsNullOrWhiteSpace(str);
    }

    /// <summary>
    /// str has any white-space
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool HasWhiteSpaces(this string? str)
    {
        return str?.Contains(" ") == true;
    }

    /// <summary>
    /// Takes the first maxLength characters of a string, or the whole string if maxLength is greater than or equal to str.Length
    /// </summary>
    /// <param name="str"></param>
    /// <param name="maxLength"></param>
    /// <returns></returns>
    public static string? Truncate(this string? str, int maxLength)
    {
        return (str?.Length > maxLength)
            ? str.Substring(0, maxLength)
            : str;
    }

    /// <summary>
    /// Reverses a string
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ReverseString(this string str)
    {
        return string.Join(string.Empty, str.Reverse());
    }

    /// <summary>
    /// Creates a <see cref="BitArray"/> from a 'binary' string, where true is represented by <paramref name="one"/> and false by any other character.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="one"></param>
    /// <returns></returns>
    public static BitArray ToBitArray(this string str, char one = '1')
    {
        return new BitArray(str.ToBoolEnumerable(one).ToArray());
    }

    /// <summary>
    /// Creates an enumerable of booleans from a 'binary' string, where true is represented by <paramref name="one"/> and false by any other character.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="one"></param>
    /// <returns></returns>
    public static IEnumerable<bool> ToBoolEnumerable(this string str, char one = '1')
    {
        return str.Select(ch => ch == one);
    }

    public static string RemoveBlanksAndMakeInvariant(this string str)
    {
        return str.Replace(" ", string.Empty).ToLowerInvariant();
    }

    public static bool IsPalindrome(this string str)
    {
        return str.RemoveBlanksAndMakeInvariant() == str.ReverseString().RemoveBlanksAndMakeInvariant();
    }
}
