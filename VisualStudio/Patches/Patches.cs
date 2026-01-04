using UnityEngine;
using Il2Cpp;
using MelonLoader;
using MoreWoodMod;

namespace MoreWoodMod
{
    //Patches RadialObjectSpawner to spawn Birch Wood.

    [HarmonyPatch(typeof(RadialObjectSpawner), "GetNextPrefabToSpawn")]
    internal class BirchSpawns
    {
        private static void Postfix(RadialObjectSpawner __instance, ref GameObject __result)
        {

            if (__instance != null && __instance.name.Contains("RadialSpawn_bark") && MoreWoodUtilities.Birch != null)
            {
                if (Utils.RollChance(Settings.instance.BirchChance))
                {
                    __result = MoreWoodUtilities.Birch;
                }
            }
        }
    }
    //Patches RadialObjectSpawner to spawn Oak Wood.

    [HarmonyPatch(typeof(RadialObjectSpawner), "GetNextPrefabToSpawn")]
    internal class OakSpawns
    {
        private static void Postfix(RadialObjectSpawner __instance, ref GameObject __result)
        {

            if (__instance != null && __instance.name.Contains("RadialSpawn_small_branch") && MoreWoodUtilities.Oak != null)
            {
                if (Utils.RollChance(Settings.instance.OakChance))
                {
                    __result = MoreWoodUtilities.Oak;
                }
            }
        }
    }
    [HarmonyPatch(typeof(GearItem), "Awake")]
    public class BirchWoodPatch
    {
        internal static void Postfix(ref GearItem __instance)
        {
            if (__instance.name.Contains("GEAR_BirchWood"))
            {
                FuelSourceItem F = __instance.gameObject.GetComponent<FuelSourceItem>();
                __instance.m_FuelSourceItem = F;
                if (__instance != null)
                {
                    F.m_BurnDurationHours = Settings.instance.BirchTime;
                    F.m_FireStartSkillModifier = Settings.instance.BirchBonus;
                    F.m_HeatIncrease = Settings.instance.BirchTemp;
                }
            }
        }
    }
    [HarmonyPatch(typeof(GearItem), "Awake")]
    public class BirchWoodPilePatch
    {
        internal static void Postfix(ref GearItem __instance)
        {
            if (__instance.name.Contains("GEAR_BirchWoodPile5"))
            {
                FuelSourceItem F = __instance.gameObject.GetComponent<FuelSourceItem>();
                __instance.m_FuelSourceItem = F;
                if (__instance != null)
                {
                    F.m_BurnDurationHours = Settings.instance.BirchTime * 5;
                    F.m_FireStartSkillModifier = Settings.instance.BirchBonus;
                    F.m_HeatIncrease = Settings.instance.BirchTemp * 5;
                }
            }
        }
    }
    [HarmonyPatch(typeof(GearItem), "Awake")]
    public class OakFireWoodPatch
    {
        internal static void Postfix(ref GearItem __instance) 
        {
            if (__instance.name.Contains("GEAR_OakFireWood"))
            {
                FuelSourceItem F = __instance.gameObject.GetComponent<FuelSourceItem>();
                __instance.m_FuelSourceItem= F;
                if (__instance != null)
                {
                    F.m_BurnDurationHours = Settings.instance.OakTime;
                    F.m_FireStartSkillModifier = Settings.instance.OakBonus;
                    F.m_HeatIncrease = Settings.instance.OakTemp;
                }

            }
        }
    }
    [HarmonyPatch(typeof(GearItem), "Awake")]
    public class OakFireWoodPilePatch
    {
        internal static void Postfix(ref GearItem __instance)
        {
            if (__instance.name.Contains("GEAR_OakFireWoodPile5"))
            {
                FuelSourceItem F = __instance.gameObject.GetComponent<FuelSourceItem>();
                __instance.m_FuelSourceItem = F;
                if (__instance != null)
                {
                    F.m_BurnDurationHours = Settings.instance.OakTime * 5;
                    F.m_FireStartSkillModifier = Settings.instance.OakBonus;
                    F.m_HeatIncrease = Settings.instance.OakTemp * 5;
                }

            }
        }
    }
}

