using System.Collections;
using System.Text;

namespace SheepTools.Model;

public class BitMatrix
{
    public List<BitArray> Content { get; set; }

    public BitMatrix(List<BitArray> content)
    {
        Content = content;
    }

    public virtual BitMatrix RotateClockwise()
    {
        var length = Content.Count;
        var result = new List<BitArray>(length);

        for (int i = 0; i < length; ++i)
        {
            result.Add(new BitArray(
                Content.Select(arr => arr[i])
                .Reverse()
                .ToArray()));
        }

        return new BitMatrix(result);
    }

    public virtual BitMatrix RotateAnticlockwise()
    {
        var length = Content[0].Count;
        var result = new List<BitArray>(length);

        for (int i = 0; i < length; ++i)
        {
            result.Add(new BitArray(
                Content.Select(arr => arr[length - i - 1])
                .ToArray()));
        }

        return new BitMatrix(result);
    }

    public virtual BitMatrix Rotate180()
    {
        return FlipUpsideDown().FlipLeftRight();
    }

    public virtual BitMatrix FlipUpsideDown()
    {
        return new BitMatrix(Enumerable.Reverse(Content).ToList());
    }

    public virtual BitMatrix FlipLeftRight()
    {
        var length = Content[0].Count;

        return new BitMatrix(Content.ConvertAll(original =>
        {
            int mid = length / 2;
            var newRow = new BitArray(original);
            for (int i = 0; i < mid; ++i)
            {
                newRow[i] = original[length - i - 1];
                newRow[length - i - 1] = original[i];
            }

            return newRow;
        }));
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (var item in Content)
        {
            foreach (var bit in item)
            {
                sb.Append((bool)bit ? "1" : "0");
            }

            sb.Append(Environment.NewLine);
        }
        sb.Append(Environment.NewLine);

        return sb.ToString();
    }
}
