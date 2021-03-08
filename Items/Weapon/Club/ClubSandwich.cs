﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using SpiritMod.Items.Consumable.Food;

namespace SpiritMod.Items.Weapon.Club
{
    public class ClubSandwich : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Club Sandwich");
            Tooltip.SetDefault("Fully charged slams release sandwich bits\nCollect bits to boost stats");
        }

        public override void SetDefaults()
        {
            item.channel = true;
            item.damage = 19;
            item.width = 60;
            item.height = 60;
            item.useTime = 320;
            item.useAnimation = 320;
            item.crit = 4;
            item.useStyle = 2;
            item.melee = true;
            item.noMelee = true;
            item.knockBack = 12;
            item.useTurn = false;
            item.value = Terraria.Item.sellPrice(0, 1, 42, 0);
            item.rare = ItemRarityID.Orange;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("ClubSandwichProj");
            item.shootSpeed = 6f;
            item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override bool CanUseItem(Player player)
        {
            return base.CanUseItem(player);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Baguette>(), 1);
            recipe.AddIngredient(ModContent.ItemType<CaesarSalad>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}