﻿using Microsoft.Xna.Framework;
using SpiritMod.Items.Material;
using SpiritMod.Items.Weapon.Gun;
using SpiritMod.Items.Weapon.Thrown;
using SpiritMod.NPCs.Ocean;
using SpiritMod.Items.Consumable.Food;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.Items;
using SpiritMod.Tiles.Ambient;

namespace SpiritMod.Tiles
{
	public class GTile : GlobalTile
	{
		int[] TileArray2 = { 0, 3, 185, 186, 187, 71, 28 };
		public int tremorItem = 0;

		static ushort IceType1 = (ushort)ModContent.TileType<Ambient.IceSculpture.Hostile.IceWheezerHostile>();
		static ushort IceType2 = (ushort)ModContent.TileType<Ambient.IceSculpture.IceWheezerPassive>();
		static ushort IceType3 = (ushort)ModContent.TileType<Ambient.IceSculpture.Hostile.IceVikingHostile>();
		static ushort IceType4 = (ushort)ModContent.TileType<Ambient.IceSculpture.IceVikingPassive>();
		static ushort IceType5 = (ushort)ModContent.TileType<Ambient.IceSculpture.Hostile.IceBatHostile>();
		static ushort IceType6 = (ushort)ModContent.TileType<Ambient.IceSculpture.IceBatPassive>();
		static ushort IceType7 = (ushort)ModContent.TileType<Ambient.IceSculpture.Hostile.IceFlinxHostile>();
		static ushort IceType8 = (ushort)ModContent.TileType<Ambient.IceSculpture.IceFlinxPassive>();
		public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
		{
			Tile tileAbove = Framing.GetTileSafely(i, j - 1);
			ushort eggType = (ushort)ModContent.TileType<Ambient.AvianEgg>();
			ushort flowerType = (ushort)ModContent.TileType<BloodBlossom>();
			if (type == flowerType || tileAbove.type == flowerType) {
				return false;
			}
			else if (type != eggType && tileAbove.type == eggType) {
				return false;
			}
			else if (type != IceType1 && tileAbove.type == IceType1) {
				return false;
			}
			else if (type != IceType2 && tileAbove.type == IceType2) {
				return false;
			}
			else if (type != IceType3 && tileAbove.type == IceType3) {
				return false;
			}
			else if (type != IceType4 && tileAbove.type == IceType4) {
				return false;
			}
			else if (type != IceType5 && tileAbove.type == IceType5) {
				return false;
			}
			else if (type != IceType6 && tileAbove.type == IceType6) {
				return false;
			}
			else if (type != IceType7 && tileAbove.type == IceType7) {
				return false;
			}
			else if (type != IceType8 && tileAbove.type == IceType8) {
				return false;
			}
			return base.CanKillTile(i, j, type, ref blockDamaged);
		}
        public virtual bool Slope(int i, int j, int type)
        {
            Tile tileAbove = Framing.GetTileSafely(i, j - 1);
            Tile tileRight = Framing.GetTileSafely(i + 1, j - 1);
            Tile tileLeft = Framing.GetTileSafely(i - 1, j - 1);
            ushort eggType = (ushort)ModContent.TileType<Ambient.AvianEgg>();
			ushort flowerType = (ushort)ModContent.TileType<BloodBlossom>();
			if (type == flowerType || tileAbove.type == flowerType) {
				return false;
			}
			else if (type == eggType || tileAbove.type == eggType) {
				return false;
			}
			else if (type != IceType1 && tileAbove.type == IceType1) {
				return false;
			}
			else if (type != IceType2 && tileAbove.type == IceType2) {
				return false;
			}
			else if (type != IceType3 && tileAbove.type == IceType3) {
				return false;
			}
			else if (type != IceType4 && tileAbove.type == IceType4) {
				return false;
			}
			else if (type != IceType5 && tileAbove.type == IceType5) {
				return false;
			}
			else if (type != IceType6 && tileAbove.type == IceType6) {
				return false;
			}
			else if (type != IceType7 && tileAbove.type == IceType7) {
				return false;
			}
			else if (type != IceType8 && tileAbove.type == IceType8) {
				return false;
			}
            return base.Slope(i, j, type);
        }
        public override bool CanExplode(int i, int j, int type)
		{
			Tile tileAbove = Framing.GetTileSafely(i, j - 1);
			ushort eggType = (ushort)ModContent.TileType<Ambient.AvianEgg>();
			ushort flowerType = (ushort)ModContent.TileType<BloodBlossom>();
			if (type == flowerType || tileAbove.type == flowerType) {
				return false;
			}
			else if (type == eggType || tileAbove.type == eggType) {
				return false;
			}
			else if (type != IceType1 && tileAbove.type == IceType1) {
				return false;
			}
			else if (type != IceType2 && tileAbove.type == IceType2) {
				return false;
			}
			else if (type != IceType3 && tileAbove.type == IceType3) {
				return false;
			}
			else if (type != IceType4 && tileAbove.type == IceType4) {
				return false;
			}
			else if (type != IceType5 && tileAbove.type == IceType5) {
				return false;
			}
			else if (type != IceType6 && tileAbove.type == IceType6) {
				return false;
			}
			else if (type != IceType7 && tileAbove.type == IceType7) {
				return false;
			}
			else if (type != IceType8 && tileAbove.type == IceType8) {
				return false;
			}
			return base.CanExplode(i, j, type);
		}
		int[] TileArray212 = { 0, 3, 185, 186, 187, 71, 28 };
		public override void RandomUpdate(int i, int j, int type)
		{
			if (type == TileID.CorruptGrass || type == TileID.Ebonstone) {
				if (MyWorld.CorruptHazards < 20) {
					if ((TileArray212.Contains(Framing.GetTileSafely(i, j - 1).type) && TileArray212.Contains(Framing.GetTileSafely(i, j - 2).type) && TileArray212.Contains(Framing.GetTileSafely(i, j - 3).type)) && (j > (int)Main.worldSurface - 100 && j < (int)Main.rockLayer - 20)) {
						if (Main.rand.Next(450) == 0) {
							WorldGen.PlaceObject(i, j - 1, ModContent.TileType<Corpsebloom>());
							NetMessage.SendObjectPlacment(-1, i, j - 1, ModContent.TileType<Corpsebloom>(), 0, 0, -1, -1);
						}
						if (Main.rand.Next(450) == 0) {
							WorldGen.PlaceObject(i, j - 1, ModContent.TileType<Corpsebloom1>());
							NetMessage.SendObjectPlacment(-1, i, j - 1, ModContent.TileType<Corpsebloom1>(), 0, 0, -1, -1);
						}
						if (Main.rand.Next(450) == 0) {
							WorldGen.PlaceObject(i, j - 1, ModContent.TileType<Corpsebloom2>());
							NetMessage.SendObjectPlacment(-1, i, j - 1, ModContent.TileType<Corpsebloom2>(), 0, 0, -1, -1);
						}
					}
				}
			}
		}
		public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			Player player = Main.LocalPlayer;
			MyPlayer modPlayer = player.GetSpiritPlayer();
			if (type == 1 || type == 25 || type == 117 || type == 203 || type == 57) {
				if (Main.rand.Next(50) == 1 && modPlayer.gemPickaxe) {
					tremorItem = Main.rand.Next(new int[] { 11, 12, 13, 14, 699, 700, 701, 702, 999, 182, 178, 179, 177, 180, 181 });
					if (Main.hardMode) {
						tremorItem = Main.rand.Next(new int[] { 11, 12, 13, 14, 699, 700, 701, 702, 999, 182, 178, 179, 177, 180, 181, 364, 365, 366, 1104, 1105, 1106 });
					}
					Item.NewItem(i * 16, j * 16, 64, 48, tremorItem, Main.rand.Next(1, 3));
				}
			}
			if (player.HasItem(ModContent.ItemType<Spineshot>())) {
				if (type == 3 || type == 24 || type == 61 || type == 71 || type == 110 || type == 201) {
					Item.NewItem(i * 16, j * 16, 64, 48, ItemID.Seed, Main.rand.Next(1, 3));
				}
			}
		}
		public override void FloorVisuals(int type, Player player)
		{
			foreach (var effect in player.GetSpiritPlayer().effects)
				effect.TileFloorVisuals(type, player);

			if (type == TileID.Sand && player.GetSpiritPlayer().scarabCharm) {
				player.jumpSpeedBoost += .15f;
			}
		}
		public override bool Drop(int i, int j, int type)
		{
			Player player = Main.LocalPlayer;
			MyPlayer modPlayer = player.GetSpiritPlayer();
			if (type == TileID.PalmTree && Main.rand.Next(3) == 0 && player.ZoneBeach) {
				if (Main.rand.Next(2) == 1) {
					Item.NewItem(i * 16, j * 16, 64, 48, ModContent.ItemType<Coconut>(), Main.rand.Next(5, 8));
				}
				if (NPC.CountNPCS(ModContent.NPCType<OceanSlime>()) < 1) {
					NPC.NewNPC(i * 16, (j - 10) * 16, ModContent.NPCType<OceanSlime>(), 0, 0.0f, -8.5f, 0.0f, 0.0f, (int)byte.MaxValue);
				}
			}

			if (type == 72) {
				Item.NewItem(i * 16, j * 16, 64, 48, ModContent.ItemType<GlowRoot>(), Main.rand.Next(0, 2));
			}
			if (type == TileID.Trees && Main.rand.Next(25) == 0 && player.ZoneSnow) {
				if (Main.rand.Next(4) == 1) {
					Item.NewItem(i * 16, j * 16, 64, 48, ModContent.ItemType<IceBerries>(), Main.rand.Next(1, 3));
				}
			}
			return base.Drop(i, j, type);
		}
	}
}