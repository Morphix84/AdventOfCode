namespace AdventOfCode;



public class Day2022_08 : BaseDay
{
    public Day2022_08()
    {
        var y = _input.Length;
        var x = _input[0].Length;
        array = new int[x, y];
        LoadArray();
    }

    int[,] array;

    const int arraySize = 99;
    public override ValueTask<string> Solve_1()
    {
        var total = 0;
        for (int y = 0; y < arraySize; y++)
        {
            for (int x = 0; x < arraySize; x++)
            {
                if (CheckVis(x, y))
                {
                    total++;
                }
            }
        }

        return new ValueTask<string>(total.ToString());
    }

    void LoadArray()
    {
        for (int y = 0; y < arraySize; y++)
        {
            string inp = _input[y];
            for (int x = 0; x < arraySize; x++)
            {
                char c = inp[x];
                array[x, y] = int.Parse(c.ToString());
            }
        }
    }

    bool CheckVis(int x, int y)
    {
        int val = array[x, y];
        if (x == 0 || y == 0 || x == arraySize - 1 || y == arraySize - 1)
        {
            return true;
        }
        else
        {

            var left = Enumerable.Range(0, x).ToList();
            var up = Enumerable.Range(0, y).ToList();
            var right = Enumerable.Range(x + 1, arraySize - x - 1).ToList();
            var down = Enumerable.Range(y + 1, arraySize - y - 1).ToList();

            var vis = true;
            for (int i = 0; i < left.Count(); i++)
            {
                var index = left[i];
                if (array[index, y] >= val)
                {
                    vis = false;
                    break;
                }
            }
            if (vis)
                return true;

            vis = true;
            for (int i = 0; i < right.Count(); i++)
            {
                var index = right[i];
                if (array[index, y] >= val)
                {
                    vis = false;
                    break;
                }
            }
            if (vis)
                return true;

            vis = true;
            for (int i = 0; i < up.Count(); i++)
            {
                var index = up[i];
                if (array[x, index] >= val)
                {
                    vis = false;
                    break;
                }
            }
            if (vis)
                return true;

            vis = true;
            for (int i = 0; i < down.Count(); i++)
            {
                var index = down[i];
                if (array[x, index] >= val)
                {
                    vis = false;
                    break;
                }
            }
            if (vis)
                return true;

        }

        return false;

    }

    int GetScore(int x, int y)
    {
        int val = array[x, y];
        int lscore = 0;
        int rscore = 0;
        int uscore = 0;
        int dscore = 0;

        var left = Enumerable.Range(0, x).ToList();
        var up = Enumerable.Range(0, y).ToList();
        var right = Enumerable.Range(x + 1, arraySize - x - 1).ToList();
        var down = Enumerable.Range(y + 1, arraySize - y - 1).ToList();

        for (int i = left.Count() - 1; i >= 0; i--)
        {
            var index = left[i];
            lscore++;
            if (array[index, y] >= val)
            {
                break;
            }
        }

        for (int i = 0; i < right.Count(); i++)
        {
            var index = right[i];
            rscore++;
            if (array[index, y] >= val)
            {
                break;
            }
        }

        for (int i = up.Count() - 1; i >= 0; i--)
        {
            var index = up[i];
            uscore++;
            if (array[x, index] >= val)
            {
                break;
            }
        }
        
        for (int i = 0; i < down.Count(); i++)
        {
            var index = down[i];
            dscore++;
            if (array[x, index] >= val)
            {
                break;
            }
        }

        return lscore * rscore * uscore * dscore;
    }
    public override ValueTask<string> Solve_2()
    {
        var best = 0;
        for (int y = 0; y < arraySize; y++)
        {
            for (int x = 0; x < arraySize; x++)
            {
                var score = GetScore(x, y);
                best = Math.Max(best, score);
            }
        }

        return new ValueTask<string>(best.ToString());
    }

}
