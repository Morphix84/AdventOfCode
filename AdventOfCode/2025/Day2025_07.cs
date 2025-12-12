using SheepTools.Extensions;
using SheepTools.Model;
using System;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day7Node
{
    public long value = 0;
    public int x;
    public int y;
    public List<Day7Node> Children = new List<Day7Node>();
    public Day7Node(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Day7Node((int,int) coords)
    {
        this.x = coords.Item1;
        this.y = coords.Item2;
    }
}
public class Day2025_07 : BaseDay
{
    
    Dictionary<(int,int), char> Grid = new Dictionary<(int,int), char>();
    Dictionary<(int, int), Day7Node> Tree = new Dictionary<(int, int), Day7Node>();
    (int, int) Start;
    Day7Node StartNode;
    public Day2025_07()
    {
        ParseInput();
    }
    private void ParseInput()
    {
        int y = 0;
        foreach (var line in _input)
        {
            for(int x = 0; x < line.Length; x++)
            {
                char current = line[x];
                Grid[(x,y)] = current;
                if (current == 'S')
                {
                    Start = (x, y);
                    StartNode = new Day7Node((x,y));
                    Tree.Add((x, y), StartNode);
                }
                else if (current == '^')
                {
                    var thisNode = new Day7Node((x, y));
                    Tree.Add((x, y), thisNode);

                    if (y == _input.Length - 1)
                    {
                        thisNode.value = 2;
                    }
                }
            }
            y++;
           
        }
    }

    public override ValueTask<string> Solve_1()
    {
        List<(int,int)> Beams = new List<(int,int)> ();
        List<(int, int)> ProcessedBeams = new List<(int, int)>();
        Beams.Add(Start);
        int sum = 0;

        while(Beams.Count > 0)
        {
            var Beam = Beams[0];
            
            Beams.RemoveAt(0);
            if (!Grid.ContainsKey(Beam))
                continue;
            if (ProcessedBeams.Contains(Beam))
                continue;
            ProcessedBeams.Add(Beam);

            if (Grid[Beam] == '^')
            {
                //Split
                sum++;
                var left = (Beam.Item1 - 1, Beam.Item2);
                var right = (Beam.Item1 + 1, Beam.Item2);

                if(!Beams.Contains(left) && !ProcessedBeams.Contains(left))
                    Beams.Add(left);
                if(!Beams.Contains(right) && !ProcessedBeams.Contains(right))
                    Beams.Add(right);
            }
            else if (Beam.Item2 > _input.Length)
            {
                //Off the bottom.
            }
            else
            {
                //Keep going down.
                Beams.Add((Beam.Item1, Beam.Item2 + 1));
            }
            
        }
        
        return new ValueTask<string>(sum.ToString());
    }

    private void MapTree()
    {
        foreach(var node in Tree)
        {
            if (node.Value.value != 0)
                return;
            var left = (node.Key.Item1 - 1, node.Key.Item2);
            var right = (node.Key.Item1 + 1, node.Key.Item2);
            bool found = false;
            while (!found)
            {
                if (left.Item2 > _input.Length)
                    found = true;
                if(Tree.ContainsKey(left))
                {
                    node.Value.Children.Add(Tree[left]);
                    found = true;
                }
                else
                {
                    left = (left.Item1, left.Item2 + 1);
                }
            }
            found = false;
            while (!found)
            {
                if (right.Item2 > _input.Length)
                    found = true;
                if (Tree.ContainsKey(right))
                {
                    node.Value.Children.Add(Tree[right]);
                    found = true;
                }
                else
                {
                    right = (right.Item1, right.Item2 + 1);
                }
            }
        }

        foreach(var node in Tree)
        {
            if (node.Value.Children.Count == 0)
                node.Value.value = 2;
        }

        bool fullyMapped = false;
        while(!fullyMapped)
        {
            fullyMapped = true;
            for (int i = Tree.Count - 1; i >= 0; i--)
            {
                var thisNode = Tree.Values.ToArray()[i];
                if(thisNode.value == 0)
                {
                    fullyMapped = false;
                    long val = 0;
                    foreach(var child in thisNode.Children)
                    {
                        val += child.value;
                    }
                    thisNode.value = val + (2-thisNode.Children.Count);
                }
            }
        }

    }
   
    public override ValueTask<string> Solve_2()
    {
        MapTree();

        long sum = StartNode.value;

        return new ValueTask<string>(sum.ToString());
    }
}
