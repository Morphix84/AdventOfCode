﻿using Xunit;

namespace SheepTools.Test;

public class RangeHelpersTest
{
    [Fact]
    public void GenerateRangeTest()
    {
        const int min = -50;
        const int max = +27;

        var result = RangeHelpers.GenerateRange(min, max);

        Assert.Equal(min, result.First());
        Assert.Equal(max, result.Last());
    }
}
