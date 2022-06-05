using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using FMOD1.Content.Projectiles.Minions;

namespace FMOD1.Content.Buffs
{
    public class SumBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rock");
            Description.SetDefault("Is it a rock or a slime?");

            //Buff won't save when exit world
            Main.buffNoSave[Type] = true;
            //Time remaining won't display
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //If the minion exist reset the buff time, otherwise remove the buff from the player
            if (player.ownedProjectileCounts[ModContent.ProjectileType<SumPro>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else 
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
