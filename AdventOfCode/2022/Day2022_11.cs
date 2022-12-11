using Microsoft.VisualBasic.FileIO;
using SheepTools;
using SheepTools.Model;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode;

public class Monkey : IComparable<Monkey>
{

    public delegate UInt64 InspectItemDelegate(UInt64 item);
    public delegate bool TestItemDelegate(UInt64 item);
    public delegate void DoTrueDelegate(UInt64 item);
    public delegate void DoFalseDelegate(UInt64 item);

    public InspectItemDelegate InspectItem;
    public TestItemDelegate TestItem;
    public DoTrueDelegate DoTrue;
    public DoFalseDelegate DoFalse;

    public UInt64 ItemsInspected { get; private set; }
    public int Id { get; set; }

    public List<UInt64> Items { get; set; }
    public List<Monkey> Monkeys { get; set; }


    public int CompareTo(Monkey other)
    {
        return other.ItemsInspected.CompareTo(ItemsInspected);
    }

    public void ThrowItemTo(UInt64 item, int monkeyIndex)
    {
        Monkeys[monkeyIndex].Items.Add(item);
    }

    public void DoTurn(bool mode, UInt64 modulo)
    {
        Items.Sort();
        while(Items.Count > 0)
        {
            var item = Items[0];
            Items.RemoveAt(0);
            

            item = InspectItem(item);
            ItemsInspected++;
            if (mode)
                item /= 3;
            else
                item %= modulo;
            if(TestItem(item))
            {
                DoTrue(item);
            }
            else
            {
                DoFalse(item);
            }
        }
    }
}
public class Day2022_11 : BaseDay
{
    public Day2022_11()
    {

    }

    private List<Monkey> ResetMonkeys()
    {
        
        var monkeys = new List<Monkey>();
        var monkey0 = new Monkey() { Id= 0, Monkeys = monkeys };
        monkey0.Items = new List<UInt64>() { 61 };
        monkey0.InspectItem = (UInt64 x) => { return 11 * x; };
        monkey0.TestItem = (UInt64 x) => { return x % 5 == 0; };
        monkey0.DoTrue = (UInt64 x) => { monkey0.ThrowItemTo(x, 7); };
        monkey0.DoFalse = (UInt64 x) => { monkey0.ThrowItemTo(x, 4); };
        monkeys.Add(monkey0);

        var monkey1 = new Monkey() { Id = 1, Monkeys = monkeys };
        monkey1.Items = new List<UInt64>() { 76, 92, 53, 93, 79, 86, 81 };
        monkey1.InspectItem = (UInt64 x) => { return 4 + x; };
        monkey1.TestItem = (UInt64 x) => { return x % 2 == 0; };
        monkey1.DoTrue = (UInt64 x) => { monkey0.ThrowItemTo(x, 2); };
        monkey1.DoFalse = (UInt64 x) => { monkey0.ThrowItemTo(x, 6); };
        monkeys.Add(monkey1);

        var monkey2 = new Monkey() { Id = 2, Monkeys = monkeys };
        monkey2.Items = new List<UInt64>() { 91, 99 };
        monkey2.InspectItem = (UInt64 x) => { return 19 * x; };
        monkey2.TestItem = (UInt64 x) => { return x % 13 == 0; };
        monkey2.DoTrue = (UInt64 x) => { monkey0.ThrowItemTo(x, 5); };
        monkey2.DoFalse = (UInt64 x) => { monkey0.ThrowItemTo(x, 0); };
        monkeys.Add(monkey2);

        var monkey3 = new Monkey() { Id = 3, Monkeys = monkeys };
        monkey3.Items = new List<UInt64>() { 58, 67, 66 };
        monkey3.InspectItem = (UInt64 x) => { return x * x; };
        monkey3.TestItem = (UInt64 x) => { return x % 7 == 0; };
        monkey3.DoTrue = (UInt64 x) => { monkey0.ThrowItemTo(x, 6); };
        monkey3.DoFalse = (UInt64 x) => { monkey0.ThrowItemTo(x, 1); };
        monkeys.Add(monkey3);

        var monkey4 = new Monkey() { Id = 4, Monkeys = monkeys };
        monkey4.Items = new List<UInt64>() { 94, 54, 62, 73 };
        monkey4.InspectItem = (UInt64 x) => { return 1 + x; };
        monkey4.TestItem = (UInt64 x) => { return x % 19 == 0; };
        monkey4.DoTrue = (UInt64 x) => { monkey0.ThrowItemTo(x, 3); };
        monkey4.DoFalse = (UInt64 x) => { monkey0.ThrowItemTo(x, 7); };
        monkeys.Add(monkey4);

        var monkey5 = new Monkey() { Id = 5, Monkeys = monkeys };
        monkey5.Items = new List<UInt64>() { 59, 95, 51, 58, 58 };
        monkey5.InspectItem = (UInt64 x) => { return 3 + x; };
        monkey5.TestItem = (UInt64 x) => { return x % 11 == 0; };
        monkey5.DoTrue = (UInt64 x) => { monkey0.ThrowItemTo(x, 0); };
        monkey5.DoFalse = (UInt64 x) => { monkey0.ThrowItemTo(x, 4); };
        monkeys.Add(monkey5);

        var monkey6 = new Monkey() { Id = 6, Monkeys = monkeys };
        monkey6.Items = new List<UInt64>() { 87, 69, 92, 56, 91, 93, 88, 73 };
        monkey6.InspectItem = (UInt64 x) => { return 8 + x; };
        monkey6.TestItem = (UInt64 x) => { return x % 3 == 0; };
        monkey6.DoTrue = (UInt64 x) => { monkey0.ThrowItemTo(x, 5); };
        monkey6.DoFalse = (UInt64 x) => { monkey0.ThrowItemTo(x, 2); };
        monkeys.Add(monkey6);

        var monkey7 = new Monkey() { Id = 7, Monkeys = monkeys };
        monkey7.Items = new List<UInt64>() { 71, 57, 86, 67, 96, 95 };
        monkey7.InspectItem = (UInt64 x) => { return 7 + x; };
        monkey7.TestItem = (UInt64 x) => { return x % 17 == 0; };
        monkey7.DoTrue = (UInt64 x) => { monkey0.ThrowItemTo(x, 3); };
        monkey7.DoFalse = (UInt64 x) => { monkey0.ThrowItemTo(x, 1); };
        monkeys.Add(monkey7);


        return monkeys;
    }
    public override ValueTask<string> Solve_1()
    {
        int rounds = 20;
        List<Monkey> monkeys = ResetMonkeys();
        for(int r = 0; r < rounds; r++)
        {
            foreach (var monkey in monkeys)
            {
                monkey.DoTurn(true, 0);
            }
        }

        monkeys.Sort();
        var monkeyBusiness = monkeys[0].ItemsInspected * monkeys[1].ItemsInspected;
        return new ValueTask<string>(monkeyBusiness.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int rounds = 10000;
        UInt64 modulo = 5 * 2 * 13 * 7 * 19 * 11 * 3 * 17;
        List<Monkey> monkeys = ResetMonkeys();
        for (int r = 0; r < rounds; r++)
        {
            foreach (var monkey in monkeys)
            {
                monkey.DoTurn(false, modulo);
            }
        }

        monkeys.Sort();
        var monkeyBusiness = monkeys[0].ItemsInspected * monkeys[1].ItemsInspected;
        return new ValueTask<string>(monkeyBusiness.ToString());
    }

}
