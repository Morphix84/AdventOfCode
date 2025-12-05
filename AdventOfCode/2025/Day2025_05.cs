using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day2025_05 : BaseDay
{
    private List<Tuple<char, int>> _moves = new List<Tuple<char, int>>();
    public Day2025_05()
    {
        ParseInput();
    }
    private void ParseInput()
    {
       
    }

    public override ValueTask<string> Solve_1()
    {
        int sum = 0;
        
        return new ValueTask<string>(sum.ToString());
    }

   

    public override ValueTask<string> Solve_2()
    {
        int sum = 0;
       
        return new ValueTask<string>(sum.ToString());
    }
}
