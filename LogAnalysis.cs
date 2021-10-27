using System;

public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string logLine, string delimiter)
    {
        int first = logLine.IndexOf(delimiter) + delimiter.Length;
        return logLine.Substring(first, logLine.Length - first);
    }
    public static string SubstringBetween(this string logLine, string substring1, string substring2)
    {
        int first = logLine.IndexOf(substring1);
        int last = logLine.IndexOf(substring2);
        return logLine.Substring(first+substring1.Length,last - (first + substring1.Length));        
    }
    // TODO: define the 'SubstringBetween()' extension method on the `string` type

    // TODO: define the 'Message()' extension method on the `string` type

    public static string FirstOrSecondMessagePart(int firstOrSecond, string logLine)
    {
        bool isErrorResult = logLine.StartsWith("[ERROR]:", System.StringComparison.CurrentCultureIgnoreCase);
        bool isInfoResult = logLine.StartsWith("[INFO]:", System.StringComparison.CurrentCultureIgnoreCase);
        bool isWarningResult = logLine.StartsWith("[WARNING]:", System.StringComparison.CurrentCultureIgnoreCase);

        string errorPattern = "[ERROR]:";
        string infoPattern = "[INFO]:";
        string warningPattern = "[WARNING]:";

        if (firstOrSecond == 1)
        {
            if (isErrorResult) return "ERROR";
            if (isInfoResult) return "INFO";
            if (isWarningResult) return "WARNING";
            return "LEVEL IS NOT CORRECT.";
        }
        if (firstOrSecond == 2)
        {
            if (isErrorResult)
            {
                int first = logLine.IndexOf(errorPattern);
                return logLine.Substring(first + errorPattern.Length, logLine.Length - first - errorPattern.Length).Trim();
            }
            if (isWarningResult)
            {
                int first = logLine.IndexOf(warningPattern);
                return logLine.Substring(first + warningPattern.Length, logLine.Length - first - warningPattern.Length).Trim();
            }
            if (isInfoResult)
            {
                int first = logLine.IndexOf(infoPattern);
                return logLine.Substring(first + infoPattern.Length, logLine.Length - first - infoPattern.Length).Trim();
            }
            return "LEVEL IS NOT CORRECT";
        }
        return "OPTION IS NOT VALID.";
    }
    public static string Message(this string logLine)
    {
        return FirstOrSecondMessagePart(2, logLine);
               
    }
    public static string LogLevel(this string logLine)
    {
        return FirstOrSecondMessagePart(1, logLine);
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
}