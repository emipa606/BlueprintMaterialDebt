using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace BlueprintMaterialDebt;

[HarmonyPatch(nameof(ResourceReadout), "DoReadoutSimple")]
internal static class ResourceReadout_DoReadoutSimple_Patch
{
    private static readonly FieldInfo countedAmountsFieldInfo =
        AccessTools.Field(typeof(ResourceReadout), "countedAmounts");

    private static void Prefix(ResourceReadout __instance, out Dictionary<ThingDef, int> __state)
    {
        if (!BlueprintMaterialDebt.SubtractResources)
        {
            __state = [];
            return;
        }

        __state = (Dictionary<ThingDef, int>)countedAmountsFieldInfo.GetValue(__instance);
        var countedAmounts = new Dictionary<ThingDef, int>(__state);

        foreach (var neededAmount in ResourceCounter_UpdateResourceCounts_Patch.neededAmounts)
        {
            countedAmounts.TryAdd(neededAmount.Key, 0);
        }
    }

    private static void Postfix(ResourceReadout __instance, Dictionary<ThingDef, int> __state)
    {
        if (!BlueprintMaterialDebt.SubtractResources)
        {
            return;
        }

        countedAmountsFieldInfo.SetValue(__instance, __state);
    }
}