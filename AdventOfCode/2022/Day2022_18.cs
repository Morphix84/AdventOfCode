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

public class Day2022_18 : BaseDay
{
    HashSet<(int, int, int)> cubes = new();
    HashSet<(int, int, int)> air = new();

    const int minBounds = -5;
    const int maxBounds = 50;

    void MakeCubes()
    {
        cubes = new();

        foreach (var line in _input)
        {
            var split = line.Split(',');
            int x = int.Parse(split[0]);
            int y = int.Parse(split[1]);
            int z = int.Parse(split[2]);
            cubes.Add(new(x, y, z));
        }
    }

    List<(int, int, int)> nextAir = new();

    void AddCubeToCheck((int, int, int) cube)
    {
        if (air.Contains(cube) || cubes.Contains(cube) || nextAir.Contains(cube))
        {
            return;
        }

        if (cube.Item1 > minBounds && cube.Item1 < maxBounds &&
                cube.Item2 > minBounds && cube.Item2 < maxBounds &&
                cube.Item3 > minBounds && cube.Item3 < maxBounds)
        {
            nextAir.Add(cube);
        }
    }
    void MakeAir()
    {
        if (cubes.Count == 0) throw new InvalidOperationException();

        nextAir.Add(new(0, 0, 0));
        while (nextAir.Count > 0)
        {
            var cube = nextAir[0];
            nextAir.RemoveAt(0);
            if (air.Contains(cube))
            {
                continue;
            }
            if (cube.Item1 > minBounds && cube.Item1 < maxBounds &&
                cube.Item2 > minBounds && cube.Item2 < maxBounds &&
                cube.Item3 > minBounds && cube.Item3 < maxBounds)
            {
                air.Add(cube);
            }

            var list = MakeSides(cube);
            foreach (var side in list)
            {
                AddCubeToCheck(side);
            }
        }
    }

    List<(int, int, int)> MakeSides((int, int, int) cube)
    {
        List<(int, int, int)> list = new();
        list.Add(new(cube.Item1 - 1, cube.Item2, cube.Item3));
        list.Add(new(cube.Item1 + 1, cube.Item2, cube.Item3));
        list.Add(new(cube.Item1, cube.Item2 + 1, cube.Item3));
        list.Add(new(cube.Item1, cube.Item2 - 1, cube.Item3));
        list.Add(new(cube.Item1, cube.Item2, cube.Item3 + 1));
        list.Add(new(cube.Item1, cube.Item2, cube.Item3 - 1));
        return list;
    }
    public override ValueTask<string> Solve_1()
    {
        MakeCubes();

        int faces = 0;

        foreach (var cube in cubes)
        {
            var sideCubes = MakeSides(cube);

            int val = 6;
            foreach (var side in sideCubes)
            {
                if (cubes.Contains(side)) val--;
            }
            faces += val;
        }


        return new ValueTask<string>(faces.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        MakeCubes();
        MakeAir();
        int faces = 0;

        foreach (var cube in cubes)
        {
            var sides = MakeSides(cube);

            int val = 0;
            foreach (var side in sides)
            {
                if (air.Contains(side)) val++;
            }
            faces += val;
        }

        return new ValueTask<string>(faces.ToString());
    }

}
