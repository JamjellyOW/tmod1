using System; //what sources the code uses, these sources allow for calling of terraria functions, existing system functions and microsoft vector functions (probably more)
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FMOD1.Content.Projectiles //where it's stored, replace Mod with the name of your mod. This file is stored in the folder \Mod Sources\(mod name, folder can't have spaces)\Projectiles.
{
    public class FlamePro : ModProjectile 
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.CursedFlameFriendly);
            AIType = ProjectileID.CursedFlameFriendly;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 240); //Gives cursed flames to target for 4 seconds. (60 = 1 second, 240 = 4 seconds)
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.position, 1, 1, DustID.Lava, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].velocity *= 0.2f;
            Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * .013f;
            Main.dust[dust].noGravity = true;

        }
    }
}