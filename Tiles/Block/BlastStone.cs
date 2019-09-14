using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.World.Generation;
using SpiritMod;

namespace SpiritMod.Tiles.Block
{
	public class BlastStone : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlendAll[this.Type] = true;
			Main.tileBlockLight[Type] = true;
			AddMapEntry(new Color(87, 85, 81));
			drop = mod.ItemType("BlastStone");
			dustType = 54;
		}

		public override bool CanExplode(int i, int j)
		{
            if (!MyWorld.downedScarabeus)
            {
			return false;
            }
            return true;
		}
		public override bool CanKillTile(int i, int j, ref bool blockDamaged)
		{
            if (!MyWorld.downedScarabeus)
            {
			return false;
            }
            return true;
		}
	}
}
