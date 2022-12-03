using System.Diagnostics;

namespace SheepTools.Extensions;

public static class StopwatchExtensions
{
    /// <summary>
    /// Calculates in the elapsed milliseconds with high resolution.
    /// </summary>
    /// <param name="stopwatch">Stopped <see cref="Stopwatch"/></param>
    /// <returns></returns>
    public static double ElapsedMilliseconds(this Stopwatch stopwatch)
    {
        return 1000 * stopwatch.ElapsedTicks / (double)Stopwatch.Frequency;
    }

    public static string ToFriendlyString(this Stopwatch stopwatch)
    {
        var milliseconds = stopwatch.ElapsedMilliseconds();

        return milliseconds switch
        {
            < 1 => $"{milliseconds:F} ms",
            < 1_000 => $"{Math.Round(milliseconds)} ms",
            < 60_000 => $"{0.001 * milliseconds:F} s",
            < 3_600_000 => $"{Math.Floor(milliseconds / 60_000)} min {Math.Round(0.001 * (milliseconds % 60_000))} s",
            _ => $"{Math.Floor(milliseconds / 3_600_000)} h {Math.Round((milliseconds % 3_600_000) / 60_000)} min"
        };
    }
}
