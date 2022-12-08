namespace AdventOfCode;



public class Day2022_08 : BaseDay
{
    public Day2022_08()
    {
        var y = _input.Length;
        var x = _input[0].Length;
        array = new int[x,y];
        visibleArray = new bool[x,y];
    }

    bool[,] visibleArray;
    int[,] array;

    const int arraySize = 99;
    public override ValueTask<string> Solve_1()
    {
        LoadArray();
        
        for(int l = 0; l < 50; l++)
        {
            var top = l;
            var bot = arraySize - l - 1;
            var left = l;
            var right = arraySize - l - 1;
            var width = arraySize - 2 * l;
            
            for(var i = left; i <= right; i++)
            {
                CheckVis(i, top);
                CheckVis(i, bot);
                CheckVis(left, i);
                CheckVis(right, i);
            }
        }
        int total = 0;
        for(int i = 0; i < arraySize; i++)
        {
            for(int j = 0; j < arraySize; j++)
            {
                if (visibleArray[i, j])
                    total++;
            }
        }
        
        
        return new ValueTask<string>(total.ToString());
    }

    void LoadArray()
    {
        for(int y = 0; y < arraySize; y++)
        {
            string inp = _input[y];
            for (int x = 0; x < arraySize; x++)
            {
                char c = inp[x];
                array[x, y] = int.Parse(c.ToString());
            }
        }
    }

    void CheckVis(int x, int y)
    {
        int val = array[x, y];
        if (x == 0 || y == 0 || x == arraySize-1 || y == arraySize - 1)
        {
            visibleArray[x, y] = true;
            return;
        }
        else if(array[x, y - 1] < val && visibleArray[x, y - 1])
        {
            visibleArray[x, y] = true;
            return;
        }
        else if (array[x, y + 1] < val && visibleArray[x, y + 1])
        {
            visibleArray[x, y] = true;
            return;
        }
        else if (array[x+1, y] < val && visibleArray[x+1, y])
        {
            visibleArray[x, y] = true;
            return;
        }
        else if (array[x-1, y] < val && visibleArray[x-1, y])
        {
            visibleArray[x, y] = true;
            return;
        }

        visibleArray[x,y] = false;

    }


    public override ValueTask<string> Solve_2()
    {
        int best = 0;

        return new ValueTask<string>(best.ToString());
    }

}
