using HarmonyLib;
using Verse;

namespace BlueprintMaterialDebt.ToggleableReadout;

[StaticConstructorOnStartup]
internal static class ToggleableReadoutPatches
{
    static ToggleableReadoutPatches()
    {
        var harmony = new Harmony("me.lubar.BlueprintMaterialDebt.ToggleableReadout");
        harmony.PatchAll();
    }
}