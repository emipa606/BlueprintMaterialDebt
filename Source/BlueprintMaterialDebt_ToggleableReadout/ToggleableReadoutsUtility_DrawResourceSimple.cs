using System;
using System.Reflection;
using HarmonyLib;
using ToggleableReadouts;
using UnityEngine;
using Verse;

namespace BlueprintMaterialDebt.ToggleableReadout;

[HarmonyPatch]
internal static class ToggleableReadoutsUtility_DrawResourceSimple
{
    public static MethodBase TargetMethod()
    {
        return Type.GetType("ToggleableReadouts.ToggleableReadoutsUtility,ToggleableReadouts")
            ?.GetMethod("DrawResourceSimple", BindingFlags.NonPublic | BindingFlags.Static);
    }

    public static void Prefix(ReadoutCache readOut)
    {
        if (!BlueprintMaterialDebt.SubtractResources)
        {
            return;
        }

        var thingDef = (ThingDef)readOut.def;
        if (!ResourceCounter_UpdateResourceCounts.neededAmounts.TryGetValue(thingDef, out var neededAmount))
        {
            return;
        }

        var count = readOut.value - neededAmount;
        readOut.valueLabel = count.ToStringCached();
        GUI.color = Color.yellow;
    }

    public static void Postfix()
    {
        GUI.color = Color.white;
    }
}