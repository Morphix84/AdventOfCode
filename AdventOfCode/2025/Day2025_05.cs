using SheepTools.Extensions;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day2025_05 : BaseDay
{
    
    List<(long, long)> Fresh = new List<(long, long)> ();
    Dictionary<long, bool> Available = new Dictionary<long, bool>();
    public Day2025_05()
    {
        ParseInput();
    }
    private void ParseInput()
    {
       bool inSecondHalf = false;
       foreach(var line in _input)
        {
            if(line.IsEmpty())
            {
                inSecondHalf = true;
                continue;
            }
            if (!inSecondHalf)
            {
                var l = line.Split('-');
                Fresh.Add((long.Parse(l[0]), long.Parse(l[1])));
            }
            else
            {
                Available.Add(long.Parse(line), false);
            }
        }
    }

    public override ValueTask<string> Solve_1()
    {
        int sum = 0;

        foreach(var ingredient in Available.Keys)
        {
            foreach(var pair in Fresh)
            {
                if(ingredient >= pair.Item1 && ingredient <= pair.Item2)
                {
                    sum++;
                    break;
                }
            }
        }
        
        return new ValueTask<string>(sum.ToString());
    }

   

    public override ValueTask<string> Solve_2()
    {
        List<Tuple<long, long>> ExcFresh = new List<Tuple<long, long>>();
        
        for(int i = 0; i < Fresh.Count; i++)
        {
            bool isConsistent = false;
            ExcFresh.Add(new Tuple<long, long>(Fresh[i].Item1, Fresh[i].Item2));
            ExcFresh.Sort();
            while (!isConsistent)
            {
                isConsistent = true;
                long last = 0;
                for(int j = 0; j < ExcFresh.Count(); j++)
                {
                    if (ExcFresh[j].Item1 <= last)
                    {
                        isConsistent = false;
                        ExcFresh[j] = new Tuple<long, long>(last + 1, ExcFresh[j].Item2);
                    }

                    if (!(ExcFresh[j].Item1 > ExcFresh[j].Item2))
                    {                   
                        last = ExcFresh[j].Item2;
                    }
                }
                ExcFresh.Sort();
            }
            ExcFresh.RemoveAll(x => x.Item2 < x.Item1);

        }

        long sum = 0;
        foreach (var excPair in ExcFresh)
        {
            sum += excPair.Item2 - excPair.Item1 + 1;
        }
        return new ValueTask<string>(sum.ToString());
    }
}
