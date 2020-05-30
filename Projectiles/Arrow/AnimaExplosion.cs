using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Arrow
{
	public class AnimaExplosion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Anima");
		}

		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.alpha = 255;
			projectile.timeLeft = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
		}
		public override void AI()
		{
                ProjectileExtras.Explode(projectile.whoAmI, 60, 60,
                delegate
                {
                    for (int i = 0; i < 60; i++)
                    {
                        int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("NightmareDust"), 0f, -2f, 0, default(Color), 1.1f);
                        Main.dust[num].noGravity = true;
						Main.dust[num].scale = 1.5f;
                        Dust expr_62_cp_0 = Main.dust[num];
                        expr_62_cp_0.position.X = expr_62_cp_0.position.X + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f);
                        Dust expr_92_cp_0 = Main.dust[num];
                        expr_92_cp_0.position.Y = expr_92_cp_0.position.Y + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f);
                        if (Main.dust[num].position != projectile.Center)
                        {
                            Main.dust[num].velocity = projectile.DirectionTo(Main.dust[num].position) * 3f;
                        }
                    }
                });
				projectile.active = false;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            if (target.type != 488)
            {
                target.AddBuff(mod.BuffType("DrainLife"), 150, true);
            }
		}

	}
}