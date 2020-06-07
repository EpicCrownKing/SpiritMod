using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Artifact
{
    public class DeathWreathe2 : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Soul Wreathe");
            Main.buffNoTimeDisplay[Type] = false;
			Main.pvpBuff[Type] = false;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			if (!npc.boss && !npc.friendly)
			{
				npc.lifeRegen -= 6;
				npc.defense = npc.defDefense / 100 * 5;

				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 110);
				Main.dust[dust].scale *= 2f;
				Main.dust[dust].velocity *= 0f;
				Main.dust[dust].noGravity = true;

                if (Main.rand.NextBool(100))
                {
                    Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<SoulBurst>(), 50, 0, Main.myPlayer);
                }
			}
		}
	}
}