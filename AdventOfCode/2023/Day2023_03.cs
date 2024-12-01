namespace AdventOfCode;

public class Day2023_03 : BaseDay
{
    public Day2023_03()
    {
        ParseInput();
    }

    private void ParseInput()
    {
    }

    public override ValueTask<string> Solve_1()
    {
        int total = 0;

        for(int y = 0; y < _input.Length; y++)
        {
            int x = 0;
            string s = _input[y];
            while (x < s.Length)
            {
                if (s[x] < '0' || s[x] > '9')
                {
                    x++;
                    continue;
                }

                //Found a number
                int i = GetNumberLength(x, y);
                total += ProcessNumber(x, y, i);

                x += i;

            }
        }

        return new ValueTask<string>(total.ToString());
    }

    private int ProcessNumber(int x, int y, int length)
    {
        string s = _input[y];
        if (HasSymbol(x,y,length))
        {
            return int.Parse(s.Substring(x, length));
        }
        return 0;

    }

    private bool HasSymbol(int x, int y, int length)
    {
        int x0 = Math.Max(x - 1, 0);
        int x1 = Math.Min(x + length, _input[y].Length - 1);
        int y0 = Math.Max(y - 1, 0);
        int y1 = Math.Min(y + 1, _input.Length - 1);

        for(int k = y0; k <= y1; k++)
        {
            string s = _input[k];
            for (int i = x0; i <= x1; i++)
            {
                if ((s[i] < '0' || s[i] > '9') && s[i] != '.')
                    return true;
            }
        }
        return false;

    }

    private int GetNumberLength(int x, int y)
    {
        int length = 0;
        string s = _input[y];
        while(true)
        {
            if (x == s.Length || s[x] < '0' || s[x] > '9')
            {
                return length;
            }
            length++;
            x++;
        }
    }

    private List<Tuple<int, int>> GetGears()
    {
        List<Tuple<int, int>> gears = new List<Tuple<int, int>>();
        for (int i = 0; i < _input.Length; i++)
        {
            string s = _input[i];
            if (!s.Contains('*'))
                continue;

            for(int k = 0; k < s.Length; k++)
            {
                if (s[k] != '*')
                    continue;

                if (CountSurroundingNumbers(k, i) == 2)
                    gears.Add(Tuple.Create(k, i));
            }
        }
        return gears;

    }

    private int CountSurroundingNumbers(int x, int y)
    {
        int x0 = Math.Max(x - 1, 0);
        int x1 = Math.Min(x + 1, _input[y].Length - 1);
        int y0 = Math.Max(y - 1, 0);
        int y1 = Math.Min(y + 1, _input.Length - 1);
        int count = 0;

        for (int k = y0; k <= y1; k++)
        {
            string s = _input[k];
            for (int i = x0; i <= x1; i++)
            {
                if (s[i] >= '0' && s[i] <= '9')
                    count++;
            }
        }
        return count;
    }

    public override ValueTask<string> Solve_2()
    {
        int total = 0;
        List<Tuple<int, int>> gears = GetGears();

        return new ValueTask<string>(total.ToString());
    }
}
