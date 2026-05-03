using Dalamud.Bindings.ImGui;
using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using Action = System.Action;

namespace ECommonsLite.ImGuiMethods;
#nullable disable

public static unsafe partial class ImGuiEx
{
    public static void EzTabBar(string id, params (string name, Action function, Vector4? color, bool child)[] tabs) => EzTabBar(id, null, tabs);
    public static void EzTabBar(string id, string KoFiTransparent, params (string name, Action function, Vector4? color, bool child)[] tabs) => EzTabBar(id, KoFiTransparent, null, tabs);
    public static void EzTabBar(string id, string KoFiTransparent, string openTabName, params (string name, Action function, Vector4? color, bool child)[] tabs) => EzTabBar(id, KoFiTransparent, openTabName, ImGuiTabBarFlags.None, tabs);
    public static void EzTabBar(string id, string KoFiTransparent, string openTabName, ImGuiTabBarFlags flags, params (string name, Action function, Vector4? color, bool child)[] tabs)
    {
        if (ImGui.BeginTabBar(id, flags))
        {
            foreach (var x in tabs)
            {
                if (x.name == null) continue;
                if (x.color != null)
                {
                    ImGui.PushStyleColor(ImGuiCol.Text, x.color.Value);
                }
                if (ImGui.BeginTabItem(x.name, openTabName == x.name ? ImGuiTabItemFlags.SetSelected : ImGuiTabItemFlags.None))
                {
                    if (x.color != null)
                    {
                        ImGui.PopStyleColor();
                    }
                    if (x.child) ImGui.BeginChild(x.name + "child");
                    x.function();
                    if (x.child) ImGui.EndChild();
                    ImGui.EndTabItem();
                }
                else
                {
                    if (x.color != null)
                    {
                        ImGui.PopStyleColor();
                    }
                }
            }
            //if (KoFiTransparent != null) PatreonBanner.RightTransparentTab();
            ImGui.EndTabBar();
        }
    }
}
