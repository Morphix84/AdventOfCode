namespace AdventOfCode;

public class Day2023_02 : BaseDay
{
    Dictionary<int, List<List<Tuple<int, string>>>> games;
    public Day2023_02()
    {
        ParseInput();
    }

    private void ParseInput()
    {
        games = new Dictionary<int, List<List<Tuple<int, string>>>>();

        for (int i = 0; i < _input.Length; i++)
        {
            int id = i + 1;
            string line = _input[i];
            var foo = line.Split(":", StringSplitOptions.RemoveEmptyEntries)[1].Trim();
            var bar = foo.Split(";", StringSplitOptions.RemoveEmptyEntries);

            var result = new Dictionary<string, int>();
            var game = new List<List<Tuple<int, string>>>();
            foreach (var key in bar)
            {
                var values = key.Split(",", StringSplitOptions.RemoveEmptyEntries);
                var round = new List<Tuple<int, string>>();
                foreach (var value in values)
                {
                    var pair = value.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Tuple<int, string> val = new Tuple<int, string>(int.Parse(pair[0]), pair[1]);
                    round.Add(val);
                }
                game.Add(round);
            }
            games.Add(id, game);

        }
    }

    public override ValueTask<string> Solve_1()
    {
        int total = 0;
        foreach (var game in games)
        {
            bool valid = true;
            foreach(var round in game.Value)
            {
                foreach(var pair in round)
                {
                    if(pair.Item2 == "red")
                    {
                        valid &= pair.Item1 <= 12;
                    }
                    else if (pair.Item2 == "green")
                    {
                        valid &= pair.Item1 <= 13;
                    }
                    else if (pair.Item2 == "blue")
                    {
                        valid &= pair.Item1 <= 14;
                    }
                    else
                    {
                        throw new Exception("Shit");
                    }
                }
            }
            if(valid)
            {
                total += game.Key;
            }
        }

        return new ValueTask<string>(total.ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        int total = 0;
        foreach (var game in games)
        {
            int red = 0;
            int blue = 0;
            int green = 0;

            foreach (var round in game.Value)
            {
                foreach (var pair in round)
                {
                    if (pair.Item2 == "red")
                    {
                        red = Math.Max(pair.Item1, red);
                    }
                    else if (pair.Item2 == "green")
                    {
                        green = Math.Max(pair.Item1, green);
                    }
                    else if (pair.Item2 == "blue")
                    {
                        blue = Math.Max(pair.Item1, blue);
                    }
                    else
                    {
                        throw new Exception("Shit");
                    }
                }
            }
            int power = red * blue * green;
            total += power;
        }

        return new ValueTask<string>(total.ToString());
    }
}
