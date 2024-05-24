using System.Reflection;
using HarmonyLib;
using LudeonTK;
using RimWorld;
using Verse;

namespace HarvestYieldPatch;

[StaticConstructorOnStartup]
internal static class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("syrchalis.rimworld.harvestYieldPatch").PatchAll(Assembly.GetExecutingAssembly());
        HarvestYieldCore.UpdateMaxValues();
    }

    [DebugAction("Pawns", "Force Wool Growth", actionType = DebugActionType.ToolMapForPawns,
        allowedGameStates = AllowedGameStates.PlayingOnMap)]
    public static void ForceWool(Pawn p)
    {
        var compShearable = p.TryGetComp<CompShearable>();
        if (p.Faction == null || compShearable == null)
        {
            return;
        }

        while (compShearable.Fullness < 1f)
        {
            compShearable.CompTick();
        }

        DebugActionsUtility.DustPuffFrom(p);
    }

    [DebugAction("Pawns", "Force Milk Production", actionType = DebugActionType.ToolMapForPawns,
        allowedGameStates = AllowedGameStates.PlayingOnMap)]
    public static void ForceMilk(Pawn p)
    {
        var compMilkable = p.TryGetComp<CompMilkable>();
        if (p.Faction == null || compMilkable == null)
        {
            return;
        }

        while (compMilkable.Fullness < 1f)
        {
            compMilkable.CompTick();
        }

        DebugActionsUtility.DustPuffFrom(p);
    }
}