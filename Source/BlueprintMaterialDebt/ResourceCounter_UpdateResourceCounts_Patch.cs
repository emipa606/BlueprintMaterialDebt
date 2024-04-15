using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace BlueprintMaterialDebt;

[HarmonyPatch(typeof(ResourceCounter), nameof(ResourceCounter.UpdateResourceCounts))]
public static class ResourceCounter_UpdateResourceCounts_Patch
{
    private static readonly HashSet<ThingDef> forcedVisible = [];
    public static readonly Dictionary<ThingDef, int> neededAmounts = new Dictionary<ThingDef, int>();

    private static void Postfix(Map ___map)
    {
        if (___map != Find.CurrentMap)
        {
            // only update for current map
            return;
        }

        Reset();

        foreach (var thing in ___map.listerThings.ThingsInGroup(ThingRequestGroup.Blueprint))
        {
            if (thing is not Blueprint_Build blueprint)
            {
                continue;
            }

            if (blueprint.IsForbidden(Faction.OfPlayer) && !BlueprintSettings.IncludeForbidden)
            {
                continue;
            }

            foreach (var material in blueprint.TotalMaterialCost())
            {
                if (neededAmounts.ContainsKey(material.thingDef))
                {
                    neededAmounts[material.thingDef] += material.count;
                }
                else
                {
                    neededAmounts.Add(material.thingDef, material.count);
                }
            }
        }

        foreach (var thing in ___map.listerThings.ThingsInGroup(ThingRequestGroup.BuildingFrame))
        {
            if (thing is not Frame frame)
            {
                continue;
            }

            if (frame.IsForbidden(Faction.OfPlayer) && !BlueprintSettings.IncludeForbidden)
            {
                continue;
            }

            foreach (var material in frame.TotalMaterialCost())
            {
                if (neededAmounts.ContainsKey(material.thingDef))
                {
                    neededAmounts[material.thingDef] += material.count;
                }
                else
                {
                    neededAmounts.Add(material.thingDef, material.count);
                }
            }
        }

        foreach (var material in neededAmounts.Keys)
        {
            if (material.resourceReadoutAlwaysShow)
            {
                continue;
            }

            material.resourceReadoutAlwaysShow = true;

            forcedVisible.Add(material);
        }
    }

    internal static void Reset()
    {
        foreach (var thing in forcedVisible)
        {
            thing.resourceReadoutAlwaysShow = false;
        }

        forcedVisible.Clear();
        neededAmounts.Clear();
    }
}