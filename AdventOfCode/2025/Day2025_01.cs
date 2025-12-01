using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day2025_01 : BaseDay
{
    private List<Tuple<char, int>> _moves = new List<Tuple<char, int>>();
    public Day2025_01()
    {
        ParseInput();
    }
     
    private void ParseInput()
    {

        for (int i = 0; i < _input.Length; i++)
        {
            string line = _input[i];
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }
            else
            {
                int num = int.Parse(line.Substring(1));
                Tuple<char, int> thisNum = new Tuple<char, int>(line[0], num);
                _moves.Add(thisNum);
            }
        }

    }

    public override ValueTask<string> Solve_1()
    {
        int currentNum = 50;
        int sum = 0;
        foreach (var move in _moves)
        {
            switch(move.Item1)
            {
                case 'L':
                    currentNum -= move.Item2;
                    break;
                case 'R':
                    currentNum += move.Item2;
                    break;
                default:
                    throw new NotFiniteNumberException();
            }

            while (currentNum > 99) 
            {
                currentNum -= 100;
            }
            while (currentNum < 0)
            {
                currentNum += 100;
            }
            
            if(currentNum == 0)
            { 
                sum++;
            }

        }
        
        return new ValueTask<string>(sum.ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        int currentNum = 50;
        int sum = 0;
        foreach (var move in _moves)
        {
            switch (move.Item1)
            {
                case 'L':
                    currentNum -= move.Item2;
                    break;
                case 'R':
                    currentNum += move.Item2;
                    break;
                default:
                    throw new NotFiniteNumberException();
            }

            //if (currentNum == 0)
            //{
            //    sum++;
            //}

            while (currentNum > 99)
            {
                currentNum -= 100;
                sum++;
            }
            while (currentNum < 0)
            {
                currentNum += 100;
                sum++;
            }



        }

        return new ValueTask<string>(sum.ToString());
    }
}
