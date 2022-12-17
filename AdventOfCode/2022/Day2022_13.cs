using Microsoft.VisualBasic.FileIO;
using SheepTools;
using SheepTools.Model;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace AdventOfCode;

public class Day2022_13 : BaseDay
{
    public Day2022_13()
    {

    }

    public static int CompareValueNodes(int left, int right)
    {
        if (left < right)
            return 1;
        else if (left > right)
            return -1;
        else return 0;
    }

    public static int Compare(object? left, object? right)
    {
        if (left.GetType() != typeof(JArray) && right.GetType() != typeof(JArray))
        {
            return CompareValueNodes(((int)((JToken)left)), ((int)((JToken)right)));
        }
        else if (left.GetType() == typeof(JArray) && right.GetType() == typeof(JArray))
        {
            for (int i = 0; i < Math.Min(((JArray)left).Count, ((JArray)right).Count); i++)
            {
                int j = Compare(((JArray)left)[i], ((JArray)right)[i]);
                if (j != 0)
                    return j;
            }
            if (((JArray)left).Count < ((JArray)right).Count)
                return 1;
            else if (((JArray)left).Count > ((JArray)right).Count)
                return -1;
            return 0;
        }
        else
        {
            if(left.GetType() != typeof(JArray))
            {
                string s = "[" + ((int)((JToken)left)).ToString() + "]";
                var tempLeft = JArray.Parse(s);
                return Compare(tempLeft, right);
            }
            else
            {
                string s = "[" + ((int)((JToken)right)).ToString() + "]";
                var tempRight = JArray.Parse(s);
                return Compare(left, tempRight);
            }
        }
        throw new NotFoundException();
    }

    public override ValueTask<string> Solve_1()
    {
        int i = 0;
        int j = 1;
        int total = 0;
        while (i < _input.Length)
        {
            try
            {
                var string1 = _input[i++];
                var string2 = _input[i++];
                i++;
                if (CheckOrder(string1, string2))
                {
                    total += j;
                }
                j++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

        }
        
        return new ValueTask<string>(total.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        List<string> codes = new List<string>();
        codes.Add("[[2]]");
        codes.Add("[[6]]");

        char[] seps = { '\n', '\r', '\t' };
        foreach (var line in _input)
        {
            if (string.IsNullOrEmpty(line)) continue;
            codes.Add(line.TrimEnd(seps));
        }
        bool inOrder = false;
        while (!inOrder)
        {
            inOrder = true;
            for (int i = 0; i < codes.Count-1; i++)
            {
                
                var string1 = codes[i];
                var string2 = codes[i+1];
                if (!CheckOrder(string1, string2))
                {
                    var temp = codes[i];
                    codes[i] = codes[i + 1];
                    codes[i + 1] = temp;
                    inOrder = false;
                }
                
            }

        }

        
        int total = 1;
        for(int i = 0; i < codes.Count ;i++)
        {
            if (codes[i].Equals("[[2]]") || codes[i].Equals("[[6]]"))
                total *= (i+1);
        }

        return new ValueTask<string>(total.ToString());
    }

    bool CheckOrder(string s1, string s2)
    {
        var node1 = JsonConvert.DeserializeObject(s1);
        var node2 = JsonConvert.DeserializeObject(s2);

        return Compare(node1, node2) == 1;
    }

}
