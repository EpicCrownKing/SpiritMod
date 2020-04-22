using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class GladeWreath : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glade Wreath");
			Tooltip.SetDefault("Summons a Glade Wraith\nCan only be used in the Briar");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 16;
            item.rare = 5;
            item.maxStack = 99;

            item.useStyle = 4;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.UseSound = SoundID.Item43;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("ForestWraith")) && player.GetSpiritPlayer().ZoneReach;
        }


        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 60, mod.NPCType("ForestWraith"));
            Main.PlaySound(29, player.position, 7);
            return true;
        
        }
    }
}