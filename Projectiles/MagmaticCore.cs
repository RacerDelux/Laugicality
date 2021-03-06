﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
    public class MagmaticCore : ModProjectile
    {
    	public float dust = 0f;
    	
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.aiStyle = 66;
            projectile.minionSlots = 1f;
            projectile.timeLeft = 18000;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            aiType = 388;
        }

        public override void AI()
        {

            if(Main.rand.Next(4) == 0)Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Magma"), 0, Math.Abs(projectile.velocity.Y) * -0.1f);

            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (player.dead)
            {
                modPlayer.mCore = false;
            }
            if (modPlayer.mCore)
            {
                projectile.timeLeft = 2;
            }
        }

        /*
        public override void AI()
        {
        	if (dust == 0f)
        	{
        		int num226 = 36;
				for (int num227 = 0; num227 < num226; num227++)
				{
					Vector2 vector6 = Vector2.Normalize(projectile.velocity) * new Vector2((float)projectile.width / 2f, (float)projectile.height) * 0.75f;
					vector6 = vector6.RotatedBy((double)((float)(num227 - (num226 / 2 - 1)) * 6.28318548f / (float)num226), default(Vector2)) + projectile.Center;
					Vector2 vector7 = vector6 - projectile.Center;
					int num228 = Dust.NewDust(vector6 + vector7, 0, 0, 33, vector7.X * 1.1f, vector7.Y * 1.1f, 100, default(Color), 1.4f);
					Main.dust[num228].noGravity = true;
					Main.dust[num228].noLight = true;
					Main.dust[num228].velocity = vector7;
				}
				dust += 1f;
        	}
        	projectile.rotation += projectile.velocity.X * 0.04f;
        	bool flag64 = projectile.type == mod.ProjectileType("BrittleStar");
			Player player = Main.player[projectile.owner];
			CalamityPlayer modPlayer = player.GetModPlayer<CalamityPlayer>(mod);
			player.AddBuff(mod.BuffType("BrittleStar"), 3600);
			if (flag64)
			{
				if (player.dead)
				{
					modPlayer.bStar = false;
				}
				if (modPlayer.bStar)
				{
					projectile.timeLeft = 2;
				}
			}
		}*/

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.ai[0] += 0.1f;
            projectile.velocity *= 0.75f;
            target.AddBuff(BuffID.OnFire, 80);      //Add Onfire buff to the NPC for 1 second
        }
    }
}