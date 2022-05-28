using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FMOD1.Content.Items.Weapons
{
    public class Hellshot : ModItem
    {
        public override void SetStaticDefaults()
        {
             DisplayName.SetDefault("Hellshot"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Lava served hot and fresh.");
        }

        public override void SetDefaults()
        {   
            //Hitbox
            Item.width = 26;
            Item.height = 32;
            
            //Use and Animation Style
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            
            // Damage Values
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 25;
            Item.knockBack = 3;
            Item.crit = 2;
            
            //Misc
            Item.value = Item.buyPrice(silver: 80, copper: 50);
            Item.rare = ItemRarityID.Blue;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 12f;
            
            //Sound
            Item.UseSound = SoundID.Item5;
        }

        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(4,0);
            return offset;
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