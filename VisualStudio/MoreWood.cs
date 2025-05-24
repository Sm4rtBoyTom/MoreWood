
using ModComponent.API.Behaviours;

namespace MoreWoodMod

{
    /// <inheritdoc/>
	public class MoreWood : MelonMod
	{
        /// <inheritdoc/>
        public override void OnInitializeMelon()
        {
         MelonLoader.MelonLogger.Msg(System.ConsoleColor.DarkYellow, "Spawning Birch!");
            Settings.instance.AddToModSettings("More Wood");
        }
        public static bool Sceneloaded;
        public override void OnSceneWasLoaded(int buildindex, string scenename)
        {
            if (MoreWoodUtilities.IsScenePlayable(scenename))
            {
                Sceneloaded = true;

                changeItemProperties();
            }
        }
        private static void changeItemProperties()
        {
            // Birch Wood
            GameObject gearBirch = GearItem.LoadGearItemPrefab("GEAR_BirchWood").gameObject;
            var birchFuel = gearBirch.GetComponent<FuelSourceItem>();
            birchFuel.m_BurnDurationHours = Settings.instance.BirchTime;
            birchFuel.m_FireStartSkillModifier = Settings.instance.BirchBonus;
            birchFuel.m_HeatIncrease = Settings.instance.BirchTemp;

            // Birch Wood Pile (x5)
            GameObject gearBirchPile = GearItem.LoadGearItemPrefab("GEAR_BirchWoodPile5").gameObject;
            var birchPileFuel = gearBirchPile.GetComponent<FuelSourceItem>();
            birchPileFuel.m_BurnDurationHours = birchFuel.m_BurnDurationHours * 5f;
            birchPileFuel.m_FireStartSkillModifier = birchFuel.m_FireStartSkillModifier;
            birchPileFuel.m_HeatIncrease = birchFuel.m_HeatIncrease * 5f;

            // Oak Firewood
            GameObject gearOak = GearItem.LoadGearItemPrefab("GEAR_OakFireWood").gameObject;
            var oakFuel = gearOak.GetComponent<FuelSourceItem>();
            oakFuel.m_BurnDurationHours = Settings.instance.OakTime;
            oakFuel.m_FireStartSkillModifier = Settings.instance.OakBonus;
            oakFuel.m_HeatIncrease = Settings.instance.OakTemp;

            // Oak Firewood Pile (x5)
            GameObject gearOakPile = GearItem.LoadGearItemPrefab("GEAR_OakFireWoodPile5").gameObject;
            var oakPileFuel = gearOakPile.GetComponent<FuelSourceItem>();
            oakPileFuel.m_BurnDurationHours = oakFuel.m_BurnDurationHours * 5f;
            oakPileFuel.m_FireStartSkillModifier = oakFuel.m_FireStartSkillModifier;
            oakPileFuel.m_HeatIncrease = oakFuel.m_HeatIncrease * 5f;
        }
    }
}