using Microsoft.VisualBasic.FileIO;
using SheepTools;
using SheepTools.Model;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace AdventOfCode;

public class Node
{
    public int Value = -1;
    public List<Node> Nodes = new List<Node>();
    public Node(string s)
    {
        s = s.Trim(',');
        if (string.IsNullOrEmpty(s))
            return;

        

        if (s[0] == '[')
        {
            s = s.Substring(1, s.Length - 2);

            int ptr = 0;
            int listdepth = 0;
            string sub = "";
            while (ptr < s.Length)
            {
                char c = s[ptr++];
                sub += c;
                if (c == '[')
                    listdepth++;
                else if (c == ']')
                    listdepth--;
                else if (c == ',' && listdepth == 0)
                {
                    Nodes.Add(new Node(sub));
                    sub = "";
                }
            }
            Nodes.Add(new Node(sub));
        }
        else if (s.Length > 0)
        {
            try
            {
                Value = int.Parse(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }



    
}
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
        if(left.GetType() == typeof(JArray))
        {
            if(right.GetType() == typeof(JArray))
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
                if (((JArray)left).Count == 0)
                    return 1;
                return Compare(((JArray)left)[0], right);
            }
        }
        else
        {
            if (right.GetType() == typeof(JArray))
            {
                if (((JArray)right).Count == 0)
                    return -1;
                return Compare(left, ((JArray)right)[0]);
            }
            else
            {
                return CompareValueNodes(((int)((JToken)left)), ((int)((JToken)right)));
            }
        }
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

    bool CheckOrder(string s1, string s2)
    {
        //Node node1 = new Node(s1);
        //Node node2 = new Node(s2);

        var node1 = JsonConvert.DeserializeObject(s1);
        var node2 = JsonConvert.DeserializeObject(s2);


        
        return Compare(node1, node2) == 1;

    }

    public override ValueTask<string> Solve_2()
    {
        int rounds = 20;

        return new ValueTask<string>(rounds.ToString());
    }

    

}
