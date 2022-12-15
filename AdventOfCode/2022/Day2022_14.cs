using Dijkstra.NET.Graph.Simple;
using Dijkstra.NET.ShortestPath;
using Microsoft.VisualBasic.FileIO;
using SheepTools;
using SheepTools.Model;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AdventOfCode;

public class Day2022_14 : BaseDay
{
    Dictionary<(int, int), char> Map;

    public Day2022_14()
    {
        Scan();
    }
    
    void Scan()
    {
        Map = new Dictionary<(int, int), char>();
        foreach (var line in _input)
        {
            var split = line.Split(" -> ");
            for (int i = 0; i < split.Length - 1; i++)
            {
                Draw(split[i], split[i+ 1]);
            }
        }
        
    }

    void Draw(string from, string to)
    {
        var fromParts = from.Split(',');
        var toParts = to.Split(',');
        var startX = int.Parse(fromParts[0]);
        var startY = int.Parse(fromParts[1]);
        var endX = int.Parse(toParts[0]);
        var endY = int.Parse(toParts[1]);

        if(endX < startX)
        {
            var temp = startX;
            startX = endX;
            endX = temp;
        }
        if (endY < startY)
        {
            var temp = startY;
            startY = endY;
            endY = temp;
        }

        if (startX == endX)
        {
            for (int i = startY; i <= endY; i++)
            {
                Map[(startX, i)] = '█';
            }
        }
        else if (startY == endY)
        {
            for (int i = startX; i <= endX; i++)
            {
                Map[(i, startY)] = '█';
            }
        }
    }

    private bool Tick(int minX, int maxX, int maxY, bool firstStar)
    {
        (int x, int y) = (500, 0);
        bool ended = false;
        bool stopped = false;

        do
        {
            if (!Map.TryGetValue((x, y + 1), out char down)) 
                down = '.';
            if (!Map.TryGetValue((x - 1, y + 1), out char left)) 
                left = '.';
            if (!Map.TryGetValue((x + 1, y + 1), out char right)) 
                right = '.';

            if (firstStar)
            {
                if (minX == x) left = '$';
                if (maxX == x) right = '$';
            }
            if (!firstStar && maxY == y + 1)
            {
                down = '█';
                left = '█'; 
                right = '█';
            }

            if (down == '.')
            {
                y++;
            }
            else if (left == '.')
            {
                y++;
                x--;
            }
            else if (right == '.')
            {
                y++;
                x++;
            }
            else if (left == '$' || right == '$')
            {
                ended = true;
            }
            else
            {
                Map[(x, y)] = 'o';
                stopped = true;
                if (!firstStar && y == 0) 
                    ended = true;
            }
            if (firstStar && y > maxY) 
                ended = true;
        } while (!ended && !stopped);

        return ended;

    }

    public override ValueTask<string> Solve_1()
    {
        Scan();

        int minX = Map.Keys.Select(x => x.Item1).Min();
        int maxX = Map.Keys.Select(x => x.Item1).Max();
        int maxY = Map.Keys.Select(x => x.Item1).Max() + 2;
        
        int totalSand = 0;
        
        bool complete = false;
        while(!complete)
        {
            complete = Tick(minX, maxX, maxY, true);
            if (!complete)
                totalSand++;
        }

        return new ValueTask<string>(totalSand.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        //267718 is too high.
        //267717 is too high.
        //260000 is too high.

        Scan();

        int minX = Map.Keys.Select(x => x.Item1).Min();
        int maxX = Map.Keys.Select(x => x.Item1).Max();
        int maxY = Map.Keys.Select(x => x.Item2).Max() + 2;

        int totalSand = 0;
        bool done = false;

        bool complete = false;
        while (!complete)
        {
            complete = Tick(minX, maxX, maxY, false);
            if (!complete)
                totalSand++;
        }
        totalSand++;

        //F.

        return new ValueTask<string>(totalSand.ToString());
    }

}
