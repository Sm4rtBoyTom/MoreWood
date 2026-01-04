
using ModComponent.API.Behaviours;

namespace MoreWoodMod

{
	public class MoreWood : MelonMod
	{
        public override void OnInitializeMelon()
        {
         MelonLoader.MelonLogger.Msg(System.ConsoleColor.DarkYellow, "Spawning Birch!");
            Settings.instance.AddToModSettings("More Wood");
        }
    }
}