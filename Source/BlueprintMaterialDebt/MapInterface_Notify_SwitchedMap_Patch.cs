using HarmonyLib;
using RimWorld;

namespace BlueprintMaterialDebt;

[HarmonyPatch(typeof(MapInterface), nameof(MapInterface.Notify_SwitchedMap))]
internal static class MapInterface_Notify_SwitchedMap_Patch
{
    private static void Postfix()
    {
        ResourceCounter_UpdateResourceCounts_Patch.Reset();
    }
}