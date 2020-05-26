using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace SpiritMod.NPCs
{
	public class SamuraiPassive : ModNPC
	{
		public static int _type;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Phantom Samurai");
			Main.npcFrameCount[npc.type] = 9;
			NPCID.Sets.TownCritter[npc.type] = true;
            NPCID.Sets.TrailCacheLength[npc.type] = 3;
            NPCID.Sets.TrailingMode[npc.type] = 0;
        }

		public override void SetDefaults()
		{
			npc.friendly = false;
            npc.townNPC = true;
            npc.width = 76;
            npc.height = 76;
            npc.aiStyle = 0;
            npc.damage = 12;
            npc.defense = 9999;
            npc.lifeMax = 50;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0f;
		}
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= 4;
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void AI()
		{
        	Player target = Main.player[npc.target];

            if (npc.localAI[0] == 0f)
            {
                npc.localAI[0] = npc.Center.Y;
                npc.netUpdate = true; //localAI probably isnt affected by this... buuuut might as well play it safe
            }
            if (npc.Center.Y >= npc.localAI[0])
            {
                npc.localAI[1] = -1f;
                npc.netUpdate = true;
            }
            if (npc.Center.Y <= npc.localAI[0] - 2f)
            {
                npc.localAI[1] = 1f;
                npc.netUpdate = true;
            }
            npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y + 0.009f * npc.localAI[1], -.5f, .5f);
            int distance = (int)Math.Sqrt((npc.Center.X - target.Center.X) * (npc.Center.X - target.Center.X) + (npc.Center.Y - target.Center.Y) * (npc.Center.Y - target.Center.Y));
			if (distance <= 540 || npc.life < npc.lifeMax)
			{
			      npc.Transform(mod.NPCType("SamuraiHostile"));
            }
            if (Main.netMode != 1)
            {
                npc.homeless = false;
                npc.homeTileX = -1;
                npc.homeTileY = -1;
                npc.netUpdate = true;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.npcTexture[npc.type].Width * 0.5f, (npc.height * 0.5f));
            for (int k = 0; k < npc.oldPos.Length; k++)
            {
                var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                Vector2 drawPos = npc.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, npc.gfxOffY);
                Color color = npc.GetAlpha(lightColor) * (float)(((float)(npc.oldPos.Length - k) / (float)npc.oldPos.Length) / 2);
                spriteBatch.Draw(Main.npcTexture[npc.type], drawPos, new Microsoft.Xna.Framework.Rectangle?(npc.frame), color, npc.rotation, drawOrigin, npc.scale, effects, 0f);
            }
            return true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 100);
        }
    }
}
