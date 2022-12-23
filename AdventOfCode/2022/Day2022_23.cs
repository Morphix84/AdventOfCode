using Dijkstra.NET.Graph.Simple;
using Dijkstra.NET.ShortestPath;
using Microsoft.VisualBasic.FileIO;
using SheepTools;
using SheepTools.Extensions;
using SheepTools.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AdventOfCode;



public class Day2022_23 : BaseDay
{
    HashSet<IntPoint> Elves = new();
    Dictionary<IntPoint, IntPoint> proposedMoves = new();
    HashSet<IntPoint> stationaryElves = new();
    HashSet<IntPoint> collisions = new();

    void Init()
    {
        Elves.Clear();
        for (int y = 0; y < _input.Length; y++)
        {
            for (int x = 0; x < _input[0].Length; x++)
            {
                if (_input[y][x] == '#')
                    Elves.Add(new IntPoint(x, y));
            }
        }
    }

    bool IsElfUp(IntPoint x)
    {
        var up = x.Move(Direction.Up);
        if (Elves.Contains(up)) return true;
        else if (Elves.Contains(up.Move(Direction.Left))) return true;
        else if (Elves.Contains(up.Move(Direction.Right))) return true;
        return false;
    }

    bool IsElfDown(IntPoint x)
    {
        var dn = x.Move(Direction.Down);
        if (Elves.Contains(dn)) return true;
        else if (Elves.Contains(dn.Move(Direction.Left))) return true;
        else if (Elves.Contains(dn.Move(Direction.Right))) return true;
        return false;
    }

    bool IsElfRight(IntPoint x)
    {
        var rt = x.Move(Direction.Right);
        if (Elves.Contains(rt)) return true;
        else if (Elves.Contains(rt.Move(Direction.Up))) return true;
        else if (Elves.Contains(rt.Move(Direction.Down))) return true;
        return false;
    }

    bool IsElfLeft(IntPoint x)
    {
        var rt = x.Move(Direction.Left);
        if (Elves.Contains(rt)) return true;
        else if (Elves.Contains(rt.Move(Direction.Up))) return true;
        else if (Elves.Contains(rt.Move(Direction.Down))) return true;
        return false;
    }

    void Propose(IntPoint proposed, IntPoint current)
    {
        if (!proposedMoves.ContainsKey(proposed))
        {
            proposedMoves.Add(proposed, current);
            return;
        }

        stationaryElves.Add(current);
        if (!collisions.Contains(proposed))
        {
            collisions.Add(proposed);
        }

        var existing = proposedMoves[proposed];
        if (!stationaryElves.Contains(existing))
            stationaryElves.Add(existing);
    }

    bool AnyElvesAround(IntPoint e)
    {
        if(IsElfDown(e) || IsElfLeft(e) || IsElfUp(e) || IsElfRight(e)) return true;
        return false;
    }


    (int,int) FindMins()
    {
        int minx = Elves.First().X;
        int miny = Elves.First().Y;
        foreach (var e in Elves)
        {
            minx = Math.Min(minx, e.X);
            miny = Math.Min(miny, e.Y);
        }
        return new(minx, miny);
    }

    (int, int) FindMaxs()
    {
        int maxx = Elves.First().X;
        int maxy = Elves.First().Y;
        foreach (var e in Elves)
        {
            maxx = Math.Max(maxx, e.X);
            maxy = Math.Max(maxy, e.Y);
        }
        return new(maxx, maxy);
    }

    bool Tick(int round)
    {
        stationaryElves.Clear();
        proposedMoves.Clear();
        collisions.Clear();

        foreach (var e in Elves)
        {
            switch (round % 4)
            {
                case 0:
                    if (!AnyElvesAround(e))
                    {
                        stationaryElves.Add(e);
                    }
                    else if (!IsElfUp(e))
                    {
                        Propose(e.Move(Direction.Up), e);
                    }
                    else if (!IsElfDown(e))
                    {
                        Propose(e.Move(Direction.Down), e);
                    }
                    else if (!IsElfLeft(e))
                    {
                        Propose(e.Move(Direction.Left), e);
                    }
                    else if (!IsElfRight(e))
                    {
                        Propose(e.Move(Direction.Right), e);
                    }
                    else
                    {
                        stationaryElves.Add(e);
                    }
                    break;
                case 1:
                    if (!AnyElvesAround(e))
                    {
                        stationaryElves.Add(e);
                    }
                    else if (!IsElfDown(e))
                    {
                        Propose(e.Move(Direction.Down), e);
                    }
                    else if (!IsElfLeft(e))
                    {
                        Propose(e.Move(Direction.Left), e);
                    }
                    else if (!IsElfRight(e))
                    {
                        Propose(e.Move(Direction.Right), e);
                    }
                    else if (!IsElfUp(e))
                    {
                        Propose(e.Move(Direction.Up), e);
                    }
                    else
                    {
                        stationaryElves.Add(e);
                    }
                    break;
                case 2:
                    if (!AnyElvesAround(e))
                    {
                        stationaryElves.Add(e);
                    }
                    else if (!IsElfLeft(e))
                    {
                        Propose(e.Move(Direction.Left), e);
                    }
                    else if (!IsElfRight(e))
                    {
                        Propose(e.Move(Direction.Right), e);
                    }
                    else if (!IsElfUp(e))
                    {
                        Propose(e.Move(Direction.Up), e);
                    }
                    else if (!IsElfDown(e))
                    {
                        Propose(e.Move(Direction.Down), e);
                    }
                    else
                    {
                        stationaryElves.Add(e);
                    }
                    break;
                case 3:
                    if (!AnyElvesAround(e))
                    {
                        stationaryElves.Add(e);
                    }
                    else if (!IsElfRight(e))
                    {
                        Propose(e.Move(Direction.Right), e);
                    }
                    else if (!IsElfUp(e))
                    {
                        Propose(e.Move(Direction.Up), e);
                    }
                    else if (!IsElfDown(e))
                    {
                        Propose(e.Move(Direction.Down), e);
                    }
                    else if (!IsElfLeft(e))
                    {
                        Propose(e.Move(Direction.Left), e);
                    }
                    else
                    {
                        stationaryElves.Add(e);
                    }
                    break;
            }
        }

        proposedMoves.RemoveAll(x => collisions.Contains(x.Key));
        Elves.Clear();
        bool didAnyoneMove = proposedMoves.Count != 0;
        Elves.AddRange(proposedMoves.Keys);
        Elves.AddRange(stationaryElves);
        return didAnyoneMove;
    }
    int FindBoundary()
    {
        (int x, int y) mins = FindMins();
        (int x, int y) maxs = FindMaxs();
        int Y = maxs.y - mins.y + 1;
        int X = maxs.x - mins.x + 1;
        return (X * Y) - Elves.Count;
    }
    public override ValueTask<string> Solve_1()
    {
        Init();
        for (int i = 0; i < 10; i++)
        {
            Tick(i);
            Console.WriteLine("After " + (i + 1) + " rounds");
        }

        int sum = FindBoundary();
        return new ValueTask<string>(sum.ToString());
    }
    public override ValueTask<string> Solve_2()
    {
        Init();
        int i = 0;
        while (Tick(i)) { i++; }
        i++;
        return new ValueTask<string>(i.ToString());
    }

    void PrintMap()
    {
        (int x, int y) mins = FindMins();
        (int x, int y) maxs = FindMaxs();
        for (int y = mins.y; y <= maxs.y; y++)
        {
            for (int x = mins.x; x <= maxs.x; x++)
            {
                if (Elves.Contains(new IntPoint(x, y)))
                    Console.Write("#");
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }

    }

}
