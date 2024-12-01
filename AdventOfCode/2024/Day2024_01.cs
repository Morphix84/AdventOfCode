using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day2024_01 : BaseDay
{
    private List<int> _first = new List<int>();
    private List<int> _second = new List<int>();
    private Dictionary<int, int> _counts = new Dictionary<int, int>();
    public Day2024_01()
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
                var nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var first = int.Parse(nums[0]);
                _first.Add(first);

                var second = int.Parse(nums[1]);
                _second.Add(second);
                if(_counts.ContainsKey(second))
                {
                    var foo = _counts[second];
                    foo++;
                    _counts[second] = foo;
                }
                else
                {
                    _counts[second] = 1;
                }

                if(!_counts.ContainsKey(first))
                {
                    _counts[first] = 0;
                }
            }
        }

    }

    public override ValueTask<string> Solve_1()
    {
        _first.Sort();
        _second.Sort();
        int sum = 0;
        for(int i =0; i < _first.Count; i++) 
        {
            sum += Math.Abs(_first[i] - _second[i]);   
        }
        return new ValueTask<string>(sum.ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        int sum = 0;
        for (int i = 0; i < _first.Count; i++)
        {
            var val = _first[i];
            sum += val * _counts[val];
        }
        return new ValueTask<string>(sum.ToString());
    }
}
