namespace SheepTools.Extensions;

public static class DateTimeExtensions
{
    /// <summary>
    /// Checks if a given datetime is after current datetime, no matter its timezone
    /// </summary>
    /// <returns>true, if it is after now</returns>
    public static bool IsAfterNow(this DateTime dateTime)
    {
        return dateTime.IsAfter(DateTime.Now);
    }

    /// <summary>
    /// Checks if a given datetime is after another, no matter their timezone
    /// </summary>
    /// <returns>true, if it is after now</returns>
    public static bool IsAfter(this DateTime dateTime, DateTime other)
    {
        return dateTime.ToUniversalTime() > other.ToUniversalTime();
    }

    /// <summary>
    /// Returns the amount of milliseconds from epoch
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static double MillisecondsFromEpoch(this DateTime dateTime)
    {
        return (dateTime - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds;
    }

    /// <summary>
    /// Returns a unique string id with format yyyy'-'MM'-'dd'__'HH'_'mm'_'ss
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static string StringId(this DateTime dateTime)
    {
        return dateTime.ToString("yyyy'-'MM'-'dd'__'HH'_'mm'_'ss");
    }
}
