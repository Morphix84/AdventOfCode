using SheepTools.Extensions;
using System.Collections;
using Xunit;

namespace SheepTools.Test.Extensions;

public class BitArrayExtensionsTest
{
    [Fact]
    public void Reverse()
    {
        const string originalString = "10011101";
        var reversedString = originalString.ReverseString();

        var array = new BitArray(originalString.Select(ch => ch == '1').ToArray());
        var expected = new BitArray(reversedString.Select(ch => ch == '1').ToArray());

        Assert.Equal(originalString, array.ToBitString());
        Assert.Equal(reversedString, array.Reverse().ToBitString());
        Assert.Equal(expected.ToBitString(), array.Reverse().ToBitString());
    }

    [Fact]
    public void ToBitString()
    {
        const string expected = "10011101";
        var array = new BitArray(expected.Select(ch => ch == '1').ToArray());

        Assert.Equal(expected, array.ToBitString());
    }
}
