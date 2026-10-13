using System.Diagnostics;

namespace leetcodebek;

public static class Helpers
{
    public static void RunAndMeasureTime(Action func, string methodName = "Function")
    {
        var stopWatch = new Stopwatch();

        stopWatch.Start();
        func();
        stopWatch.Stop();

        Console.Write($"{methodName} took ");

        void WriteColored(double value, string format, string unit)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(value.ToString(format));
            Console.ResetColor();
            Console.Write(unit);
        }
        
        if (stopWatch.Elapsed.TotalSeconds >= 1)
        {
            WriteColored(stopWatch.Elapsed.TotalSeconds, "F3", " s. Or ");
        }

        WriteColored(stopWatch.Elapsed.TotalMilliseconds, "F3", " ms. Or ");
        WriteColored(stopWatch.Elapsed.TotalMicroseconds, "F3", " microseconds.");

        Console.WriteLine();    
    }
    
    public static void RunAndMeasureTime<TResult>(Func<TResult> func, string methodName = "Function")
    {
        var stopWatch = new Stopwatch();

        stopWatch.Start();
        func();
        stopWatch.Stop();

        Console.Write($"{methodName} took ");

        void WriteColored(double value, string format, string unit)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(value.ToString(format));
            Console.ResetColor();
            Console.Write(unit);
        }

        if (stopWatch.Elapsed.TotalSeconds >= 1)
        {
            WriteColored(stopWatch.Elapsed.TotalSeconds, "F3", " s. Or ");
        }

        WriteColored(stopWatch.Elapsed.TotalMilliseconds, "F3", " ms. Or ");
        WriteColored(stopWatch.Elapsed.TotalMicroseconds, "F3", " microseconds.");

        Console.WriteLine();    
    }
}