using SheepTools.Extensions;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day2025_03 : BaseDay
{
    //private List<string> _ranges = new List<Tuple<long, long>>();
    public Day2025_03()
    {
        ParseInput();
    }
     
    private void ParseInput()
    {
        //for(int j = 0; j < _input.Length; j++)
        //{
        //    string[] ranges = _input[j].Split(',');
        //    for (int i = 0; i < ranges.Length; i++)
        //    {
        //        if (ranges[i].IsEmpty())
        //            continue;
        //        string[] ids = ranges[i].Split('-');
        //        long first = long.Parse(ids[0]);
        //        long last = long.Parse(ids[1]);
        //        _ranges.Add(Tuple.Create(first, last));
        //    }
        //}


    }

    public override async ValueTask<string> Solve_1()
    {
        long sum = 0;
        foreach(var bank in _input)
        {
            int first = 0;
            int second = 0;
            int highest = 0;
            for(int i = 0; i < bank.Length; i++)
            {
                int val = int.Parse(bank[i].ToString());
                if(val > first)
                {
                    if(i < bank.Length - 1)
                    {
                        first = val;
                        second = 0;
                    }
                    else if(val > second)
                    {
                        second = val;
                    }
                }
                else if (val > second)
                {
                    second = val;
                }

            }
            sum += first * 10 + second;
        }

        return sum.ToString();// new ValueTask<string>(sum.ToString());
    }

   

    public override ValueTask<string> Solve_2()
    {
        System.Numerics.BigInteger sum = 0;
        foreach (var bank in _input)
        {
            int[] digits = new int[12];
            int minIndexToEval = bank.Length - 12;

            for (int i = 0; i < bank.Length; i++)
            {
                int val = int.Parse(bank[i].ToString());
                int j = 0;
                if(i > minIndexToEval)
                {
                    j += i - minIndexToEval;
                }
                for(; j < 12; j++)
                {
                    if (val > digits[j])
                    {
                        digits[j] = val;
                        for(int k = j+1; k < 12;k++)
                        { digits[k] = 0; }
                        break;
                    }
                }

                //Length 15
                //can mod 0 on 0, 1, 2, 3
                // Length - 12 = 3 <-last index we can do 0
            }
            System.Numerics.BigInteger mult = new System.Numerics.BigInteger();
            mult = 100000000000;
            for(int i = 0;i < 12;i++)
            {
                sum += mult * digits[i];
                mult /= 10;
            }
            
        }

        return new ValueTask<string>(sum.ToString());
    }
}
