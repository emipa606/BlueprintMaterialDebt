using System.Reflection;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace BlueprintMaterialDebt;

[HarmonyPatch(typeof(ResourceReadout), nameof(ResourceReadout.DrawResourceSimple), typeof(Rect), typeof(ThingDef))]
internal static class ResourceReadout_DrawResourceSimple_Patch
{
    private static readonly MethodInfo DrawIcon = AccessTools.Method(typeof(ResourceReadout), "DrawIcon");

    private static bool Prefix(ResourceReadout __instance, ref Rect rect, ref ThingDef thingDef)
    {
        if (!BlueprintMaterialDebt.SubtractResources)
        {
            return true;
        }

        DrawIcon.Invoke(__instance, [rect.x, rect.y, thingDef]);

        rect.y += 2f;
        var count = Find.CurrentMap.resourceCounter.GetCount(thingDef);
        var warningColor = count > 0 ? Color.yellow : Color.red;
        if (ResourceCounter_UpdateResourceCounts_Patch.neededAmounts.TryGetValue(thingDef, out var neededAmount))
        {
            count -= neededAmount;
        }

        var previousColor = GUI.color;
        if (count <= 0)
        {
            GUI.color = warningColor;
        }

        Widgets.Label(new Rect(34f, rect.y, rect.width - 34f, rect.height), count.ToStringCached());

        GUI.color = previousColor;

        return false;
    }
}