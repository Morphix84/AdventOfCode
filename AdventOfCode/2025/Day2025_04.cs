using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day2025_04 : BaseDay
{
    private List<Tuple<char, int>> _moves = new List<Tuple<char, int>>();
    public Day2025_04()
    {
        ParseInput();
    }
    private void ParseInput()
    {
       
    }

    public override ValueTask<string> Solve_1()
    {
        int sum = 0;
        for (int y = 0; y < _input.Length; y++)
        {
            for (int x = 0; x < _input[y].Length; x++)
            {
                char c = _input[y][x];
                if (c == '@')
                {
                    int count = CountNeighbors(x, y);
                    if (count < 4)
                        sum++;
                }

            }
        }
        return new ValueTask<string>(sum.ToString());
    }

    int CountNeighbors(int x, int y)
    {
        int count = 0;
        List<(int, int)> Neighbors = new List<(int, int)>();
        Neighbors.Add((x - 1, y - 1));
        Neighbors.Add((x - 1, y));
        Neighbors.Add((x - 1, y + 1));
        Neighbors.Add((x, y - 1));
        Neighbors.Add((x, y + 1));
        Neighbors.Add((x + 1, y - 1));
        Neighbors.Add((x + 1, y));
        Neighbors.Add((x + 1, y + 1));

        foreach (var neighbor in Neighbors)
        {
            if (neighbor.Item1 >= 0 && neighbor.Item1 < _input[0].Length && neighbor.Item2 >= 0 && neighbor.Item2 < _input.Length)
            {
                char c = _input[neighbor.Item2][neighbor.Item1];
                if (c == '@')
                {
                    count++;
                }
            }
        }
        return count;

    }

    public override ValueTask<string> Solve_2()
    {
        int sum = 0;
        bool foundmore = true;
        while(foundmore)
        {
            foundmore = false;
            for (int y = 0; y < _input.Length; y++)
            {
                for (int x = 0; x < _input[y].Length; x++)
                {
                    char c = _input[y][x];
                    if (c == '@')
                    {
                        int count = CountNeighbors(x, y);
                        if (count < 4)
                        {
                            sum++;
                            StringBuilder sb = new StringBuilder(_input[y]);
                            sb[x] = '.';
                            _input[y] = sb.ToString();
                            foundmore = true;
                        }
                            
                    }

                }
            }
            
        }
        return new ValueTask<string>(sum.ToString());
    }
}
