﻿
using Microsoft.Xna.Framework;
using SpiritMod.Projectiles.Hostile;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Tides
{
	public class KakamoraShaman : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kakamora Shaman");
			Main.npcFrameCount[npc.type] = 7;
		}

		public override void SetDefaults()
		{
			npc.width = 52;
			npc.height = 50;
			npc.damage = 24;
			npc.defense = 4;
			aiType = NPCID.SnowFlinx;
			npc.aiStyle = 3;
			npc.lifeMax = 120;
			npc.knockBackResist = .70f;
			npc.value = 200f;
			npc.noTileCollide = false;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath1;
		}
		bool blocking = false;
		int blockTimer = 0;
		public override void AI()
		{
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			blockTimer++;
			if(blockTimer == 200) {
				Main.PlaySound(SoundLoader.customSoundType, npc.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/Kakamora/KakamoraThrow"));
				npc.frameCounter = 0;
				healed = false;
			}
			if(blockTimer > 200) {
				blocking = true;
			}
			if(blockTimer > 350) {
				blocking = false;
				blockTimer = 0;
				npc.frameCounter = 0;
			}
			if(blocking) {
				npc.aiStyle = 0;
				npc.velocity.X = 0;
				npc.defense = 999;
				npc.HitSound = SoundID.NPCHit4;
				if(player.position.X > npc.position.X) {
					npc.spriteDirection = 1;
				} else {
					npc.spriteDirection = -1;
				}
			} else {
				npc.spriteDirection = npc.direction;
				npc.aiStyle = 3;
				npc.defense = 6;
				npc.HitSound = SoundID.NPCHit2;
				if(Main.rand.NextBool(1500)) {
					Main.PlaySound(SoundLoader.customSoundType, npc.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/Kakamora/KakamoraIdle3"));
				}
				var list = Main.npc.Where(x => x.Hitbox.Intersects(npc.Hitbox));
				foreach(var npc2 in list) {
					if(npc2.type == ModContent.NPCType<LargeCrustecean>() && npc.Center.Y > npc2.Center.Y && npc2.active) {
						npc.velocity.X = npc2.direction * 7;
						npc.velocity.Y = -2;
						Main.PlaySound(SoundLoader.customSoundType, npc.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/Kakamora/KakamoraHit"));
					}
				}
			}
		}
		public override void FindFrame(int frameHeight)
		{
			if(npc.collideY && !blocking) {
				npc.frameCounter += 0.2f;
				npc.frameCounter %= 4;
				int frame = (int)npc.frameCounter;
				npc.frame.Y = frame * frameHeight;
			}
			if(blocking) {
				npc.frameCounter += 0.05f;
				if(npc.frameCounter > 2 && !healed) {
					var list = Main.npc;
					foreach(var npc2 in list) {
						if(npc2.type == ModContent.NPCType<KakamoraRunner>() || npc2.type == ModContent.NPCType<KakamoraShielder>() || npc2.type == ModContent.NPCType<KakamoraShielderRare>() || npc2.type == ModContent.NPCType<SpearKakamora>() || npc2.type == ModContent.NPCType<SwordKakamora>()) {
							if(Math.Abs(npc2.position.X - npc.position.X) < 500 && npc2.active) //500 is distance away he heals
							{
								int bolt = Terraria.Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-66, 66), npc.Center.Y - Main.rand.Next(60, 120), 0, 0, ModContent.ProjectileType<ShamanBolt>(), 0, 0);
								Projectile p = Main.projectile[bolt];
								Vector2 direction = npc2.Center - p.Center;
								direction.Normalize();
								direction *= 4;
								p.velocity = direction;
								p.ai[0] = direction.X;
								p.ai[1] = direction.Y;
							}
						}
					}
					for(int j = 0; j < 25; j++) {
						Dust.NewDustPerfect(new Vector2(npc.Center.X + npc.direction * 22, npc.Center.Y), 173, new Vector2(Main.rand.NextFloat(-6, 6), Main.rand.NextFloat(-16, 0)));
					}
					healed = true;
				}
				npc.frameCounter = MathHelper.Clamp((float)npc.frameCounter, 0, 2.9f);
				int frame = (int)npc.frameCounter;
				npc.frame.Y = (frame + 4) * frameHeight;
			}
		}
		bool healed = false;
		public override void HitEffect(int hitDirection, double damage)
		{
			if(npc.life <= 0) {
				Main.PlaySound(SoundLoader.customSoundType, npc.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/Kakamora/KakamoraDeath"));
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Kakamora_Gore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Kakamora_Gore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Kakamora_Gore3"), 1f);
			} else if(!blocking) {
				Main.PlaySound(SoundLoader.customSoundType, npc.position, mod.GetSoundSlot(SoundType.Custom, "Sounds/Kakamora/KakamoraHit"));
			}
		}
	}
}