using Verse;

namespace HarvestYieldPatch;

public class HarvestYieldSettings : ModSettings
{
    public static float PlantYieldMax = 2f;

    public static float AnimalYieldMax = 2f;

    public static float MiningYieldMax = 2f;

    public static float ButcherFleshYieldMax = 2f;

    public static float ButcherMechYieldMax = 2f;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref PlantYieldMax, "HarvestYieldMax", 2f);
        Scribe_Values.Look(ref AnimalYieldMax, "AnimalYieldMax", 2f);
        Scribe_Values.Look(ref MiningYieldMax, "MiningYieldMax", 2f);
        Scribe_Values.Look(ref ButcherFleshYieldMax, "butcherFleshYieldMax", 2f);
        Scribe_Values.Look(ref ButcherMechYieldMax, "butcherMechYieldMax", 2f);
    }
}