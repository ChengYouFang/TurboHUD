// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
// *.txt files are not loaded automatically by TurboHUD
// you have to change this file's extension to .cs to enable it
// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

using Turbo.Plugins.Default;

namespace Turbo.Plugins.User
{

    public class PluginEnablerOrDisablerPlugin : BasePlugin, ICustomizer
    {

        public PluginEnablerOrDisablerPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        // "Customize" methods are automatically executed after every plugin is loaded.
        // So these methods can use Hud.GetPlugin<class> to access the plugin instances' public properties (like decorators, Enabled flag, parameters, etc)
        // Make sure you test the return value against null!
        public void Customize()
        {
            // basic examples

			// turn on MultiplayerExperienceRangePlugin
			Hud.TogglePlugin<MultiplayerExperienceRangePlugin>(true);

			// turn off sell darkening
			Hud.GetPlugin<InventoryAndStashPlugin>().NotGoodDisplayEnabled = false;

			// disable arcane affix label
			Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Arcane);

			// override an elite affix's text
			Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.Desecrator, "DES");
			Hud.RunOnPlugin<Resu.CraftersDelightPlugin>(plugin => 
			{
				plugin.ShowAncientRank = true; 
				plugin.SlainFarmers = true;
				plugin.DeathsBreath = true;
				plugin.VeiledCrystal = true;
				plugin.ArcaneDust = true;
				plugin.Gems = false;
				plugin.ForgottenSoul = true;
				plugin.ReusableParts = true;
				plugin.GreaterRiftKeystone = true;
				plugin.BovineBardiche = true;
				plugin.PuzzleRing = true;
				plugin.BloodShards = true;
				plugin.RamaladnisGift = true;
				plugin.Potion = true;
				plugin.InfernalMachine = true;
				plugin.Bounty = true;
				plugin.HellFire = true;
				plugin.LegendaryGems = true;
				plugin.HoradricCaches = true;
				plugin.LoreChestsDisplay = true;
				plugin.NormalChestsDisplay = true;
				plugin.ResplendentChestsDisplay = true;
				plugin.GroupGems = true; // set to false to group gems by type, set to true to group all gems
				plugin.Equipped = true; // set to false to turn off "same item as equipped" drop sound drop & rendering on minimap & inventory.
				plugin.NoobGearMode = true; // set to false to turn off Noob Gear Mode.
			});
			Hud.RunOnPlugin<Resu.OtherPlayersHeadsPlugin>(plugin => 
			{ 
				plugin.ShowCompanions = true; // set to false to not display companions
			});  
		}
	}
}