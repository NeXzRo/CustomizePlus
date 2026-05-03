using Dalamud.Game.Text.SeStringHandling;
using ECommonsLite.Logging;
using FFXIVClientStructs.FFXIV.Client.System.String;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
#nullable disable

namespace ECommonsLite;

public static unsafe partial class GenericHelpers
{
    public static void Log(this Exception e)
    {
        PluginLog.Error($"{e.Message}\n{e.StackTrace ?? ""}");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsAny<T>(this T obj, params T[] values)
    {
        return values.Any(x => x.Equals(obj));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Safe(System.Action a, bool suppressErrors = false)
    {
        try
        {
            a();
        }
        catch (Exception e)
        {
            if (!suppressErrors) PluginLog.Error($"{e.Message}\n{e.StackTrace ?? ""}");
        }
    }
}
