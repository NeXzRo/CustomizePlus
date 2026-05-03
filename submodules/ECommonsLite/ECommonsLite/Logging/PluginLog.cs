using ECommonsLite.DalamudServices;
using Serilog.Events;

namespace ECommonsLite.Logging;

public static class PluginLog
{

    public static void Information(string s)
    {
        Svc.Log.Information($"{s}");
    }
    public static void Error(string s)
    {
        Svc.Log.Error($"{s}");
    }
    public static void Fatal(string s)
    {
        Svc.Log.Fatal($"{s}");
    }
    public static void Debug(string s)
    {
        Svc.Log.Debug($"{s}");
    }
    public static void Verbose(string s)
    {
        Svc.Log.Verbose($"{s}");
    }
    public static void Warning(string s)
    {
        Svc.Log.Warning($"{s}");
    }
    public static void LogInformation(string s)
    {
        Information(s);
    }
    public static void LogError(string s)
    {
        Error(s);
    }
    public static void LogFatal(string s)
    {
        Fatal(s);
    }
    public static void LogDebug(string s)
    {
        Debug(s);
    }
    public static void LogVerbose(string s)
    {
        Verbose(s);
    }
    public static void LogWarning(string s)
    {
        Warning(s);
    }
    public static void Log(string s)
    {
        Information(s);
    }
}
