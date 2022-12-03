using SheepTools.Extensions;
using System.Collections;

namespace SheepTools;

public class BitArrayComparer : IEqualityComparer<BitArray>
{
    public bool Equals(BitArray? x, BitArray? y)
    {
        return x?.ToBitString() == y?.ToBitString();
    }

    public int GetHashCode(BitArray obj)
    {
        return obj.ToBitString().GetHashCode();
    }
}
