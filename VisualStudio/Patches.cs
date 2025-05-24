using UnityEngine;
using Il2Cpp;
using MelonLoader;

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

            if (__instance != null && __instance.name.Contains("RadialSpawn_branches_hard") && MoreWoodUtilities.Oak != null)
            {
                if (Utils.RollChance(Settings.instance.OakChance))
                {
                    __result = MoreWoodUtilities.Oak;
                }
            }
        }
    }
}

