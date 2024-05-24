using Mlie;
using RimWorld;
using UnityEngine;
using Verse;

namespace HarvestYieldPatch;

public class HarvestYieldCore : Mod
{
    public static HarvestYieldSettings settings;
    private static string currentVersion;

    public HarvestYieldCore(ModContentPack content)
        : base(content)
    {
        settings = GetSettings<HarvestYieldSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "HarvestYieldSettingsCategory".Translate();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(inRect);
        if (HarvestYieldSettings.plantYieldMax > 5f)
        {
            listing_Standard.Label("HarvestYieldMax".Translate() + ": " + "Unlimited".Translate(), -1f,
                "HarvestYieldMaxTooltip".Translate());
        }
        else
        {
            listing_Standard.Label(
                "HarvestYieldMax".Translate() + ": " + HarvestYieldSettings.plantYieldMax.ToStringPercent(), -1f,
                "HarvestYieldMaxTooltip".Translate());
        }

        listing_Standard.Gap(6f);
        HarvestYieldSettings.plantYieldMax =
            listing_Standard.Slider(GenMath.RoundTo(HarvestYieldSettings.plantYieldMax, 0.1f), 1f, 5.1f);
        listing_Standard.Gap();
        if (HarvestYieldSettings.animalYieldMax > 5f)
        {
            listing_Standard.Label("AnimalYieldMax".Translate() + ": " + "Unlimited".Translate(), -1f,
                "AnimalYieldMaxTooltip".Translate());
        }
        else
        {
            listing_Standard.Label(
                "AnimalYieldMax".Translate() + ": " + HarvestYieldSettings.animalYieldMax.ToStringPercent(), -1f,
                "AnimalYieldMaxTooltip".Translate());
        }

        listing_Standard.Gap(6f);
        HarvestYieldSettings.animalYieldMax =
            listing_Standard.Slider(GenMath.RoundTo(HarvestYieldSettings.animalYieldMax, 0.1f), 1f, 5.1f);
        listing_Standard.Gap();
        if (HarvestYieldSettings.miningYieldMax > 5f)
        {
            listing_Standard.Label("MiningYieldMax".Translate() + ": " + "Unlimited".Translate(), -1f,
                "MiningYieldMaxTooltip".Translate());
        }
        else
        {
            listing_Standard.Label(
                "MiningYieldMax".Translate() + ": " + HarvestYieldSettings.miningYieldMax.ToStringPercent(), -1f,
                "MiningYieldMaxTooltip".Translate());
        }

        listing_Standard.Gap(6f);
        HarvestYieldSettings.miningYieldMax =
            listing_Standard.Slider(GenMath.RoundTo(HarvestYieldSettings.miningYieldMax, 0.1f), 1f, 5.1f);
        listing_Standard.Gap();
        if (HarvestYieldSettings.butcherFleshYieldMax > 5f)
        {
            listing_Standard.Label("ButcherFleshYieldMax".Translate() + ": " + "Unlimited".Translate(), -1f,
                "ButcherFleshYieldMaxTooltip".Translate());
        }
        else
        {
            listing_Standard.Label(
                "ButcherFleshYieldMax".Translate() + ": " + HarvestYieldSettings.butcherFleshYieldMax.ToStringPercent(),
                -1f, "ButcherFleshYieldMaxTooltip".Translate());
        }

        listing_Standard.Gap(6f);
        HarvestYieldSettings.butcherFleshYieldMax =
            listing_Standard.Slider(GenMath.RoundTo(HarvestYieldSettings.butcherFleshYieldMax, 0.1f), 1f, 5.1f);
        listing_Standard.Gap();
        if (HarvestYieldSettings.butcherMechYieldMax > 5f)
        {
            listing_Standard.Label("ButcherMechYieldMax".Translate() + ": " + "Unlimited".Translate(), -1f,
                "ButcherMechYieldMaxTooltip".Translate());
        }
        else
        {
            listing_Standard.Label(
                "ButcherMechYieldMax".Translate() + ": " + HarvestYieldSettings.butcherMechYieldMax.ToStringPercent(),
                -1f, "ButcherMechYieldMaxTooltip".Translate());
        }

        listing_Standard.Gap(6f);
        HarvestYieldSettings.butcherMechYieldMax =
            listing_Standard.Slider(GenMath.RoundTo(HarvestYieldSettings.butcherMechYieldMax, 0.1f), 1f, 5.1f);
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("HYP.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        UpdateMaxValues();
    }

    public static void UpdateMaxValues()
    {
        StatDefOf.PlantHarvestYield.maxValue =
            HarvestYieldSettings.plantYieldMax > 5f ? 9999999f : HarvestYieldSettings.plantYieldMax;
        StatDefOf.AnimalGatherYield.maxValue =
            HarvestYieldSettings.animalYieldMax > 5f ? 9999999f : HarvestYieldSettings.animalYieldMax;
        StatDefOf.MiningYield.maxValue =
            HarvestYieldSettings.miningYieldMax > 5f ? 9999999f : HarvestYieldSettings.miningYieldMax;
        HarvestYieldDefOf.ButcheryFleshEfficiency.maxValue = HarvestYieldSettings.butcherFleshYieldMax > 5f
            ? 9999999f
            : HarvestYieldSettings.butcherFleshYieldMax;
        HarvestYieldDefOf.ButcheryMechanoidEfficiency.maxValue = HarvestYieldSettings.butcherMechYieldMax > 5f
            ? 9999999f
            : HarvestYieldSettings.butcherMechYieldMax;
    }
}