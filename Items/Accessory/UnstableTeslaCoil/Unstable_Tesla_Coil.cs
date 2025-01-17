using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory.UnstableTeslaCoil
{
	public class Unstable_Tesla_Coil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unstable Tesla Coil");
			Tooltip.SetDefault("Electrocutes nearby enemies\nElectrocuted enemies are targetted by summons\nIncreases pickup range for ores");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 30;
			item.value = Item.sellPrice(gold: 1);
			item.rare = 3;
			item.defense = 2;
			item.accessory = true;
		}
		

		public override void UpdateAccessory(Player player, bool hideVisual)
			=> player.GetSpiritPlayer().teslaCoil = true;
	}
}