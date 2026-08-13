using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class LogEntry
{
    public DateTime Timestamp { get; set; }
    public string LogLevel { get; set; }
    public string Message { get; set; }
    public Exception Exception { get; set; }

    public LogEntry(DateTime timestamp, string logLevel, string message, Exception exception = null)
    {
        Timestamp = timestamp;
        LogLevel = logLevel;
        Message = message;
        Exception = exception;
    }
}

class LogProcessor
{
    private StringBuilder buffer = new StringBuilder();
    private List<LogEntry> errorLogs = new List<LogEntry>();
    private int bufferCapacity;

    public LogProcessor(int capacity) { bufferCapacity = capacity; }

    public void ProcessLog(LogEntry log)
    {
        StringBuilder logMessage = new StringBuilder();
        logMessage.Append("[");
        logMessage.Append(log.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
        logMessage.Append("] ");
        logMessage.Append(log.LogLevel);
        logMessage.Append(": ");
        logMessage.Append(log.Message);

        if (log.Exception != null)
        {
            logMessage.Append(" | Exception: ");
            logMessage.Append(log.Exception.Message);
        }

        buffer.AppendLine(logMessage.ToString());

        if (log.LogLevel.ToUpper() == "ERROR")
            errorLogs.Add(log);

        if (buffer.Length >= bufferCapacity)
            FlushBuffer();
    }

    private void FlushBuffer()
    {
        if (buffer.Length == 0) return;
        File.AppendAllText("logs.txt", buffer.ToString());
        Console.WriteLine("Buffer flushed to logs.txt");
        buffer.Clear();
    }

    public void Flush() { FlushBuffer(); }

    public void DisplayErrorSummary()
    {
        Console.WriteLine("\n===== ERROR SUMMARY =====");
        Console.WriteLine("Total Errors: " + errorLogs.Count);
        foreach (LogEntry error in errorLogs)
            Console.WriteLine($"{error.Timestamp:yyyy-MM-dd HH:mm:ss} - {error.Message}");
    }
}

class Program
{
    static void Main()
    {
        LogProcessor processor = new LogProcessor(200);

        processor.ProcessLog(new LogEntry(DateTime.Now, "INFO", "Application started"));
        processor.ProcessLog(new LogEntry(DateTime.Now, "INFO", "User logged in"));
        processor.ProcessLog(new LogEntry(DateTime.Now, "ERROR", "Database connection failed", new Exception("Unable to connect to database")));
        processor.ProcessLog(new LogEntry(DateTime.Now, "WARNING", "Memory usage is high"));
        processor.ProcessLog(new LogEntry(DateTime.Now, "ERROR", "File not found", new FileNotFoundException("Configuration file missing")));

        processor.Flush();
        processor.DisplayErrorSummary();

        Console.WriteLine("\nLog processing completed.");
    }
}
