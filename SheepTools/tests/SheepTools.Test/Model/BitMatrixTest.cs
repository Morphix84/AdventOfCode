using SheepTools.Model;
using System.Collections;
using Xunit;

namespace SheepTools.Test.Model;

public class BitMatrixTest
{
    [Theory]
    [MemberData(nameof(FlipUpsideDownData))]
    public void FlipUpsideDown(BitMatrix original, BitMatrix expectedResult)
    {
        var result = original.FlipUpsideDown();

        foreach (var (first, second) in expectedResult.Content.Zip(result.Content))
        {
            Assert.Equal(first, second);
        }
    }

    [Theory]
    [MemberData(nameof(FlipLeftRightData))]
    public void FlipLeftRight(BitMatrix original, BitMatrix expectedResult)
    {
        var result = original.FlipLeftRight();

        foreach (var (first, second) in expectedResult.Content.Zip(result.Content))
        {
            Assert.Equal(first, second);
        }
    }

    [Theory]
    [MemberData(nameof(RotateClockwiseData))]
    public void RotateClockwise(BitMatrix original, BitMatrix expectedResult)
    {
        var result = original.RotateClockwise();

        foreach (var (first, second) in expectedResult.Content.Zip(result.Content))
        {
            Assert.Equal(first, second);
        }
    }

    [Theory]
    [MemberData(nameof(RotateAnticlockwiseData))]
    public void RotateAnticlockwise(BitMatrix original, BitMatrix expectedResult)
    {
        var result = original.RotateAnticlockwise();

        foreach (var (first, second) in expectedResult.Content.Zip(result.Content))
        {
            Assert.Equal(first, second);
        }
    }

    [Theory]
    [MemberData(nameof(Rotate180Data))]
    public void Rotate180(BitMatrix original, BitMatrix expectedResult)
    {
        var result = original.Rotate180();

        foreach (var (first, second) in expectedResult.Content.Zip(result.Content))
        {
            Assert.Equal(first, second);
        }
    }

    public static IEnumerable<object[]> FlipUpsideDownData()
    {
        yield return new object[]
        {
                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { true, true, false }),
                    new BitArray( new [] { false, false, false }),
                    new BitArray( new [] { true, true, true }),
                    new BitArray( new [] { false, false, true })
                }),

                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { false, false, true }),
                    new BitArray( new [] { true, true, true }),
                    new BitArray( new [] { false, false, false }),
                    new BitArray( new [] { true, true, false })
                })
        };

        yield return new object[]
        {
                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { true, true, false }),
                    new BitArray( new [] { false, false, false }),
                    new BitArray( new [] { false, false, true })
                }),

                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { false, false, true }),
                    new BitArray( new [] { false, false, false }),
                    new BitArray( new [] { true, true, false })
                })
        };
    }

    public static IEnumerable<object[]> FlipLeftRightData()
    {
        yield return new object[]
        {
                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { true, true, false }),
                    new BitArray( new [] { false, false, false }),
                    new BitArray( new [] { true, false, true }),
                    new BitArray( new [] { true , false, false })
                }),

                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { false, true, true}),
                    new BitArray( new [] { false, false, false }),
                    new BitArray( new [] { true, false, true }),
                    new BitArray( new [] { false, false, true })
                })
        };

        yield return new object[]
        {
                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { true, true, false, false }),
                    new BitArray( new [] { false, false, true, false }),
                    new BitArray( new [] { false, true, true, true })
                }),

                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { false, false, true, true }),
                    new BitArray( new [] { false, true, false, false }),
                    new BitArray( new [] { true, true, true, false })
                })
        };
    }

    public static IEnumerable<object[]> RotateClockwiseData()
    {
        yield return new object[]
        {
                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { true, false, true }),
                    new BitArray( new [] { false, false, false }),
                    new BitArray( new [] { false, false, true })
                }),

                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { false, false, true}),
                    new BitArray( new [] { false, false, false }),
                    new BitArray( new [] { true, false, true })
                })
        };

        yield return new object[]
        {
                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { true, false, true, false }),
                    new BitArray( new [] { false, true, false, true}),
                    new BitArray( new [] { false, false, true, true }),
                    new BitArray( new [] { true, true, false, true })
                }),

                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { true, false, false, true }),
                    new BitArray( new [] { true, false, true, false }),
                    new BitArray( new [] { false, true, false, true }),
                    new BitArray( new [] { true, true, true, false })
                })
        };
    }

    public static IEnumerable<object[]> RotateAnticlockwiseData()
    {
        yield return new object[]
        {
                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { false, false, true}),
                    new BitArray( new [] { false, false, false }),
                    new BitArray( new [] { true, false, true })
                }),

                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { true, false, true }),
                    new BitArray( new [] { false, false, false }),
                    new BitArray( new [] { false, false, true })
                })
        };

        yield return new object[]
        {
                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { true, false, false, true }),
                    new BitArray( new [] { true, false, true, false }),
                    new BitArray( new [] { false, true, false, true }),
                    new BitArray( new [] { true, true, true, false })
                }),

                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { true, false, true, false }),
                    new BitArray( new [] { false, true, false, true}),
                    new BitArray( new [] { false, false, true, true }),
                    new BitArray( new [] { true, true, false, true })
                })
        };
    }

    public static IEnumerable<object[]> Rotate180Data()
    {
        yield return new object[]
        {
                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { false, false, true}),
                    new BitArray( new [] { false, false, false }),
                    new BitArray( new [] { true, false, true })
                }),

                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { true, false, true }),
                    new BitArray( new [] { false, false, false }),
                    new BitArray( new [] { true, false, false })
                })
        };

        yield return new object[]
        {
                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { true, false, false, false }),
                    new BitArray( new [] { true, false, true, false }),
                    new BitArray( new [] { false, true, false, true }),
                    new BitArray( new [] { true, true, true, false })
                }),

                new BitMatrix(new List<BitArray>
                {
                    new BitArray( new [] { false, true, true, true}),
                    new BitArray( new [] { true, false, true, false}),
                    new BitArray( new [] { false, true, false, true }),
                    new BitArray( new [] { false, false, false, true })
                })
        };
    }
}
