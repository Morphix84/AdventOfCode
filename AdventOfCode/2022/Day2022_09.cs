using SheepTools.Model;

namespace AdventOfCode;

public class Day2022_09 : BaseDay
{
    public Day2022_09()
    {
        foreach (var line in _input)
        {
            var tup = line.Split(' ');
            (char, int) item = new(tup[0][0], int.Parse(tup[1]));
            moves.Add(item);
        }
    }
    List<(char, int)> moves = new List<(char, int)>();



    void MoveKnot(Point H, char dir)
    {
        switch (dir)
        {
            default:
                throw new NotImplementedException();
            case 'R':
                H.X++;
                break;
            case 'L':
                H.X--;
                break;
            case 'U':
                H.Y++;
                break;
            case 'D':
                H.Y--;
                break;
        }
    }

    bool TooFarApart(Point H, Point T)
    {
        return Math.Abs(H.X - T.X) > 1 || Math.Abs(H.Y - T.Y) > 1;
    }

    void UpdateKnotPosition(Point H, Point T)
    {
        if (TooFarApart(H, T))
        {
            int i = (H.X > T.X) ? 1 : 0;
            int j = (T.X > H.X) ? 1 : 0;
            int k = (H.Y > T.Y) ? 1 : 0;
            int l = (T.Y > H.Y) ? 1 : 0;
            T.X = T.X + (i - j);
            T.Y = T.Y + (k - l);
        }
    }

    public override ValueTask<string> Solve_2()
    {
        const int numKnots = 10;
        List<Point> knots = new List<Point>();
        for (int i = 0; i < numKnots; i++)
            knots.Add(new Point(0, 0));

        HashSet<Point> visited = new HashSet<Point>();
        visited.Add(new(0, 0));
        foreach (var move in moves)
        {
            for (int i = 0; i < move.Item2; i++)
            {
                MoveKnot(knots[0], move.Item1);
                for (int j = 0; j < numKnots - 1; j++)
                {
                    UpdateKnotPosition(knots[j], knots[j + 1]);
                }

                if (!visited.Contains(knots[9]))
                    visited.Add(knots[9]);
            }
        }
        return new ValueTask<string>(visited.Count.ToString());
    }

    public override ValueTask<string> Solve_1()
    {
        Point H = new Point(0, 0);
        Point T = new Point(0, 0);
        HashSet<Point> visited = new HashSet<Point>();
        visited.Add(T);
        foreach (var move in moves)
        {
            for (int i = 0; i < move.Item2; i++)
            {
                MoveKnot(H, move.Item1);
                UpdateKnotPosition(H, T);
                if (!visited.Contains(T))
                    visited.Add(T);
            }
        }
        return new ValueTask<string>(visited.Count.ToString());
    }

}
