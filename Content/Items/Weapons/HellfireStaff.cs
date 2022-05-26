using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FMOD1.Content.Items.Weapons
{
    public class HellfireStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
             DisplayName.SetDefault("Hellfire Staff"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Inflicts those unsuspecting with fire!");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {   
            //Hitbox
            Item.width = 86;
            Item.height = 72;
            
            //Use and Animation Style
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            
            // Damage Values
            Item.DamageType = DamageClass.Magic;
            Item.damage = 25;
            Item.knockBack = 3;
            Item.crit = 4;
            
            //Misc
            Item.value = Item.buyPrice(silver: 80, copper: 50);
            Item.rare = ItemRarityID.Blue;
            Item.mana = 10;
            Item.shoot = ProjectileID.CursedFlameFriendly;
            Item.shootSpeed = 10f;
            Item.noMelee = true;
            
            //Sound
            Item.UseSound = SoundID.Item43;

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
        Vector2 offset = new Vector2(velocity.X * 7, velocity.Y * 7);
        position += offset;
        return true;
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