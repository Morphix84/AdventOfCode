using SheepTools;
using SheepTools.Model;

namespace AdventOfCode;

public class Day2022_10 : BaseDay
{
    public Day2022_10()
    {

    }
    public override ValueTask<string> Solve_1()
    {
        int signal = 0;
        int clock = 1;
        int regX = 1;
        for (int i = 0; i < _input.Length; i++)
        {
            if (clock == 20 || clock == 60 || clock == 100 || clock == 140 || clock == 180 || clock == 220)
                signal += clock * regX;
            string op = _input[i];
            if (op == "noop")
            {
                clock++;
            }
            else
            {
                int v = int.Parse(op.Split(' ')[1]);
                clock++;
                if (clock == 20 || clock == 60 || clock == 100 || clock == 140 || clock == 180 || clock == 220)
                    signal += clock * regX;
                clock++;
                regX += v;
            }
        }
        return new ValueTask<string>(signal.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int clock = 1;
        int regX = 1;
        for (int i = 0; i < _input.Length; i++)
        {
            Draw(clock, regX);
            string op = _input[i];
            if (op == "noop")
            {
                clock++;
            }
            else
            {
                int v = int.Parse(op.Split(' ')[1]);
                clock++;
                Draw(clock, regX);
                clock++;
                regX += v;
            }
        }
        display.Print();
        //return new ValueTask<string>("RZEKEFHA".ToString());
        return new ValueTask<string>(display.ToString());
    }

    AoCSixHeightDisplay display = new AoCSixHeightDisplay(40);
    void Draw(int clock, int regX)
    {
        var pos = (clock - 1) % 40;
        display.SetNext(Math.Abs(regX - pos) <= 1);
    }

}
