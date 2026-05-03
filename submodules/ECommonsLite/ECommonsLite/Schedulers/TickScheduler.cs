using ECommonsLite.DalamudServices;
using ECommonsLite.Logging;
using System;

namespace ECommonsLite.Schedulers;

public class TickScheduler : IScheduler
{
    private long ExecuteAt;
    private Action Action;
    public bool Disposed { get; private set; } = false;

    public TickScheduler(Action function, long delayMS = 0)
    {
        ExecuteAt = Environment.TickCount64 + delayMS;
        this.Action = function;
        Svc.Framework.Update += Execute;
    }

    public void Dispose()
    {
        if(!Disposed)
        {
            Svc.Framework.Update -= Execute;
        }
        Disposed = true;
    }

    private void Execute(object _)
    {
        if(Environment.TickCount64 < ExecuteAt) return;
        try
        {
            Action();
        }
        catch(Exception e)
        {
            PluginLog.Error(e.Message + "\n" + e.StackTrace ?? "");
        }
        Dispose();
    }
}