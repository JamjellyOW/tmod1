using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FMOD1.Content.Items.Weapons
{
    public class Cutless : ModItem
    {
        public override void SetStaticDefaults()
        {
             DisplayName.SetDefault("Cutless"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("The Cutlass that cuts less!");
        }

        public override void SetDefaults()
        {   
            //Hitbox test comment
            Item.width = 26;
            Item.height = 32;
            
            //Use and Animation Style
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            
            // Damage Values
            Item.DamageType = DamageClass.Melee;
            Item.damage = 21;
            Item.knockBack = 3;
            Item.crit = 2;
            
            //Misc
            Item.value = Item.buyPrice(silver: 80, copper: 50);
            Item.rare = ItemRarityID.Blue;
            
            //Sound
            Item.UseSound = SoundID.Item1;
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