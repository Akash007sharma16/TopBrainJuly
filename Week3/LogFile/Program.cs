using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// 1. LogEntry class
class LogEntry
{
    // 2. Properties
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

// 3. LogProcessor class
class LogProcessor
{
    private StringBuilder buffer = new StringBuilder();
    private List<LogEntry> errorLogs = new List<LogEntry>();

    // Buffer capacity
    private int bufferCapacity;

    public LogProcessor(int capacity)
    {
        bufferCapacity = capacity;
    }

    // Process a log entry
    public void ProcessLog(LogEntry log)
    {
        // 4. Use StringBuilder to construct log message
        StringBuilder logMessage = new StringBuilder();

        logMessage.Append("[");
        logMessage.Append(log.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
        logMessage.Append("] ");

        logMessage.Append(log.LogLevel);
        logMessage.Append(": ");
        logMessage.Append(log.Message);

        // If exception exists, add it
        if (log.Exception != null)
        {
            logMessage.Append(" | Exception: ");
            logMessage.Append(log.Exception.Message);
        }

        // 5. Store log message in buffer
        buffer.AppendLine(logMessage.ToString());

        // 7. Store Error logs separately
        if (log.LogLevel.ToUpper() == "ERROR")
        {
            errorLogs.Add(log);
        }

        // 6. Flush buffer when capacity is reached
        if (buffer.Length >= bufferCapacity)
        {
            FlushBuffer();
        }
    }

    // Flush buffer to file
    private void FlushBuffer()
    {
        if (buffer.Length == 0)
            return;

        File.AppendAllText("logs.txt", buffer.ToString());

        Console.WriteLine("Buffer flushed to logs.txt");

        buffer.Clear();
    }

    // Flush remaining logs
    public void Flush()
    {
        FlushBuffer();
    }

    // 8. Display error summary
    public void DisplayErrorSummary()
    {
        Console.WriteLine("\n===== ERROR SUMMARY =====");

        Console.WriteLine("Total Errors: " + errorLogs.Count);

        foreach (LogEntry error in errorLogs)
        {
            Console.WriteLine(
                $"{error.Timestamp:yyyy-MM-dd HH:mm:ss} - {error.Message}"
            );
        }
    }
}

// Main Program
class Program
{
    static void Main()
    {
        // Create LogProcessor with buffer capacity
        LogProcessor processor = new LogProcessor(200);

        // Create log entries
        LogEntry log1 = new LogEntry(
            DateTime.Now,
            "INFO",
            "Application started"
        );

        LogEntry log2 = new LogEntry(
            DateTime.Now,
            "INFO",
            "User logged in"
        );

        LogEntry log3 = new LogEntry(
            DateTime.Now,
            "ERROR",
            "Database connection failed",
            new Exception("Unable to connect to database")
        );

        LogEntry log4 = new LogEntry(
            DateTime.Now,
            "WARNING",
            "Memory usage is high"
        );

        LogEntry log5 = new LogEntry(
            DateTime.Now,
            "ERROR",
            "File not found",
            new FileNotFoundException("Configuration file missing")
        );

        // Process logs
        processor.ProcessLog(log1);
        processor.ProcessLog(log2);
        processor.ProcessLog(log3);
        processor.ProcessLog(log4);
        processor.ProcessLog(log5);

        // Flush remaining logs
        processor.Flush();

        // Display error summary
        processor.DisplayErrorSummary();

        Console.WriteLine("\nLog processing completed.");
    }
}