using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Sepulchre
{
	public class SepulchreBrickTwo : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlendAll[Type] = true;
			soundType = SoundID.Tink;
			Main.tileBlockLight[Type] = true;
			AddMapEntry(new Color(87, 85, 81));
			dustType = 54;
		}
	}
}
