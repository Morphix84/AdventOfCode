namespace AdventOfCode;

public class Day2022_01 : BaseDay
{
    List<List<int>> list;
    public Day2022_01()
    {
        ParseInput();
    }

    private void ParseInput()
    {
        list = new List<List<int>>();

        List<int> vs = new List<int>();
        for (int i = 0; i < _input.Length; i++)
        {
            string line = _input[i];

            if (string.IsNullOrEmpty(line))
            {
                list.Add(vs);
                vs = new List<int>();
                continue;
            }
            vs.Add(int.Parse(line));

        }
    }

    public override ValueTask<string> Solve_1()
    {
        List<int> totals = new List<int>();
        foreach (var l in list)
        {
            var sum = l.Sum();
            totals.Add(sum);
        }

        totals.Sort();
        totals.Reverse();
        return new ValueTask<string>(totals[0].ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        List<int> totals = new List<int>();
        foreach (var l in list)
        {
            var sum = l.Sum();
            totals.Add(sum);
        }

        totals.Sort();
        totals.Reverse();

        var foo = totals[0] + totals[1] + totals[2];
        return new ValueTask<string>(foo.ToString());
    }
}
