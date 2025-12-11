using SheepTools.Extensions;
using System;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day2025_07 : BaseDay
{

    Dictionary<(int,int), char> Grid = new Dictionary<(int,int), char>();
    (int, int) Start;
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

   
    public override ValueTask<string> Solve_2()
    {
       
        BigInteger sum = 0;
       

        return new ValueTask<string>(sum.ToString());
    }
}
