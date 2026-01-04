using Il2CppRewired.ComponentControls.Data;
using ModSettings;
using MelonLoader;
using UnityEngine;

namespace MoreWoodMod
{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();

        [Section("Birch Settings")]

        [Name("Spawn Chance")]
        [Description("Adjust the chance for Birch Wood to spawn in Birch Forests. Default: 10%.")]
        [Slider(0f, 25f, 26)]
        public float BirchChance = 10f;

        [Name("Fire Starting Bonus")]
        [Description("Adjust the fire starting percentage bonus for Birch Wood. Default: 5.")]
        [Slider(0, 20, 21)]
        public float BirchBonus = 5;

        [Name("Temperature Increase")]
        [Description("Adjust the Amount of Heat that Birch Wood gives. Default: 5.")]
        [Slider(0, 15, 16)]
        public float BirchTemp = 5;

        [Name("Burning Time")]
        [Description("Adjust the amount of time that Birch Wood burns for. Default: 1 hour.")]
        [Slider(0.5f, 3f, 6)]
        public float BirchTime = 1f;


        [Section("Oak Settings")]

        [Name("Oak Wood Spawn Chance")]
        [Description("Adjust the chance for Birch Wood to spawn in Forests. Default: 10%.")]
        [Slider(0f, 25f, 26)]
        public float OakChance = 10f;

        [Name("Fire Starting Bonus")]
        [Description("Adjust the fire starting percentage bonus for Oak Wood. Default: -5.")]
        [Slider(-5, 10, 16)]
        public float OakBonus = -5;

        [Name("Temperature Increase")]
        [Description("Adjust the Amount of Heat that Birch Wood gives. Default: 15.")]
        [Slider(0, 20, 21)]
        public float OakTemp = 15;

        [Name("Burning Time")]
        [Description("Adjust the amount of time that Oak Wood burns for. Default:  2 hours.")]
        [Slider(1f, 4f, 7)]
        public float OakTime = 2f;


        [Section("Reset Settings")]
        [Name("Reset To Default")]
        [Description("Resets all settings to Default. (Confirm and scene reload/transition required.)")]
        public bool ResetSettings = false;

        protected override void OnConfirm()
        {
            ApplyReset();
            instance.ResetSettings = false;
            base.OnConfirm();
            instance.RefreshGUI();
        }

        public static void ApplyReset()
        {
            if(instance.ResetSettings==true)
            {
                instance.BirchChance = 10f;
                instance.OakChance = 10f;
                instance.BirchTime = 1f;
                instance.BirchBonus = 5;
                instance.BirchTemp = 5;
                instance.OakBonus = -5;
                instance.OakTemp = 15;
                instance.OakTime = 2f;
            }
        }
    }
}