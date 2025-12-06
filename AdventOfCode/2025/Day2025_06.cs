using SheepTools.Extensions;
using System;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day2025_06 : BaseDay
{

    List<char> Operators = new List<char>();
    List<List<int>> Nums = new List<List<int>>();
    List<List<char>> RawGrid = new List<List<char>>();
    List<int> OperatorIndexes = new List<int>();

    public Day2025_06()
    {
        ParseInput();
    }
    private void ParseInput()
    {

        foreach (var line in _input)
        {
            List<char> Row = new List<char>();
            foreach (char c in line)
            {
                Row.Add(c);
            }
            RawGrid.Add(Row);

            if (line[0] == '*' || line[0] == '+')
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '*' || line[i] == '+')
                        OperatorIndexes.Add(i);
                }

            }

            List<int> nums = new List<int>();

            var parts = line.Split(' ');
            foreach (var part in parts)
            {
                if (part.IsWhiteSpace() || part.IsEmpty())
                    continue;

                int result;
                if (int.TryParse(part, out result))
                { nums.Add(result); }
                else
                {
                    Operators.Add(part[0]);
                }
            }
            if (nums.Count > 0)
                Nums.Add(nums);
        }
    }

    public override ValueTask<string> Solve_1()
    {
        List<BigInteger> Results = new List<BigInteger>();
        for (int i = 0; i < Operators.Count; i++)
        {
            BigInteger Result = new BigInteger();
            switch (Operators[i])
            {
                case '+':
                    for (int j = 0; j < Nums.Count; j++)
                    {
                        Result += Nums[j][i];
                    }
                    break;
                case '*':
                    Result = 1;
                    for (int j = 0; j < Nums.Count; j++)
                    {
                        Result *= Nums[j][i];
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
            Results.Add(Result);
        }
        BigInteger sum = 0;
        foreach (var b in Results)
        {
            sum += b;
        }

        return new ValueTask<string>(sum.ToString());
    }

    private BigInteger DoProblem(int start, int end, char op)
    {
        BigInteger Result = new BigInteger();
        if (op == '*')
        {
            Result = 1;
        }
        else
        {
            Result = 0;
        }
        for (int i = end; i >= start; i--)
        {
            BigInteger workingNum = 0;
            for (int j = 0; j < RawGrid.Count - 1; j++)
            {
                char c = RawGrid[j][i];
                if (c == ' ')
                {
                    continue;
                }
                int result = c - '0';
                workingNum *= 10;
                workingNum += result;
            }
            if (workingNum == 0)
                continue;
            if (op == '*')
            {
                Result *= workingNum;            }
            else
            {
                Result += workingNum;
            }
        }
        return Result;
    }

    public override ValueTask<string> Solve_2()
    {
        List<BigInteger> Results = new List<BigInteger>();
        for (int i = 0; i < OperatorIndexes.Count; i++)
        {

            int start = OperatorIndexes[i];
            int end;
            if (i + 1 == OperatorIndexes.Count)
            {
                end = RawGrid[0].Count - 1;
            }
            else
            {
                end = OperatorIndexes[i + 1] - 1;
            }
            Results.Add(DoProblem(start, end, Operators[i]));
        }
        BigInteger sum = 0;
        foreach (var b in Results)
        {
            sum += b;
        }

        return new ValueTask<string>(sum.ToString());
    }
}
