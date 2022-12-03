using Microsoft.Extensions.Logging;
using Moq;

namespace SheepTools.Moq;

public static class MoqLoggerExtensions
{
    public static void VerifyLog(this Mock<ILogger> loggerMock, LogLevel level, string? failMessage = null)
    {
        loggerMock.VerifyLog<Exception>(level, It.IsAny<Times>(), failMessage);
    }


    public static void VerifyLog<TException>(this Mock<ILogger> loggerMock, LogLevel level, string? failMessage = null)
        where TException : Exception
    {
        loggerMock.VerifyLog<TException>(level, It.IsAny<Times>(), failMessage);
    }


    public static void VerifyLog(this Mock<ILogger> loggerMock, LogLevel level, Times times, string? failMessage = null)
    {
        loggerMock.VerifyLog<Exception>(level, times, failMessage);
    }

    public static void VerifyLog(this Mock<ILogger> loggerMock, LogLevel level, Func<Times> times, string? failMessage = null)
    {
        loggerMock.VerifyLog<Exception>(level, times, failMessage);
    }


    public static void VerifyLog<TException>(this Mock<ILogger> loggerMock, LogLevel level, Func<Times> times, string? failMessage = null)
        where TException : Exception
    {
        loggerMock.VerifyLog<TException>(level, times.Invoke(), failMessage);
    }


    public static void VerifyLog(this Mock<ILogger> loggerMock, LogLevel level, string message, Func<Times> times, string? failMessage = null)
    {
        loggerMock.VerifyLog(level, message, times.Invoke(), failMessage);
    }

    public static void VerifyLog(this Mock<ILogger> loggerMock, LogLevel level, string message, Times times, string? failMessage = null)
    {
        loggerMock.VerifyLog<Exception>(level, message, times, failMessage);
    }


    public static void VerifyLog<TException>(this Mock<ILogger> loggerMock, LogLevel level, TException ex, Times times, string? failMessage = null)
        where TException : Exception
    {
        loggerMock.VerifyLog(level, ex, ex.Message, times, failMessage);
    }

    public static void VerifyLog<TException>(this Mock<ILogger> loggerMock, LogLevel level, TException ex, Func<Times> times, string? failMessage = null)
        where TException : Exception
    {
        loggerMock.VerifyLog(level, ex, ex.Message, times.Invoke(), failMessage);
    }


    public static void VerifyLog<TException>(this Mock<ILogger> loggerMock, TException ex, Times times, string? failMessage = null)
        where TException : Exception
    {
        loggerMock.VerifyLog(ex, ex.Message, times, failMessage);
    }

    public static void VerifyLog<TException>(this Mock<ILogger> loggerMock, TException ex, Func<Times> times, string? failMessage = null)
        where TException : Exception
    {
        loggerMock.VerifyLog(ex, ex.Message, times.Invoke(), failMessage);
    }


    public static void VerifyLog<TException>(this Mock<ILogger> loggerMock, TException ex, string message, Func<Times> times, string? failMessage = null)
        where TException : Exception
    {
        loggerMock.VerifyLog(ex, message, times.Invoke(), failMessage);
    }


    public static void VerifyLog<TException>(this Mock<ILogger> loggerMock, LogLevel level, TException ex, string message, Func<Times> times, string? failMessage = null)
        where TException : Exception
    {
        loggerMock.VerifyLog(level, ex, message, times.Invoke(), failMessage);
    }

    #region Real implementations

    public static void VerifyLog<TException>(this Mock<ILogger> loggerMock, LogLevel level, Times times, string? failMessage = null)
        where TException : Exception
    {
        loggerMock.Verify(l => l.Log(
                level,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<TException>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            times,
            failMessage);
    }

    public static void VerifyLog<TException>(this Mock<ILogger> loggerMock, LogLevel level, string message, Times times, string? failMessage = null)
        where TException : Exception
    {
        loggerMock.Verify(l => l.Log(
                level,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((object v, Type _) => v != null && v.ToString() != null && v!.ToString()!.Contains(message)),
                It.IsAny<TException>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            times,
            failMessage);
    }

    public static void VerifyLog<TException>(this Mock<ILogger> loggerMock, TException ex, string message, Times times, string? failMessage = null)
        where TException : Exception
    {
        loggerMock.Verify(l => l.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((object v, Type _) => v != null && v.ToString() != null && v!.ToString()!.Contains(message)),
                It.Is<TException>(e => (e != null ? e.GetHashCode() : -1) == ex.GetHashCode()),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            times,
            failMessage);
    }

    public static void VerifyLog<TException>(this Mock<ILogger> loggerMock, LogLevel level, TException ex, string message, Times times, string? failMessage = null)
       where TException : Exception
    {
        loggerMock.Verify(l => l.Log(
                level,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((object v, Type _) => v != null && v.ToString() != null && v!.ToString()!.Contains(message)),
                It.Is<TException>(e => (e != null ? e.GetHashCode() : -1) == ex.GetHashCode()),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            times,
            failMessage);
    }

    #endregion
}
