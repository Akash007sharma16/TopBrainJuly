using System;
using System.Collections.Generic;
using System.Linq;

public abstract class NotificationChannel
{
    public bool TrySend(string message)
    {
        try { return Send(message); }
        catch { return false; }
    }
    protected abstract bool Send(string message);
}

public class EmailChannel : NotificationChannel
{
    protected override bool Send(string message) => true;
}

public class SmsChannel : NotificationChannel
{
    protected override bool Send(string message)
    {
        if (message.Length > 160) throw new Exception("SMS message is too long");
        return true;
    }
}

class Program
{
    static void Main()
    {
        List<NotificationChannel> channels = new List<NotificationChannel>
        {
            new EmailChannel(), new SmsChannel(), new EmailChannel(), new SmsChannel()
        };

        string shortMessage = "Hello! This is a short message.";
        string longMessage = new string('A', 161);

        var results = new List<(NotificationChannel Channel, bool Success)>();

        foreach (var channel in channels)
            results.Add((channel, channel.TrySend(shortMessage)));

        foreach (var channel in channels)
            results.Add((channel, channel.TrySend(longMessage)));

        var report = results.Select(r => new { ChannelType = r.Channel.GetType().Name, Success = r.Success });

        foreach (var entry in report)
            Console.WriteLine($"{entry.ChannelType}: {(entry.Success ? "Success" : "Failed")}");

        Console.WriteLine($"Succeeded: {report.Count(x => x.Success)}, Failed: {report.Count(x => !x.Success)}");
    }
}
