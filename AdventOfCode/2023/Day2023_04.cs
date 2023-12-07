namespace AdventOfCode;

public class Day2023_04 : BaseDay
{
    Dictionary<int, List<int>> Winners = new Dictionary<int, List<int>>();
    Dictionary<int, List<int>> MyCards = new Dictionary<int, List<int>>();


    public Day2023_04()
    {
        ParseInput();
    }

    private void ParseInput()
    {
        for(int i = 0; i < _input.Length; i++)
        {
            string s = _input[i];
            var split = s.Split(':');
            var foo = split[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int index = int.Parse(foo[1]);

            var cards = split[1].Split('|');
            var win = cards[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            var mine = cards[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> winners = new List<int>();
            List<int> myCards = new List<int>();
            foreach(var num in win)
            {
                winners.Add(int.Parse(num));
            }
            foreach(var num in mine)
            {
                myCards.Add(int.Parse(num));
            }
            Winners.Add(index, winners);
            MyCards.Add(index, myCards);
        }
    }

    public override ValueTask<string> Solve_1()
    {
        int total = 0;
        foreach(var cardId in MyCards.Keys)
        {
            int thisCardValue = 0;
            var card = MyCards[cardId];
            var winners = Winners[cardId];
            foreach(var num in card)
            {
                if (winners.Contains(num))
                {
                    if (thisCardValue == 0)
                        thisCardValue++;
                    else
                        thisCardValue *= 2;
                }
                    
            }
            total += thisCardValue;
        }
        

        return new ValueTask<string>(total.ToString());
    }



    public override ValueTask<string> Solve_2()
    {
        int MaxCardId = 208;
        List<int> CardIndexes = new List<int>();
        CardIndexes.AddRange(MyCards.Keys);
        int index = 0;
        while (index < CardIndexes.Count)
        {
            var cardId = CardIndexes[index];
            var card = MyCards[cardId];
            var winners = Winners[cardId];
            var numWinners = 0;
            foreach (var num in card)
            {
                if (winners.Contains(num))
                {
                    numWinners++;
                }
            }
            for(int i = 1; i <= numWinners; i++)
            {
                if(cardId + i <= MaxCardId)
                    CardIndexes.Add(cardId + i);
            }
            index++;
        }

        return new ValueTask<string>(CardIndexes.Count.ToString());
    }
}
