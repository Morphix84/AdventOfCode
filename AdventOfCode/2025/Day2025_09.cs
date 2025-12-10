using SheepTools;
using SheepTools.Extensions;
using Spectre.Console;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day2025_09 : BaseDay
{
    List<(int, int)> Coords = new List<(int, int)>();
   
    public Day2025_09()
    {
        ParseInput();
    }
    private void ParseInput()
    {
        foreach(var line in _input)
        {
            var s = line.Split(',');
            var coord = (int.Parse(s[0]), int.Parse(s[1]));
            Coords.Add(coord);
        }
        
    }

    public override ValueTask<string> Solve_1()
    {
        long largestarea = 0;
        for (int i = 0; i < Coords.Count; i++)
        {
            var c1 = Coords[i];
            for(int j = i+1;  j < Coords.Count; j++)
            {
                var c2 = Coords[j];
                long height = Math.Abs(c1.Item1 - c2.Item1) + 1;
                long width = Math.Abs(c1.Item2 - c2.Item2) + 1;
                long area = height * width;
                if (area > largestarea)
                    largestarea = area;
            }
        }
        

        return new ValueTask<string>(largestarea.ToString());
    }

    Dictionary<(int, int), char> Grid = new Dictionary<(int, int), char>();

    public override ValueTask<string> Solve_2()
    {
        int gridsize = 0;
        foreach(var c in Coords)
        {
            if (c.Item1 > gridsize)
                gridsize = c.Item1;
            if (c.Item2 > gridsize)
                gridsize = c.Item2;
        }

        
        
        int sum = 0;

        (int, int) Last = Coords[0];
        Grid[(Last.Item1, Last.Item2)] = 'R';
        for (int i = 1; i < Coords.Count; i++)
        {
            var Current = Coords[i];
            Grid[(Current.Item1, Current.Item2)] = 'R';
            LineFill(Current, Last, 'G');
            Last = Current;
        }
        LineFill(Coords[0], Coords[Coords.Count - 1], 'G');

        long largestarea = 0;
        for (int i = 0; i < Coords.Count; i++)
        {
            Console.WriteLine(i.ToString());
            var c1 = Coords[i];
            for (int j = i + 1; j < Coords.Count; j++)
            {
                var c2 = Coords[j];
                if (IsValid3(c1, c2))
                {
                    long height = Math.Abs(c1.Item1 - c2.Item1) + 1;
                    long width = Math.Abs(c1.Item2 - c2.Item2) + 1;
                    long area = height * width;
                    if (area > largestarea)
                        largestarea = area;
                }
            }
        }


        //var dir1 = (Coords[0].Item1 + 1, Coords[0].Item2);
        //var dir2 = (Coords[0].Item1 - 1, Coords[0].Item2);
        //var dir3 = (Coords[0].Item1, Coords[0].Item2 + 1);
        //var dir4 = (Coords[0].Item1, Coords[0].Item2 - 1);
        //if(!Grid.ContainsKey(dir1))
        //{
        //    FloodFill(dir1, 'B', gridsize);
        //}
        //if (!Grid.ContainsKey(dir2))
        //{
        //    FloodFill(dir2, 'W', gridsize);
        //}
        //if (!Grid.ContainsKey(dir3))
        //{
        //    FloodFill(dir3, 'U', gridsize);
        //}
        //if (!Grid.ContainsKey(dir4))
        //{
        //    FloodFill(dir4, 'O', gridsize);
        //}

        //long largestarea = 0;
        //for (int i = 0; i < Coords.Count; i++)
        //{
        //    var c1 = Coords[i];
        //    for (int j = i + 1; j < Coords.Count; j++)
        //    {
        //        var c2 = Coords[j];
        //        if(IsValid(c1, c2))
        //        {
        //            long height = Math.Abs(c1.Item1 - c2.Item1) + 1;
        //            long width = Math.Abs(c1.Item2 - c2.Item2) + 1;
        //            long area = height * width;
        //            if (area > largestarea)
        //                largestarea = area;
        //        }
        //    }
        //}


        return new ValueTask<string>(largestarea.ToString());
    }

    private bool IsValid3((int, int) First, (int, int) Second)
    {
        bool charFound = false;
        char c = '?';
        int x1 = Math.Min(First.Item1, Second.Item1);
        int x2 = Math.Max(First.Item1, Second.Item1);
        int y1 = Math.Min(First.Item2, Second.Item2);
        int y2 = Math.Max(First.Item2, Second.Item2);
        for(int x = x1 + 1; x < x2; x++)
        {
            if (Grid.ContainsKey((x, y1+1)))
            {
                return false;
            }
            if (Grid.ContainsKey((x, y2 - 1)))
            {
                return false;
            }
        }

        for (int y = y1 + 1; y < y2; y++)
        {
            if (Grid.ContainsKey((x1+1, y)))
            {
                return false;
            }
            if (Grid.ContainsKey((x2-1, y)))
            {
                return false;
            }
        }


        return true;
    }

    private bool IsValid2((int, int) First, (int, int) Second)
    {
        bool charFound = false;
        char c = '?';
        int x1 = Math.Min(First.Item1, Second.Item1);
        int x2 = Math.Max(First.Item1, Second.Item1);
        int y1 = Math.Min(First.Item2, Second.Item2);
        int y2 = Math.Max(First.Item2, Second.Item2);
        x1++;
        x2--;
        y1++;
        y2--;

        for (int x = x1; x <= x2; x++)
        {
            for (int y = y1; y <= y2; y++)
            {
                if (Grid.ContainsKey((x, y)))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private bool IsValid((int,int) First, (int,int) Second)
    {
        bool charFound = false;
        char c = '?';
        int x1 = Math.Min(First.Item1, Second.Item1);
        int x2 = Math.Max(First.Item1, Second.Item1);
        int y1 = Math.Min(First.Item2, Second.Item2);
        int y2 = Math.Max(First.Item2, Second.Item2);
        
        for(int x = x1; x <= x2; x++)
        {
            for(int y = y1; y <= y2; y++)
            {
                if (!Grid.ContainsKey((x,y)))
                {
                    return false;
                }
                char thischar = Grid[(x, y)];
                if(thischar != 'R' && thischar != 'G')
                {
                    if(!charFound)
                    {
                        charFound = true;
                        c = thischar;
                    }
                    else if (c != thischar)
                    {
                        return false;
                    }
                }
            }
        }
       
        return true;
    }

    private void FloodFill((int,int) Point, char c, int limit)
    {
        List<(int, int)> newPoints = new List<(int, int)>();
        newPoints.Add(Point);

        while (newPoints.Count > 0)
        {
            var point = newPoints[0];
            newPoints.RemoveAt(0);

            if (Grid.ContainsKey(point))
                continue;
            else if (point.Item1 > limit || point.Item2 > limit || point.Item1 < 0 || point.Item2 < 0)
                continue;

            Grid[point] = c;

            var dir1 = (point.Item1 + 1, point.Item2);
            var dir2 = (point.Item1 - 1, point.Item2);
            var dir3 = (point.Item1, point.Item2 + 1);
            var dir4 = (point.Item1, point.Item2 - 1);

            newPoints.Add(dir1);
            newPoints.Add(dir2);
            newPoints.Add(dir3);
            newPoints.Add(dir4);
        }
        
        
    }

    private void LineFill((int, int) First, (int, int) Second, char c)
    {
        if(First.Item1 == Second.Item1)
        {
            //Horizontal
            if(First.Item2 <  Second.Item2)
            {
                for(int i = First.Item2 + 1; i < Second.Item2; i++)
                {
                    Grid[(First.Item1, i)] = 'G';
                }
            }
            else
            {
                for (int i = Second.Item2 + 1; i < First.Item2; i++)
                {
                    Grid[(First.Item1, i)] = 'G';
                }
            }
        }
        else if (First.Item2 == Second.Item2)
        {
            //Vertical
            if (First.Item1 < Second.Item1)
            {
                for (int i = First.Item1 + 1; i < Second.Item1; i++)
                {
                    Grid[(i, First.Item2)] = 'G';
                }
            }
            else
            {
                for (int i = Second.Item1 + 1; i < First.Item1; i++)
                {
                    Grid[(i, First.Item2)] = 'G';
                }
            }
        }
        else
        {
            throw new NotFiniteNumberException();
        }
    }
}
