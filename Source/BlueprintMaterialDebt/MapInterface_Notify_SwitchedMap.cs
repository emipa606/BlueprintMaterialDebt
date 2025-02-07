﻿using HarmonyLib;
using RimWorld;

namespace BlueprintMaterialDebt;

[HarmonyPatch(typeof(MapInterface), nameof(MapInterface.Notify_SwitchedMap))]
internal static class MapInterface_Notify_SwitchedMap
{
    public static void Postfix()
    {
        ResourceCounter_UpdateResourceCounts.Reset();
    }
}