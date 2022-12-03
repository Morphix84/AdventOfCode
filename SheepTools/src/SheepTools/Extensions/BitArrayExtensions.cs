using System.Collections;

namespace SheepTools.Extensions;

public static class BitArrayExtensions
{
    public static BitArray Reverse(this BitArray bitArray)
    {
        var result = new BitArray(bitArray);

        int length = bitArray.Length;
        int mid = (length / 2);

        for (int i = 0; i < mid; i++)
        {
            result[length - i - 1] = bitArray[i];
            result[i] = bitArray[length - i - 1];
        }

        return result;
    }

    public static string ToBitString(this BitArray bitArray)
    {
        return string.Join("", bitArray.Cast<bool>().Select(bit => bit ? 1 : 0));
    }
}
