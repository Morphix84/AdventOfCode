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

public class Day2022_15 : BaseDay
{
    HashSet<(IntPoint, IntPoint)> beacons = new();
    int MinX = int.MaxValue;
    int MaxX = int.MinValue;
    public Day2022_15()
    {
        ParseBeacons();
    }

    void ParseBeacons()
    {
        foreach(var line in _input)
        {
            var s = line.Split(':');
            var sensor = s[0].Split(',');
            var x = int.Parse(sensor[0].Split('=')[1]);
            var y = int.Parse(sensor[1].Split('=')[1]);
            var beacon = s[1].Substring(24, s[1].Length - 24);
            var bx = int.Parse(beacon.Split(',')[0]);
            var by = int.Parse(beacon.Split('=')[1]);

            var sp = new IntPoint(x, y);
            var bp = new IntPoint(bx, by);

            
            if (x < MinX)
            {
                MinX = x;
                MinX -= (int)sp.ManhattanDistance(bp);
            }
            if (bx < MinX) MinX = bx;

            if (x > MaxX)
            {
                MaxX = x;
                MaxX += (int)sp.ManhattanDistance(bp);
            }
            if (bx > MaxX) MaxX = bx;

            beacons.Add(new(sp, bp));

        }
    }

    public override ValueTask<string> Solve_1()
    {
        //Not 4496912
        //Not 4705930
        //Not 5607467
        var y = 2000000;
        int cannot = 0;
        MinX = -5000000;
        MaxX = 10000000;
        for(int x = MinX; x <= MaxX; x++)
        {
            var point = new IntPoint(x, y);
            foreach(var beaconPair in beacons)
            {
                var sensor = beaconPair.Item1;
                var beacon = beaconPair.Item2;
                if(sensor.ManhattanDistance(point) <= sensor.ManhattanDistance(beacon))
                {
                    cannot++;
                    break;
                }


            }
        }

        return new ValueTask<string>(cannot.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>("".ToString());
    }

}
