using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using FMOD1.Content.Items.Weapons;

namespace FMOD1.Content.Enemies
{
    public class Slime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rock Slime");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];

        }

        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 15;
            NPC.defense = 4;
            NPC.lifeMax = 25;
            NPC.value = 500f;
            NPC.aiStyle = 1;
            NPC.HitSound = SoundID.NPCDeath1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AIType = NPCID.GreenSlime;
        }


        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.2f;
        }


        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 20)
            {
                NPC.frameCounter = 0;
            }
            NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            var slimeDropRules = Main.ItemDropsDB.GetRulesForNPCID(NPCID.GreenSlime, false);
            foreach (var slimeDropRule in slimeDropRules)
            {
                npcLoot.Add(slimeDropRule);
            }
            ItemDropRule.Common(ItemID.StoneBlock, 2, 3, 5);
            npcLoot.Add(ItemDropRule.Common(ItemID.StoneBlock, 2));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SumStaff>(), 5));
        }

    }
}
