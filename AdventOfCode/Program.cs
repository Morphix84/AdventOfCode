using AdventOfCode;

//    await Solver.SolveLast(opt => opt.ClearConsole = false);
//}
//else if (args.Length == 1 && args[0].Contains("all", StringComparison.CurrentCultureIgnoreCase))
//{
//    await Solver.SolveAll(opt =>
//    {
//        opt.ShowConstructorElapsedTime = true;
//        opt.ShowTotalElapsedTimePerDay = true;
//    });
//}
//else
//{
//    var indexes = args.Select(arg => uint.TryParse(arg, out var index) ? index : uint.MaxValue);

//    await Solver.Solve(indexes.Where(i => i < uint.MaxValue));
//}



await Solver.Solve<Day2025_07>();
//await Solver.SolveLast();
//await Solver.SolveLast(opt => opt.ClearConsole = false);

//await Solver.SolveAll(opt =>
//{
//    opt.ShowConstructorElapsedTime = true;
//    opt.ShowTotalElapsedTimePerDay = true;
//});