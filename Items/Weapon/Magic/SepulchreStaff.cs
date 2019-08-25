using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Weapon.Magic
{
    public class SepulchreStaff : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Staff of the Dark Magus");
            Tooltip.SetDefault("Shoots out a ball of green flames that jumps from enemy to enemy");
        }



        public override void SetDefaults()
        {
            item.damage = 15;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.magic = true;
            item.width = 34;
            item.height = 34;
            item.useTime = 26;
            item.mana = 7;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.knockBack = 4f ;
            item.value = Terraria.Item.sellPrice(0, 3, 0, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item8;
            item.autoReuse = false;
            item.shootSpeed = 14;
            item.shoot = mod.ProjectileType("CursedBallJump");
        }
    }
}