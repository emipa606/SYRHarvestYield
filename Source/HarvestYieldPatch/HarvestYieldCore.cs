using Mlie;
using RimWorld;
using UnityEngine;
using Verse;

namespace HarvestYieldPatch;

public class HarvestYieldCore : Mod
{
    public static HarvestYieldSettings Settings;
    private static string currentVersion;

    public HarvestYieldCore(ModContentPack content)
        : base(content)
    {
        Settings = GetSettings<HarvestYieldSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "HarvestYieldSettingsCategory".Translate();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        if (HarvestYieldSettings.PlantYieldMax > 5f)
        {
            listingStandard.Label("HarvestYieldMax".Translate() + ": " + "Unlimited".Translate(), -1f,
                "HarvestYieldMaxTooltip".Translate());
        }
        else
        {
            listingStandard.Label(
                "HarvestYieldMax".Translate() + ": " + HarvestYieldSettings.PlantYieldMax.ToStringPercent(), -1f,
                "HarvestYieldMaxTooltip".Translate());
        }

        listingStandard.Gap(6f);
        HarvestYieldSettings.PlantYieldMax =
            listingStandard.Slider(GenMath.RoundTo(HarvestYieldSettings.PlantYieldMax, 0.1f), 1f, 5.1f);
        listingStandard.Gap();
        if (HarvestYieldSettings.AnimalYieldMax > 5f)
        {
            listingStandard.Label("AnimalYieldMax".Translate() + ": " + "Unlimited".Translate(), -1f,
                "AnimalYieldMaxTooltip".Translate());
        }
        else
        {
            listingStandard.Label(
                "AnimalYieldMax".Translate() + ": " + HarvestYieldSettings.AnimalYieldMax.ToStringPercent(), -1f,
                "AnimalYieldMaxTooltip".Translate());
        }

        listingStandard.Gap(6f);
        HarvestYieldSettings.AnimalYieldMax =
            listingStandard.Slider(GenMath.RoundTo(HarvestYieldSettings.AnimalYieldMax, 0.1f), 1f, 5.1f);
        listingStandard.Gap();
        if (HarvestYieldSettings.MiningYieldMax > 5f)
        {
            listingStandard.Label("MiningYieldMax".Translate() + ": " + "Unlimited".Translate(), -1f,
                "MiningYieldMaxTooltip".Translate());
        }
        else
        {
            listingStandard.Label(
                "MiningYieldMax".Translate() + ": " + HarvestYieldSettings.MiningYieldMax.ToStringPercent(), -1f,
                "MiningYieldMaxTooltip".Translate());
        }

        listingStandard.Gap(6f);
        HarvestYieldSettings.MiningYieldMax =
            listingStandard.Slider(GenMath.RoundTo(HarvestYieldSettings.MiningYieldMax, 0.1f), 1f, 5.1f);
        listingStandard.Gap();
        if (HarvestYieldSettings.ButcherFleshYieldMax > 5f)
        {
            listingStandard.Label("ButcherFleshYieldMax".Translate() + ": " + "Unlimited".Translate(), -1f,
                "ButcherFleshYieldMaxTooltip".Translate());
        }
        else
        {
            listingStandard.Label(
                "ButcherFleshYieldMax".Translate() + ": " + HarvestYieldSettings.ButcherFleshYieldMax.ToStringPercent(),
                -1f, "ButcherFleshYieldMaxTooltip".Translate());
        }

        listingStandard.Gap(6f);
        HarvestYieldSettings.ButcherFleshYieldMax =
            listingStandard.Slider(GenMath.RoundTo(HarvestYieldSettings.ButcherFleshYieldMax, 0.1f), 1f, 5.1f);
        listingStandard.Gap();
        if (HarvestYieldSettings.ButcherMechYieldMax > 5f)
        {
            listingStandard.Label("ButcherMechYieldMax".Translate() + ": " + "Unlimited".Translate(), -1f,
                "ButcherMechYieldMaxTooltip".Translate());
        }
        else
        {
            listingStandard.Label(
                "ButcherMechYieldMax".Translate() + ": " + HarvestYieldSettings.ButcherMechYieldMax.ToStringPercent(),
                -1f, "ButcherMechYieldMaxTooltip".Translate());
        }

        listingStandard.Gap(6f);
        HarvestYieldSettings.ButcherMechYieldMax =
            listingStandard.Slider(GenMath.RoundTo(HarvestYieldSettings.ButcherMechYieldMax, 0.1f), 1f, 5.1f);
        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("HYP.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        UpdateMaxValues();
    }

    public static void UpdateMaxValues()
    {
        StatDefOf.PlantHarvestYield.maxValue =
            HarvestYieldSettings.PlantYieldMax > 5f ? 9999999f : HarvestYieldSettings.PlantYieldMax;
        StatDefOf.AnimalGatherYield.maxValue =
            HarvestYieldSettings.AnimalYieldMax > 5f ? 9999999f : HarvestYieldSettings.AnimalYieldMax;
        StatDefOf.MiningYield.maxValue =
            HarvestYieldSettings.MiningYieldMax > 5f ? 9999999f : HarvestYieldSettings.MiningYieldMax;
        HarvestYieldDefOf.ButcheryFleshEfficiency.maxValue = HarvestYieldSettings.ButcherFleshYieldMax > 5f
            ? 9999999f
            : HarvestYieldSettings.ButcherFleshYieldMax;
        HarvestYieldDefOf.ButcheryMechanoidEfficiency.maxValue = HarvestYieldSettings.ButcherMechYieldMax > 5f
            ? 9999999f
            : HarvestYieldSettings.ButcherMechYieldMax;
    }
}