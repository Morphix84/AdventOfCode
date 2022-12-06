namespace AdventOfCode;


public class BarrelRegister<T>
{
    private List<T> list = new List<T>();
    int maxSize = 0;

    public BarrelRegister(int size)
    {
        maxSize = size;
    }
    public void SetSize(int i)
    {
        maxSize = i;
    }

    public void Push(T obj)
    {
        list.Add(obj);
        if (list.Count > maxSize)
            list.RemoveAt(0);
    }

    public bool AllUnique()
    {
        var unique = list.Distinct().Count();
        return unique == list.Count;
    }

    public int Count { get { return list.Count; } }
}

public class Day2022_06 : BaseDay
{
    public Day2022_06()
    {
    }


    public override ValueTask<string> Solve_1()
    {
        const int regSize = 4;
        var reg = new BarrelRegister<char>(regSize);
        int answer = 0;
        for(int i = 0; i < _input[0].Length; i++)
        {
            char c = _input[0][i];
            reg.Push(c);
            if(reg.Count == regSize && reg.AllUnique())
            {
                answer = i+1;
                break;
            }
        }
      

        return new ValueTask<string>(answer.ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        const int regSize = 14;
        var reg = new BarrelRegister<char>(regSize);
        int answer = 0;
        for (int i = 0; i < _input[0].Length; i++)
        {
            char c = _input[0][i];
            reg.Push(c);
            if (reg.Count == regSize && reg.AllUnique())
            {
                answer = i + 1;
                break;
            }
        }


        return new ValueTask<string>(answer.ToString());
    }

}
