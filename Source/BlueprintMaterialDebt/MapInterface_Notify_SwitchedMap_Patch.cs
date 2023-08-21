using System;
using HarmonyLib;
using RimWorld;

namespace BlueprintMaterialDebt;

[HarmonyPatch(typeof(MapInterface), nameof(MapInterface.Notify_SwitchedMap), new Type[0])]
internal static class MapInterface_Notify_SwitchedMap_Patch
{
    private static void Postfix()
    {
        ResourceCounter_UpdateResourceCounts_Patch.Reset();
    }
}