using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory.Leather
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class LeatherGlove : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leather Strikers");
			Tooltip.SetDefault("Increases weapon speed slightly");
		}
        public override void SetDefaults()
        {
            item.width = 26;
			item.height = 34;
            item.rare = 1;
            item.value = 1200;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>(mod).leatherGlove = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("OldLeather"), 6);
            recipe.AddRecipeGroup("LeadBars", 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}