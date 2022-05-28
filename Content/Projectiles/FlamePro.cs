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
            //Damage
            Projectile.DamageType = DamageClass.Magic;
            //Size
            Projectile.width = 10;
            Projectile.height = 10;
            //Misc
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.light = 1.5f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;

            //Ai style
            Projectile.aiStyle = ProjectileID.CursedFlameFriendly;
            
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Left, 1, 1, DustID.Lava, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].velocity *= 0.2f;
            Main.dust[dust].scale = (float)Main.rand.Next(80,115) * .013f;
            Main.dust[dust].noGravity = true;
        }
    }
}