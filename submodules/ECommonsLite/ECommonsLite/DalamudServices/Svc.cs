using Dalamud.Game;
using Dalamud.Game.ClientState.Objects;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using ECommonsLite.Logging;
using System;

namespace ECommonsLite.DalamudServices;
#nullable disable

public class Svc
{
    [PluginService] public static IDalamudPluginInterface PluginInterface { get; private set; }
    [PluginService] public static IFramework Framework { get; private set; }
    [PluginService] public static IPluginLog Log { get; private set; }

    internal static bool IsInitialized = false;
    public static void Init(IDalamudPluginInterface pi)
    {
        if(IsInitialized)
        {
            PluginLog.Debug("Services already initialized, skipping");
        }
        IsInitialized = true;
        try
        {
            pi.Create<Svc>();
        }
        catch(Exception ex)
        {
            ex.Log();
        }
    }
}
