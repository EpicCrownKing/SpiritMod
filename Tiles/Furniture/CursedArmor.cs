﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SpiritMod.Tiles.Furniture
{
	public class CursedArmor : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = false;

			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.Origin = new Point16(0, 3);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();

			mineResist = 0.2f;

			name.SetDefault("Cursed Armor");
			AddMapEntry(Colors.RarityAmber, name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Main.PlaySound(new LegacySoundStyle(SoundID.NPCKilled, 6).WithPitchVariance(0.2f), new Vector2(i * 16, j * 16));
			NPC npc = Main.npc[NPC.NewNPC(i * 16, j * 16, NPCID.Golem)];
			if (Main.netMode != NetmodeID.SinglePlayer)
				NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc.whoAmI);
		}
	}
}
