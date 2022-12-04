namespace AdventOfCode;

public class Day2022_04 : BaseDay
{
    public Day2022_04()
    {
        ParseInput();
    }

    List<List<int>> ranges = new List<List<int>>();
    private void ParseInput()
    {
        foreach (var line in _input)
        {
            var pairs = line.Split(',');
            List<int> range = new List<int>();
            foreach (var pair in pairs)
            {
                var thing = pair.Split('-');
                range.Add(int.Parse(thing[0]));
                range.Add(int.Parse(thing[1]));
            }
            ranges.Add(range);
        }
    }


    public override ValueTask<string> Solve_1()
    {
        int score = 0;
        foreach (var pair in ranges)
        {
            List<int> range1 = new List<int>();
            List<int> range2 = new List<int>();

            for (int i = pair[0]; i <= pair[1]; i++)
            {
                range1.Add(i);
            }
            for (int i = pair[2]; i <= pair[3]; i++)
            {
                range2.Add(i);
            }
            var intersect = range1.Where(x => range2.Contains(x)).ToList();
            if (intersect.Count == range2.Count || intersect.Count == range1.Count)
                score++;
        }

        return new ValueTask<string>(score.ToString());
    }


    public override ValueTask<string> Solve_2()
    {

        int score = 0;
        foreach (var pair in ranges)
        {
            List<int> range1 = new List<int>();
            List<int> range2 = new List<int>();

            for (int i = pair[0]; i <= pair[1]; i++)
            {
                range1.Add(i);
            }
            for (int i = pair[2]; i <= pair[3]; i++)
            {
                range2.Add(i);
            }
            var intersect = range1.Where(x => range2.Contains(x)).ToList();
            if (intersect.Count != 0)
                score++;
        }

        return new ValueTask<string>(score.ToString());
    }

}
