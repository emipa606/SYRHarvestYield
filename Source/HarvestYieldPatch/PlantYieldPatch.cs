using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace HarvestYieldPatch;

public static class PlantYieldPatch
{
    public static readonly MethodInfo NewYieldNowMethod = typeof(PlantYieldPatch).GetMethod(nameof(YieldNowPatch));

    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var YieldNow = AccessTools.Method(typeof(Plant), nameof(Plant.YieldNow));
        foreach (var instruction in instructions)
        {
            if (instruction.opcode == OpCodes.Callvirt && (MethodInfo)instruction.operand == YieldNow)
            {
                yield return new CodeInstruction(OpCodes.Ldloc_0);
                yield return new CodeInstruction(OpCodes.Call, NewYieldNowMethod);
            }
            else
            {
                yield return instruction;
            }
        }
    }

    public static int YieldNowPatch(Plant p, Pawn actor)
    {
        return GenMath.RoundRandom(p.YieldNow() * actor.GetStatValue(StatDefOf.PlantHarvestYield));
    }
}