using HarmonyLib;
using UnityEngine;
using Verse;

namespace BlueprintMaterialDebt;

[StaticConstructorOnStartup]
public class BlueprintMaterialDebt : Mod
{
    public static bool SubtractResources = true;

    internal static readonly Texture2D ToggleIcon = ContentFinder<Texture2D>.Get("BlueprintMaterialDebtOverlayIcon");
    public static BlueprintSettings settings;

    public BlueprintMaterialDebt(ModContentPack content) : base(content)
    {
        settings = GetSettings<BlueprintSettings>();
        Harmony harmony = new("me.lubar.BlueprintMaterialDebt");
        harmony.PatchAll();
    }

    public override string SettingsCategory() => "BlueprintMaterialDebt_ModName".Translate();

    public override void DoSettingsWindowContents(Rect canvas)
    {
        Listing_Standard list = new();
        list.Begin(canvas);
        list.CheckboxLabeled("BlueprintMaterialDebt_includeForbidden_title".Translate(), ref BlueprintSettings.IncludeForbidden, "BlueprintMaterialDebt_includeForbidden_desc".Translate());
        list.End();
    }
}

public class BlueprintSettings : ModSettings
{
    internal static bool IncludeForbidden;
}
