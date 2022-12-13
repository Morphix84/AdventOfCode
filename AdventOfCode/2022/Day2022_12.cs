using Dijkstra.NET.Graph.Simple;
using Dijkstra.NET.ShortestPath;
using Microsoft.VisualBasic.FileIO;
using SheepTools;
using SheepTools.Model;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode;

public class Day2022_12 : BaseDay
{
    public Day2022_12()
    {
        BuildGraph();
    }

    uint Start = 0;
    uint End = 0;

    Graph Graph = new Graph();

    void BuildGraph()
    {
        var graph = new Graph();

        for (int y = 0; y < _input.Length; y++)
        {
            var line = _input[y];
            for (int x = 0; x < _input.Length; x++)
            {
                graph.AddNode();
            }
        }

        for (int y = 0; y < _input.Length; y++)
        {
            var line = _input[y];
            for (int x = 0; x < _input.Length; x++)
            {
                char c = _input[y][x];
                uint index = (uint)(x + 1 + (y * _input[0].Length));
                if (c == 'S') 
                {
                    Start = index;
                }
                else if (c == 'E')
                {
                    End = index;
                }
                var height = GetHeight(c);

                if(x != 0 && Math.Abs(GetHeight(_input[y][x - 1]) - height) <= 1)
                {
                    uint index2 = (uint)((x-1) + 1 + (y * _input[0].Length));
                    graph.Connect(index, index2);
                    graph.Connect(index2, index);
                }

                if (x != (_input[0].Length - 1) && Math.Abs(GetHeight(_input[y][x + 1]) - height) <= 1)
                {
                    uint index2 = (uint)((x + 1) + 1 + (y * _input[0].Length));
                    graph.Connect(index, index2);
                    graph.Connect(index2, index);
                }

                if (y != 0 && Math.Abs(GetHeight(_input[y-1][x]) - height) <= 1)
                {
                    uint index2 = (uint)(x + 1 + ((y-1) * _input[0].Length));
                    graph.Connect(index, index2);
                    graph.Connect(index2, index);
                }

                if (y != (_input.Length - 1) && Math.Abs(GetHeight(_input[y+1][x]) - height) <= 1)
                {
                    uint index2 = (uint)(x + 1 + ((y+1) * _input[0].Length));
                    graph.Connect(index, index2);
                    graph.Connect(index2, index);
                }

            }
        }

        Graph = graph;
    }

    int GetHeight(char c)
    {
        return c == 'S' || c == 'E' ? 0 : c - 'a';
    }

    public override ValueTask<string> Solve_1()
    {
        var path = Graph.Dijkstra(Start, End);
        
        return new ValueTask<string>(path.Distance.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var monkeyBusiness = "";
        return new ValueTask<string>(monkeyBusiness.ToString());
    }

}
