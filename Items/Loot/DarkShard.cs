using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class DarkShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Shard");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 26;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 0;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(77);
            recipe.AddIngredient(null, "ObsidiumOre", 3);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
        
    }
}