﻿using Microsoft.Xna.Framework;
using SpiritMod.Buffs;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
	public class EarthSpirit : ModProjectile
	{
		public override string Texture => SpiritMod.EMPTY_TEXTURE;

		// public override void SetStaticDefaults() => DisplayName.SetDefault("Earth Spirit");

		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.friendly = true;
			Projectile.timeLeft = 120;
			Projectile.penetrate = 5;
			Projectile.alpha = 255;
		}

		public override bool PreAI()
		{
			Projectile.rotation = Projectile.velocity.ToRotation() + 1.57f;
			Lighting.AddLight((int)(Projectile.Center.X / 16f), (int)(Projectile.Center.Y / 16f), 0.5f, 0.5f, 0.9f);

			for (int i = 0; i < 10; i++) {
				float x = Projectile.Center.X - Projectile.velocity.X / 10f * (float)i;
				float y = Projectile.Center.Y - Projectile.velocity.Y / 10f * (float)i;
				int num = Dust.NewDust(new Vector2(x, y), 1, 1, DustID.BlueCrystalShard, 0f, 0f, 0, default, 1f);
				Main.dust[num].alpha = Projectile.alpha;
				Main.dust[num].position.X = x;
				Main.dust[num].position.Y = y;
				Main.dust[num].velocity *= 0f;
				Main.dust[num].noGravity = true;
			}

			Projectile.velocity.Y += 0.4F;
			Projectile.velocity.X *= 1.005F;
			Projectile.velocity.X = MathHelper.Clamp(Projectile.velocity.X, -10, 10);
			return false;
		}

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			ProjectileExtras.Explode(Projectile.whoAmI, 120, 120,
				delegate {
					for (int i = 0; i < 40; i++) {
						int num = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, -2f, 0, default, 2f);
						Main.dust[num].noGravity = true;
						Dust dust = Main.dust[num];
						dust.position.X = dust.position.X + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
						Dust expr_92_cp_0 = Main.dust[num];
						expr_92_cp_0.position.Y = expr_92_cp_0.position.Y + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
						if (Main.dust[num].position != Projectile.Center) {
							Main.dust[num].velocity = Projectile.DirectionTo(Main.dust[num].position) * 6f;
						}
					}
				});
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.NextBool(2))
				target.AddBuff(ModContent.BuffType<SoulBurn>(), 120, true);
		}

		public override bool OnTileCollide(Vector2 oldVelocity) => false;
	}
}
