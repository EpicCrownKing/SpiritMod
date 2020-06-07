using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class JungleStaff : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rosevine Staff");
			Tooltip.SetDefault("Shoots a bouncing mass of vines and flowers");
		}


        public override void SetDefaults()
        {
            item.damage = 20;
            item.magic = true;
            item.mana = 9;
            item.width = 38;
            item.height = 38;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = ItemUseStyleID.HoldingOut;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = 20000;
            item.rare = 2;
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<ThornSpike>();
            item.shootSpeed = 13f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleSpores, 12);
            recipe.AddIngredient(ItemID.Stinger, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
