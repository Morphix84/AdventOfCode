namespace AdventOfCode;

public class Day2022_03 : BaseDay
{
    public Day2022_03()
    {
        ParseInput();
    }


    private void ParseInput()
    {
        for (int i = 0; i < _input.Length; i++)
        {

        }
    }

    private int GetValue(char c)
    {
        if (c >= 'A' && c <= 'Z')
            return c - 64 + 26;
        else
            return c - 96;
    }
    public override ValueTask<string> Solve_1()
    {
        List<char> chars = new List<char>();
        int sum = 0;
        foreach(var line in _input)
        {
            var length = line.Length / 2;
            var string1 = line.Substring(0, length);
            var string2 = line.Substring(length, length);
            HashSet<char> charSet1 = new HashSet<char>(string1);
            HashSet<char> charSet2 = new HashSet<char>(string2);
            var both = charSet1.Where(x => charSet2.Contains(x));
            char c = both.First();
            chars.Add(c);
            int val = GetValue(c);
            sum+= val;
        }

        return new ValueTask<string>(sum.ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        List<char> chars = new List<char>();
        int sum = 0;
        for (int i = 0; i < _input.Length; i+=3)
        {
            HashSet<char> charSet1 = new HashSet<char>(_input[i]);
            HashSet<char> charSet2 = new HashSet<char>(_input[i+1]);
            HashSet<char> charSet3 = new HashSet<char>(_input[i+2]);
            
            var both = charSet1.Where(x => charSet2.Contains(x));
            both = both.Where(x => charSet3.Contains(x));

            char c = both.First();
            chars.Add(c);
            int val = GetValue(c);
            sum += val;
        }
        return new ValueTask<string>(sum.ToString());
    }

}
