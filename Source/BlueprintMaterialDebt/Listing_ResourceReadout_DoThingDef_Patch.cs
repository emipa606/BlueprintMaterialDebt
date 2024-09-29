using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace BlueprintMaterialDebt;

[HarmonyPatch(typeof(Listing_ResourceReadout), "DoThingDef", typeof(ThingDef), typeof(int))]
internal static class Listing_ResourceReadout_DoThingDef_Patch
{
    private static bool Prefix(Listing_ResourceReadout __instance, Map ___map, float ___nestIndentWidth,
        ref float ___curY, ref ThingDef thingDef, ref int nestLevel)
    {
        if (!BlueprintMaterialDebt.SubtractResources)
        {
            return true;
        }

        var count = ___map.resourceCounter.GetCount(thingDef);

        var warningColor = count > 0 ? Color.yellow : Color.red;

        if (ResourceCounter_UpdateResourceCounts_Patch.neededAmounts.TryGetValue(thingDef, out var neededAmount))
        {
            count -= neededAmount;
        }
        else if (count == 0)
        {
            return false;
        }

        var rect = new Rect(0f, ___curY, __instance.ColumnWidth, __instance.lineHeight)
        {
            xMin = (nestLevel * ___nestIndentWidth) + 18f
        };
        if (Mouse.IsOver(rect))
        {
            GUI.DrawTexture(rect, TexUI.HighlightTex);
        }

        if (Mouse.IsOver(rect))
        {
            var thing = thingDef;
            TooltipHandler.TipRegion(rect,
                new TipSignal(() => thing.LabelCap + ": " + thing.description.CapitalizeFirst(), thingDef.shortHash));
        }

        var rect2 = new Rect(rect);
        rect2.width = rect2.height = 28f;
        rect2.y = rect.y + (rect.height / 2f) - (rect2.height / 2f);
        Widgets.ThingIcon(rect2, thingDef);

        var rect3 = new Rect(rect)
        {
            xMin = rect2.xMax + 6f
        };

        var previousColor = GUI.color;
        if (count <= 0)
        {
            GUI.color = warningColor;
        }

        Widgets.Label(rect3, count.ToStringCached());

        GUI.color = previousColor;

        ___curY += __instance.lineHeight + __instance.verticalSpacing;

        return false;
    }
}