namespace AdventOfCode;

public class Day2023_01 : BaseDay
{
    List<string> list;
    public Day2023_01()
    {
        ParseInput();
    }

    private void ParseInput()
    {
        list = new List<string>();

        for (int i = 0; i < _input.Length; i++)
        {
            string line = _input[i];

            list.Add(line);

        }
    }

    public override ValueTask<string> Solve_1()
    {
        List<int> totals = new List<int>();
        int totaltotal = 0;
        foreach (var l in list)
        {
            char a = '-';
            char b = '-';
            for (int i = 0; i < l.Length; i++)
            {
                if (l[i] >= '0' && l[i] <= '9')
                {
                    a = l[i];
                    break;
                }
            }
            for (int i = l.Length - 1; i >= 0 ; i--)
            {
                if (l[i] >= '0' && l[i] <= '9')
                {
                    b = l[i];
                    break;
                }
            }
            string foo = string.Format("{0}{1}", a, b);
            int sum = 0;
            try
            {
                sum = int.Parse(foo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            totals.Add(sum);
            totaltotal += sum;
        }

        return new ValueTask<string>(totaltotal.ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        List<int> totals = new List<int>();
        int totaltotal = 0;
        foreach (var l in list)
        {
            char a = '-';
            char b = '-';
            int ia = -1;
            int ib = -1;
            Dictionary<int, char> wordsfwd = new Dictionary<int, char>();
            Dictionary<int, char> wordsrev = new Dictionary<int, char>();

            Dictionary<string, char> words = new Dictionary<string, char>();
            words.Add("one", '1');
            words.Add("two", '2');
            words.Add("three", '3');
            words.Add("four", '4');
            words.Add("five", '5');
            words.Add("six", '6');
            words.Add("seven", '7');
            words.Add("eight", '8');
            words.Add("nine", '9');
            foreach(string word in words.Keys)
            {
                int i = l.IndexOf(word);
                if(i != -1)
                {
                    wordsfwd.Add(i, words[word]);
                }
                i = l.LastIndexOf(word);
                if (i != -1)
                {
                    wordsrev.Add(i, words[word]);
                }
            }
            
            
            for (int i = 0; i < l.Length; i++)
            {
                if (l[i] >= '0' && l[i] <= '9')
                {
                    wordsfwd.Add(i, l[i]);
                    break;
                }
            }
            for (int i = l.Length - 1; i >= 0; i--)
            {
                if (l[i] >= '0' && l[i] <= '9')
                {
                    wordsrev.Add(i, l[i]);
                    break;
                }
            }
            ia = wordsfwd.Keys.Min();
            ib = wordsrev.Keys.Max();
            a = wordsfwd[ia];
            b = wordsrev[ib];

            string foo = string.Format("{0}{1}", a, b);
            int sum = 0;
            try
            {
                sum = int.Parse(foo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            totals.Add(sum);
            totaltotal += sum;
        }

        return new ValueTask<string>(totaltotal.ToString());
    }
}
