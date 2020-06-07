using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
    public class MartianGrenade : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Electrosphere Grenade");
			Tooltip.SetDefault("'WARNING- HIGH VOLTAGE'");
		}


        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Grenade);
            item.shoot = ModContent.ProjectileType<Grenadeproj>();
            item.useAnimation = 30;
            item.rare = 8;
            item.ranged = true;
            item.useTime = 34;
            item.damage = 110;
			item.value = 1900;
        }

       
    }
}