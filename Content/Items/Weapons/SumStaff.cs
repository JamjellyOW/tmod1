using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using FMOD1.Content.Projectiles.Minions;
using FMOD1.Content.Buffs;

namespace FMOD1.Content.Items.Weapons
{
    public class SumStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
             DisplayName.SetDefault("Bag of Rocks"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Rock? Slime? I have no idea.");
        }

        public override void SetDefaults()
        {   
            //Hitbox
            Item.width = 28;
            Item.height = 32;
            
            //Use and Animation Style
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = false;
            
            // Damage Values
            Item.DamageType = DamageClass.Summon;
            Item.damage = 25;
            Item.knockBack = 3f;
            
            //Misc
            Item.value = Item.buyPrice(silver: 80, copper: 50);
            Item.rare = ItemRarityID.Blue;
            Item.mana = 10;
            Item.noMelee = true;

            Item.buffType = ModContent.BuffType<SumBuff>();
            Item.shoot = ModContent.ProjectileType<SumPro>();
            
            //Sound
            Item.UseSound = SoundID.Item44;

        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position
            position = Main.MouseWorld;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
            player.AddBuff(Item.buffType, 2);

            //position = Main.MouseWorld;

            // Minions have to be spawned manually, then have originalDamage assigned to the damage of the summon item
            var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
            projectile.originalDamage = Item.damage;

            // Since we spawned the projectile manually already, we do not need the game to spawn it for ourselves anymore, so return false
            return false;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}