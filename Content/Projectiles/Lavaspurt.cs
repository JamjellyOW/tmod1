using System; //what sources the code uses, these sources allow for calling of terraria functions, existing system functions and microsoft vector functions (probably more)
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FMOD1.Content.Projectiles //where it's stored, replace Mod with the name of your mod. This file is stored in the folder \Mod Sources\(mod name, folder can't have spaces)\Projectiles.
{
    public class Lavaspurt : ModProjectile 
    {
        public override void SetDefaults()
        {
            //type
            Projectile.DamageType = DamageClass.Ranged;
            
            //dimensions
            Projectile.width = 20;
            Projectile.height = 9;
            
            //Misc
            Projectile.ignoreWater = false;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.light = 1f;
            Projectile.tileCollide = true;
            Projectile.penetrate = 3;
            Projectile.extraUpdates = 1;
            //AIType = ProjectileID.WoodenArrowFriendly;
            

            
        }

        //makes target burn
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 240); //Gives cursed flames to target for 4 seconds. (60 = 1 second, 240 = 4 seconds)
        }

        public override void AI()
        {
            if (Projectile.wet)
            {
                Projectile.Kill();
            }


            int dust = Dust.NewDust(Projectile.position, 1, 1, DustID.Lava, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].velocity *= 0.2f;
            Main.dust[dust].scale = .50f;
            Main.dust[dust].noGravity = true;

        }
    }
}