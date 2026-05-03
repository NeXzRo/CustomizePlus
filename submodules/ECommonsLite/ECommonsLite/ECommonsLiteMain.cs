using Dalamud.Plugin;
using ECommonsLite.DalamudServices;
using ECommonsLite.EzIpcManager;
using ECommonsLite.Logging;
using Serilog.Events;
using System.Reflection;

#nullable disable

namespace ECommonsLite;

public static class ECommonsLiteMain
{
    public static IDalamudPlugin Instance = null;
    public static bool Disposed { get; private set; } = false;
    //test
    public static void Init(IDalamudPluginInterface pluginInterface, IDalamudPlugin instance, params Module[] modules)
    {
        Instance = instance;
        GenericHelpers.Safe(() => Svc.Init(pluginInterface));
#if DEBUG
        var type = "debug build";
#elif RELEASE
var type = "release build";
#else
var type = "unknown build";
#endif
        PluginLog.Information($"This is ECommonsLite v{typeof(ECommonsLiteMain).Assembly.GetName().Version} ({type}) and {Svc.PluginInterface.InternalName} v{instance.GetType().Assembly.GetName().Version}. Hello!");
        Svc.Log.MinimumLogLevel = LogEventLevel.Verbose;
    }

    public static void Dispose()
    {
        Disposed = true;
        GenericHelpers.Safe(EzIPC.Dispose);
        Instance = null;
    }
}
