namespace AdventOfCode;

enum MoveResult
{
    Rock,
    Paper,
    Scissors
}

enum RoundResult
{
    Lose, Draw, Win
}

public class Day2022_02 : BaseDay
{
    List<List<int>> list;
    public Day2022_02()
    {
        ParseInput();
    }

    List<Tuple<MoveResult, MoveResult>> moves;
    List<Tuple<MoveResult, RoundResult>> moves2;


    private void ParseInput()
    {
        moves = new List<Tuple<MoveResult, MoveResult>>();
        moves2 = new List<Tuple<MoveResult, RoundResult>>();
        for (int i = 0; i < _input.Length; i++)
        {
            MoveResult moveResult1 = MoveResult.Rock;
            MoveResult moveResult2 = MoveResult.Rock;
            RoundResult roundResult1 = RoundResult.Win;

            string line = _input[i];
            var foo = line.Split(" ");
            switch (foo[0])
            {
                case "A":
                    moveResult1 = MoveResult.Rock;
                    break;
                case "B":
                    moveResult1 = MoveResult.Paper;
                    break;
                case "C":
                    moveResult1 = MoveResult.Scissors;
                    break;
            }

            switch (foo[1])
            {
                case "X":
                    moveResult2 = MoveResult.Rock;
                    roundResult1 = RoundResult.Lose;
                    break;
                case "Y":
                    moveResult2 = MoveResult.Paper;
                    roundResult1 = RoundResult.Draw;
                    break;
                case "Z":
                    moveResult2 = MoveResult.Scissors;
                    roundResult1 = RoundResult.Win;
                    break;
            }
            moves.Add(new Tuple<MoveResult, MoveResult>(moveResult1, moveResult2));
            moves2.Add(new Tuple<MoveResult, RoundResult>(moveResult1, roundResult1));

        }
    }

    public override ValueTask<string> Solve_1()
    {
        int score = 0;
        foreach (var l in moves)
        {
            score += MoveScore(l.Item2);
            score += WinScore(l.Item1, l.Item2);
        }

        return new ValueTask<string>(score.ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        int score = 0;
        foreach (var l in moves2)
        {
            MoveResult me = PickMove(l.Item1, l.Item2);
            score += MoveScore(me);
            score += WinScore(l.Item1, me);
        }

        return new ValueTask<string>(score.ToString());
    }

    private MoveResult PickMove(MoveResult them, RoundResult outcome)
    {
        if (them == MoveResult.Rock)
        {
            switch (outcome)
            {
                case RoundResult.Lose: return MoveResult.Scissors;
                case RoundResult.Draw: return MoveResult.Rock;
                case RoundResult.Win: return MoveResult.Paper;
            }
        }
        else if (them == MoveResult.Paper)
        {
            switch (outcome)
            {
                case RoundResult.Lose: return MoveResult.Rock;
                case RoundResult.Draw: return MoveResult.Paper;
                case RoundResult.Win: return MoveResult.Scissors;
            }
        }
        else
        {
            switch (outcome)
            {
                case RoundResult.Lose: return MoveResult.Paper;
                case RoundResult.Draw: return MoveResult.Scissors;
                case RoundResult.Win: return MoveResult.Rock;
            }
        }
        return MoveResult.Rock;
    }
    private int WinScore(MoveResult them, MoveResult me)
    {
        if (them == MoveResult.Rock)
        {
            switch (me)
            {
                case MoveResult.Paper: return 6;
                case MoveResult.Scissors: return 0;
                case MoveResult.Rock: return 3;
            }
        }
        else if (them == MoveResult.Paper)
        {
            switch (me)
            {
                case MoveResult.Paper: return 3;
                case MoveResult.Scissors: return 6;
                case MoveResult.Rock: return 0;
            }
        }
        else
        {
            switch (me)
            {
                case MoveResult.Paper: return 0;
                case MoveResult.Scissors: return 3;
                case MoveResult.Rock: return 6;
            }
        }
        return 0;
    }
    private int MoveScore(MoveResult move)
    {
        switch (move)
        {
            case MoveResult.Rock: return 1;
            case MoveResult.Paper: return 2;
            case MoveResult.Scissors: return 3;
        }
        return 0;
    }

}
