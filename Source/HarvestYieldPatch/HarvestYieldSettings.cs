using Verse;

namespace HarvestYieldPatch;

public class HarvestYieldSettings : ModSettings
{
    public static float plantYieldMax = 2f;

    public static float animalYieldMax = 2f;

    public static float miningYieldMax = 2f;

    public static float butcherFleshYieldMax = 2f;

    public static float butcherMechYieldMax = 2f;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref plantYieldMax, "HarvestYieldMax", 2f);
        Scribe_Values.Look(ref animalYieldMax, "AnimalYieldMax", 2f);
        Scribe_Values.Look(ref miningYieldMax, "MiningYieldMax", 2f);
        Scribe_Values.Look(ref butcherFleshYieldMax, "butcherFleshYieldMax", 2f);
        Scribe_Values.Look(ref butcherMechYieldMax, "butcherMechYieldMax", 2f);
    }
}