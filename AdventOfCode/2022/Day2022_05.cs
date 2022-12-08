namespace AdventOfCode;

public class Day2022_05 : BaseDay
{
    public Day2022_05()
    {
        ParseInput();
    }
    List<Stack<char>> stacks = new List<Stack<char>>();

    private void SetupStacks()
    {
        var stack1 = new Stack<char>();
        stack1.Push('N');
        stack1.Push('B');
        stack1.Push('D');
        stack1.Push('T');
        stack1.Push('V');
        stack1.Push('G');
        stack1.Push('Z');
        stack1.Push('J');
        var stack2 = new Stack<char>();
        stack2.Push('S');
        stack2.Push('R');
        stack2.Push('M');
        stack2.Push('D');
        stack2.Push('W');
        stack2.Push('P');
        stack2.Push('F');
        var stack3 = new Stack<char>();
        stack3.Push('V');
        stack3.Push('C');
        stack3.Push('R');
        stack3.Push('S');
        stack3.Push('Z');
        var stack4 = new Stack<char>();
        stack4.Push('R');
        stack4.Push('T');
        stack4.Push('J');
        stack4.Push('Z');
        stack4.Push('P');
        stack4.Push('H');
        stack4.Push('G');
        var stack5 = new Stack<char>();
        stack5.Push('T');
        stack5.Push('C');
        stack5.Push('J');
        stack5.Push('N');
        stack5.Push('D');
        stack5.Push('Z');
        stack5.Push('Q');
        stack5.Push('F');
        var stack6 = new Stack<char>();
        stack6.Push('N');
        stack6.Push('V');
        stack6.Push('P');
        stack6.Push('W');
        stack6.Push('G');
        stack6.Push('S');
        stack6.Push('F');
        stack6.Push('M');
        var stack7 = new Stack<char>();
        stack7.Push('G');
        stack7.Push('C');
        stack7.Push('V');
        stack7.Push('B');
        stack7.Push('P');
        stack7.Push('Q');
        var stack8 = new Stack<char>();
        stack8.Push('Z');
        stack8.Push('B');
        stack8.Push('P');
        stack8.Push('N');
        var stack9 = new Stack<char>();
        stack9.Push('W');
        stack9.Push('P');
        stack9.Push('J');

        stacks.Clear();
        stacks.Add(stack1);
        stacks.Add(stack2);
        stacks.Add(stack3);
        stacks.Add(stack4);
        stacks.Add(stack5);
        stacks.Add(stack6);
        stacks.Add(stack7);
        stacks.Add(stack8);
        stacks.Add(stack9);
    }
    private void ParseInput()
    {

        SetupStacks();
        foreach (var line in _input)
        {
            var strings = line.Split(' ');
            List<int > numbers = new List<int>();
            numbers.Add(int.Parse(strings[1]));
            numbers.Add(int.Parse(strings[3]));
            numbers.Add(int.Parse(strings[5]));
            moves.Add(numbers);
        }
    }

    List<List<int>> moves = new List<List<int>>();

    public override ValueTask<string> Solve_1()
    {
        foreach(var num in moves)
        {
            for (int i = 0; i < num[0]; i++)
            {
                var stackFrom = stacks[num[1] - 1];
                var stackTo = stacks[num[2]- 1];
                if(stackFrom.Count == 0)
                    continue;

                char c = stackFrom.Pop();
                stackTo.Push(c);
            }
        }

        string answer = "";
        foreach(var stack in stacks)
        {
            answer += stack.Peek();
        }

        return new ValueTask<string>(answer.ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        SetupStacks();
        foreach (var num in moves)
        {
            string boxes = "";
            var stackTo = stacks[num[2] - 1];
             var stackFrom = stacks[num[1] - 1];
            for (int i = 0; i < num[0]; i++)
            {
               
                
                if (stackFrom.Count == 0)
                    continue;

                boxes += stackFrom.Pop();
                
            }
            for(int i = boxes.Length - 1; i >= 0; i--)
            {
                stackTo.Push(boxes[i]);
            }
        }

        string answer = "";
        foreach (var stack in stacks)
        {
            answer += stack.Peek();
        }

        return new ValueTask<string>(answer.ToString());
    }

}
