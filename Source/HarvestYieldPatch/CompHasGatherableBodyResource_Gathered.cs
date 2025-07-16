using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace HarvestYieldPatch;

[HarmonyPatch(typeof(CompHasGatherableBodyResource), nameof(CompHasGatherableBodyResource.Gathered))]
public static class CompHasGatherableBodyResource_Gathered
{
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var roundRandom = AccessTools.Method(typeof(GenMath), nameof(GenMath.RoundRandom));
        var randChance = AccessTools.Method(typeof(Rand), nameof(Rand.Chance));
        var animalGatherYield = AccessTools.Field(typeof(StatDefOf), nameof(StatDefOf.AnimalGatherYield));
        var getStatValue = AccessTools.Method(typeof(StatExtension), nameof(StatExtension.GetStatValue), [
            typeof(Thing),
            typeof(StatDef),
            typeof(bool),
            typeof(int)
        ]);
        var found = false;
        foreach (var i in instructions)
        {
            if (i.opcode == OpCodes.Call && (MethodInfo)i.operand == randChance)
            {
                yield return i;
                yield return new CodeInstruction(OpCodes.Pop);
                found = true;
                continue;
            }

            if (found && i.opcode == OpCodes.Brtrue_S)
            {
                i.opcode = OpCodes.Br_S;
                found = false;
            }

            if (i.opcode == OpCodes.Call && (MethodInfo)i.operand == roundRandom)
            {
                yield return new CodeInstruction(OpCodes.Ldarg_1);
                yield return new CodeInstruction(OpCodes.Ldsfld, animalGatherYield);
                yield return new CodeInstruction(OpCodes.Ldc_I4_1);
                yield return new CodeInstruction(OpCodes.Ldc_I4_M1);
                yield return new CodeInstruction(OpCodes.Call, getStatValue);
                yield return new CodeInstruction(OpCodes.Mul);
            }

            yield return i;
        }
    }
}