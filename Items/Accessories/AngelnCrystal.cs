using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class AngelnCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Improved fishing skills");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 3;
            item.accessory = true;
            //item.defense = 1000;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.cratePotion = true;
            player.sonarPotion = true;
            player.fishingSkill += 15;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SonarGem", 1);
            recipe.AddIngredient(null, "FishingGem", 1);
            recipe.AddIngredient(null, "CrateGem", 1);
            recipe.AddTile(null, "CrystalineInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}