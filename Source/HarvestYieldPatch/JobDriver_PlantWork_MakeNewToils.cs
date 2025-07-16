using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace HarvestYieldPatch;

[HarmonyPatch(typeof(JobDriver_PlantWork), "MakeNewToils")]
public static class JobDriver_PlantWork_MakeNewToils
{
    private static readonly MethodInfo newYieldNowMethod =
        typeof(JobDriver_PlantWork_MakeNewToils).GetMethod(nameof(YieldNowPatch));

    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var yieldNow = AccessTools.Method(typeof(Plant), nameof(Plant.YieldNow));
        foreach (var instruction in instructions)
        {
            if (instruction.opcode == OpCodes.Callvirt && (MethodInfo)instruction.operand == yieldNow)
            {
                yield return new CodeInstruction(OpCodes.Ldloc_0);
                yield return new CodeInstruction(OpCodes.Call, newYieldNowMethod);
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