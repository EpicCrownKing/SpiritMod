using SpiritMod.Items.Armor;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpiritMod.NPCs
{
    public class LostMime : ModNPC
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Lost Mime");
            Main.npcFrameCount[npc.type] = 17;
        }

        public override void SetDefaults() {
            npc.width = 24;
            npc.height = 42;
            npc.damage = 30;
            npc.defense = 10;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit48;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 2060f;
            npc.knockBackResist = .25f;
            npc.aiStyle = 3;
            aiType = NPCID.AngryBones;
        }

        /* public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.playerSafe)
			{
				return 0f;
			}
			return SpawnCondition.Cavern.Chance * 0.007f;
		}*/

        public override void FindFrame(int frameHeight) {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }

        public override void AI() {
            npc.spriteDirection = npc.direction;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.Confused, 60);
        }
        public override void HitEffect(int hitDirection, double damage) {
            if(npc.life <= 0 && Main.rand.Next(2) == 0) {
                Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 6);
                npc.Transform(ModContent.NPCType<CaptiveMask>());
            }
            int d = 6;
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, d, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.27f);
                Dust.NewDust(npc.position, npc.width, npc.height, d, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.87f);
            }
            if (npc.life <= 0) {
                Gore.NewGore(npc.position, npc.velocity, 9);
                Gore.NewGore(npc.position, npc.velocity, 9);
                Gore.NewGore(npc.position, npc.velocity, 9);
            }
        }

        public override void NPCLoot() {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<MimeMask>(), 1);
        }

    }
}
