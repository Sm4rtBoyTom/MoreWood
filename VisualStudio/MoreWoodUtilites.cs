using UnityEngine;
using Il2Cpp;
using MelonLoader;
using UnityEngine.AddressableAssets;


namespace MoreWoodMod
{
    internal static class MoreWoodUtilities
    {

        public static bool IsScenePlayable(string scene)
        {
            return !(string.IsNullOrEmpty(scene) || scene.Contains("MainMenu") || scene == "Boot" || scene == "Empty");
        }

        public static GameObject Birch = Addressables.LoadAssetAsync<GameObject>("GEAR_BirchWood").WaitForCompletion();
        
        public static GameObject Oak = Addressables.LoadAssetAsync<GameObject>("GEAR_OakFireWood").WaitForCompletion();
    }
}


