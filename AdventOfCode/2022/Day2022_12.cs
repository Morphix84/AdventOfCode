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

    int Start = 0;
    int End = 0;

    Graphalo.DirectedGraph<int> Graph = new Graphalo.DirectedGraph<int>();


    void BuildGraph()
    {
        var graph = new Graphalo.DirectedGraph<int>();

        for (int y = 0; y < _input.Length; y++)
        {
            var line = _input[y];
            for (int x = 0; x < line.Length; x++)
            {
                graph.AddVertex(GetIndex(x, y));
            }
        }

        for (int y = 0; y < _input.Length; y++)
        {
            var line = _input[y];
            for (int x = 0; x < line.Length; x++)
            {
                char c = _input[y][x];
                int index = GetIndex(x, y);
                if (c == 'S') 
                {
                    Start = index;
                }
                else if (c == 'E')
                {
                    End = index;
                }
                var height = GetHeight(c);

                if(x != 0 && Math.Abs(GetHeight(x-1, y) - height) <= 1)
                {
                    int index2 = GetIndex(x - 1, y);
                    graph.AddEdge(new Graphalo.Edge<int>(index, index2));
                    //graph.AddEdge(new Graphalo.Edge<int>(index2, index));
                }

                if (x != (_input[0].Length - 1) && Math.Abs(GetHeight(x + 1, y) - height) <= 1)
                {
                    int index2 = GetIndex(x + 1, y);
                    graph.AddEdge(new Graphalo.Edge<int>(index, index2));
                    //graph.AddEdge(new Graphalo.Edge<int>(index2, index));
                }

                if (y != 0 && Math.Abs(GetHeight(x, y-1) - height) <= 1)
                {
                    int index2 = GetIndex(x, y-1);
                    graph.AddEdge(new Graphalo.Edge<int>(index, index2));
                    //graph.AddEdge(new Graphalo.Edge<int>(index2, index));
                }

                if (y != (_input.Length - 1) && Math.Abs(GetHeight(x, y+1) - height) <= 1)
                {
                    int index2 = GetIndex(x, y+1);
                    graph.AddEdge(new Graphalo.Edge<int>(index, index2));
                    //graph.AddEdge(new Graphalo.Edge<int>(index2, index));
                }

            }
        }

        Graph = graph;
    }

    int GetHeight(int x, int y)
    {
        char c = _input[y][x];
        return GetHeight(c);
    }
    int GetHeight(char c)
    {
        if (c == 'S' )
            return 0;
        if (c == 'E' )
            return 'z' - 'a' + 1;
        return c - 'a' + 1;
    }

    int GetIndex(int x, int y)
    {
        return (x + (y * _input[0].Length));
    }

    public override ValueTask<string> Solve_1()
    {
        var result = Graph.Traverse(Graphalo.Traversal.TraversalKind.Dijkstra, Start, End);
        foreach (var e in Graph.AllEdges)
        {
            Console.WriteLine("From {0} to {1}", e.From.ToString(), e.To.ToString());
        }
        var length = result.Results.Count() - 1;
        return new ValueTask<string>(length.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var monkeyBusiness = "";
        return new ValueTask<string>(monkeyBusiness.ToString());
    }

}
