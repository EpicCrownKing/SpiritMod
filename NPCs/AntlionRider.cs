﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
	public class AntlionRider : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Rider");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.width = 22;
			npc.height = 32;
			npc.damage = 16;
			npc.defense = 8;
			npc.lifeMax = 59;
			npc.HitSound = SoundID.NPCHit32;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 329f;
			npc.knockBackResist = .65f;
			npc.aiStyle = 3;
			aiType = NPCID.AngryBones;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{

			if (Main.tileSand[spawnInfo.spawnTileType])
				return SpawnCondition.OverworldDayDesert.Chance * .812f;
			return 0;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.20f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
		}

		// localai0 : 0 when spawned, 1 when otherNPC spawned. 
		// ai0 = npc number of other NPC
		// ai1 = charge time for gun.
		// ai2 = used for frame??
		// ai3 = 
		public override void AI()
		{
			int otherNPC = -1;
			Vector2 offsetFromOtherNPC = Vector2.Zero;
			if (npc.localAI[0] == 0f && Main.netMode != NetmodeID.MultiplayerClient) {
				npc.localAI[0] = 1f;
				int newNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, 509, npc.whoAmI, 0f, 0f, 0f, 0f, 255);
				npc.ai[0] = (float)newNPC;
				npc.netUpdate = true;
			}
			int otherNPCCheck = (int)npc.ai[0];
			if (Main.npc[otherNPCCheck].active && Main.npc[otherNPCCheck].type == NPCID.FlyingAntlion) {
				if (npc.timeLeft < 60) {
					npc.timeLeft = 60;
				}
				otherNPC = otherNPCCheck;
				offsetFromOtherNPC = Vector2.UnitY * -24f;
			}

			// If otherNPC exists, do this
			if (otherNPC != -1) {
				NPC nPC7 = Main.npc[otherNPC];
				npc.velocity = Vector2.Zero;
				npc.position = nPC7.Center;
				npc.position.X = npc.position.X - (float)(npc.width / 2);
				npc.position.Y = npc.position.Y - (float)(npc.height / 2);
				npc.position += offsetFromOtherNPC;
				npc.gfxOffY = nPC7.gfxOffY;
				npc.direction = nPC7.direction;
				npc.spriteDirection = nPC7.spriteDirection;
				npc.rotation = nPC7.velocity.X * .1f;
				npc.timeLeft = nPC7.timeLeft;
				npc.velocity = nPC7.velocity;
				npc.target = nPC7.target;
				if (npc.ai[1] < 60f) {
					npc.ai[1] += 1f;
				}
				if (npc.justHit) {
					npc.ai[1] = -30f;
				}
				int projectileType = Terraria.ID.ProjectileID.RayGunnerLaser;// 438;
				int projectileDamage = 30;
				float scaleFactor20 = 7f;
				if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height)) {
					Vector2 vectorToPlayer = Main.player[npc.target].Center - npc.Center;
					Vector2 vectorToPlayerNormalized = Vector2.Normalize(vectorToPlayer);
					float num1547 = vectorToPlayer.Length();
					float num1548 = 700f;

					if (num1547 < num1548) {
						if (npc.ai[1] == 60f && Math.Sign(vectorToPlayer.X) == npc.direction) {
							npc.ai[1] = -60f;
							Vector2 center12 = Main.player[npc.target].Center;
							Vector2 value26 = npc.Center - Vector2.UnitY * 4f;
							Vector2 vector188 = center12 - value26;
							vector188.X += (float)Main.rand.Next(-50, 51);
							vector188.Y += (float)Main.rand.Next(-50, 51);
							vector188.X *= (float)Main.rand.Next(80, 121) * 0.01f;
							vector188.Y *= (float)Main.rand.Next(80, 121) * 0.01f;
							vector188.Normalize();
							if (float.IsNaN(vector188.X) || float.IsNaN(vector188.Y)) {
								vector188 = -Vector2.UnitY;
							}
							vector188 *= scaleFactor20;
							Projectile.NewProjectile(value26.X, value26.Y, vector188.X, vector188.Y, projectileType, projectileDamage, 0f, Main.myPlayer, 0f, 0f);
							npc.netUpdate = true;
						}
						else {
							float oldAI2 = npc.ai[2];
							npc.velocity.X = npc.velocity.X * 0.5f;
							npc.ai[2] = 3f;
							if (Math.Abs(vectorToPlayerNormalized.Y) > Math.Abs(vectorToPlayerNormalized.X) * 2f) {
								if (vectorToPlayerNormalized.Y > 0f) {
									npc.ai[2] = 1f;
								}
								else {
									npc.ai[2] = 5f;
								}
							}
							else if (Math.Abs(vectorToPlayerNormalized.X) > Math.Abs(vectorToPlayerNormalized.Y) * 2f) {
								npc.ai[2] = 3f;
							}
							else if (vectorToPlayerNormalized.Y > 0f) {
								npc.ai[2] = 2f;
							}
							else {
								npc.ai[2] = 4f;
							}
							if (npc.ai[2] != oldAI2) {
								npc.netUpdate = true;
							}
						}
					}
				}

			}
			else {
				// This code is called when Bottom is dead. Top is transformed into a new NPC.
				npc.Transform(ModContent.NPCType<AntlionAssassin>());
				return;
			}
		}
		public override void NPCLoot()
		{
			if (Main.rand.NextBool(25)) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 857);
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int k = 0; k < 11; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, 85, hitDirection, -1f, 1, default(Color), .61f);
			}
			if (npc.life <= 0) {
				{
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionRider/Rider1"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionRider/Rider2"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionRider/Rider3"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionRider/Rider4"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionRider/Rider5"), 1f);
				}
				if (Main.LocalPlayer.GetSpiritPlayer().emptyAntlionScroll) {
					MyWorld.numAntlionsKilled++;
				}
			}
		}
	}
}
