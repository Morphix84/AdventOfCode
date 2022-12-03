using SheepTools.Extensions;
using System.Collections;
using Xunit;

namespace SheepTools.Test.Extensions;

public class StringExtensionsTest
{
    [Theory]
    [InlineData("", true)]
    [InlineData(null, false)]
    [InlineData(" ", false)]
    [InlineData(".", false)]
    public void IsEmpty(string? input, bool expected)
    {
        Assert.Equal(expected, input.IsEmpty());
    }

    [Theory]
    [InlineData(null, false)]
    [InlineData("", true)]
    [InlineData(" ", true)]
    [InlineData("  ", true)]
    [InlineData("\r", true)]
    [InlineData("\n", true)]
    [InlineData("\r\n", true)]
    [InlineData("/t", false)]
    [InlineData("\u0000", false)]
    [InlineData("\u001F", false)]
    [InlineData("\u200B", false)]
    [InlineData(".", false)]
    public void IsWhiteSpace(string? input, bool expected)
    {
        Assert.Equal(expected, input.IsWhiteSpace());
    }

    [Theory]
    [InlineData("", false)]
    [InlineData(null, false)]
    [InlineData(" ", true)]
    [InlineData(" true", true)]
    [InlineData("true ", true)]
    [InlineData(" true ", true)]
    [InlineData("tr ue", true)]
    [InlineData("false", false)]
    public void HasWhiteSpaces(string? input, bool expected)
    {
        Assert.Equal(expected, input.HasWhiteSpaces());
    }

    [Theory]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData("1", "1")]
    [InlineData("123", "123")]
    [InlineData("12345", "12345")]
    [InlineData("123456879", "12345")]
    public void Truncate(string? input, string? expected)
    {
        Assert.Equal(expected, input.Truncate(5));
    }

    [Theory]
    [InlineData("abcde", "edcba")]
    [InlineData("  12 34 ", " 43 21  ")]
    [InlineData("", "")]
    public void ReverseString(string input, string expected)
    {
        Assert.Equal(expected, input.ReverseString());
    }

    [Theory]
    [InlineData("011011101011110001010111100,,,,1234aabbcc  \n\t", '1')]
    [InlineData("#.#...###.#...###.......##,,,,1234aabbcc  \n\t", '#')]
    public void ToBoolEnumerable(string input, char one)
    {
        var expected = input.Select(ch => ch == one);
        var result = input.ToBoolEnumerable(one);

        expected.Zip(result).ForEach(pair => Assert.Equal(pair.First, pair.Second));
    }

    [Theory]
    [InlineData("011011101011110001010111100,,,,1234aabbcc  \n\t", '1')]
    [InlineData("#.#...###.#...###.......##,,,,1234aabbcc  \n\t", '#')]
    public void ToBitArray(string input, char one)
    {
        var expected = new BitArray(input.Select(ch => ch == one).ToArray());
        var result = input.ToBitArray(one);

        Assert.Equal(expected, result, new BitArrayComparer());
    }

    [Theory]
    [InlineData("abc", "ABC")]
    [InlineData("abc", "AbC")]
    [InlineData("abc", " abc")]
    [InlineData("AbC 1234 567", "  aBc123 45 67   ")]
    public void RemoveBlanksAndMakeInvariant(string str1, string str2)
    {
        Assert.NotEqual(str1, str2);
        Assert.Equal(str1.RemoveBlanksAndMakeInvariant(), str2.RemoveBlanksAndMakeInvariant());
    }

    [Theory]
    [InlineData("abccba")]
    [InlineData("abcba")]
    [InlineData("abc   CBA ")]
    [InlineData("abc cb a")]
    [InlineData(" abc cb    a")]
    [InlineData("AbC 1234 567  76 5 43 2 1c Ba")]
    [InlineData("AbC 1234 56  76 5 43 2 1c Ba")]
    public void IsPalindrome(string str)
    {
        Assert.True(str.IsPalindrome());
    }
}
