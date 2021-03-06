using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Slybertron
{
	public class GasBallUp : ModProjectile
	{
        public int delay = 0;
        public int damage = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gas Ball");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			//projectile.alpha = 255;
            projectile.timeLeft = 180;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            damage = 50;
        }

        public override void AI()
        {
            delay += 1;
            if(delay == 30)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 8, mod.ProjectileType("GasBallDown"), damage, 3f, Main.myPlayer);
                delay = 0;
            }
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Steam"), 0f, 0f);
        }

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            //NPCs.Slybertron.Slybertron.electroShockHits += 1;
            int debuff = mod.BuffType("Electrified");
            if (debuff >= 0)
            {
                player.AddBuff(debuff, 90, true);
            }      //Add Onfire buff to the NPC for 1 second
        }
    }
}