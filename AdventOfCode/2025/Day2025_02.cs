using SheepTools.Extensions;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day2025_02 : BaseDay
{
    private List<Tuple<long, long>> _ranges = new List<Tuple<long, long>>();
    public Day2025_02()
    {
        ParseInput();
    }
     
    private void ParseInput()
    {
        for(int j = 0; j < _input.Length; j++)
        {
            string[] ranges = _input[j].Split(',');
            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i].IsEmpty())
                    continue;
                string[] ids = ranges[i].Split('-');
                long first = long.Parse(ids[0]);
                long last = long.Parse(ids[1]);
                _ranges.Add(Tuple.Create(first, last));
            }
        }


    }

    public override ValueTask<string> Solve_1()
    {
        long sum = 0;
        foreach (var range in _ranges)
        {
            for(long i = range.Item1; i <= range.Item2; i++)
            {
                if(!IsValidSimple(i))
                {
                    sum += i;
                }
            }
        }
        
        return new ValueTask<string>(sum.ToString());
    }

    private bool IsValidSimple(long Value)
    {
        
        string s = Value.ToString();
        if (s.Length%2 != 0)
        {
            return true;
        }
        string one = s.Substring(0, s.Length / 2);
        string two = s.Substring(s.Length / 2, s.Length / 2);
        return !one.Equals(two);
    }
    private bool IsValid(long Value)
    {
        string s = Value.ToString();
        bool isInvalid = false;
        for(int l = 1; l <= s.Length/2; l++)
        {
            if (isInvalid)
                break;
            var divVal = int.DivRem(s.Length, l);
            if (divVal.Remainder != 0)
                continue;

            string one = s.Substring(0, l);
            bool stillmatches = true;
            int offset = l;
            while(offset + l <= s.Length && stillmatches)
            {
                string two = s.Substring(offset, l);
                if(!one.Equals(two))
                {
                    stillmatches = false;
                }
                offset += l;
                
            }
            
            if (stillmatches)
            {
                return false;
            }
            
        }
        return true;
    }

    public override ValueTask<string> Solve_2()
    {
        long sum = 0;
        foreach (var range in _ranges)
        {
            for (long i = range.Item1; i <= range.Item2; i++)
            {
                if (!IsValid(i))
                {
                     sum += i;
                }
            }
        }

        return new ValueTask<string>(sum.ToString());
    }
}
