using HarmonyLib;
using Verse;

namespace BlueprintMaterialDebt.ToggleableReadout;

[StaticConstructorOnStartup]
internal static class ToggleableReadoutPatches
{
    static ToggleableReadoutPatches()
    {
        new Harmony("me.lubar.BlueprintMaterialDebt.ToggleableReadout").PatchAll();
    }
}