using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class DarkJewelry : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases life and mana regeneration \n+40 Mana");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            //item.defense = 1000;
            item.lifeRegen = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaRegenBonus += 10;
            player.statManaMax2 += 40;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BandOfDarkness", 1);
            recipe.AddIngredient(null, "DarkNecklace", 1);
            recipe.AddTile(114);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}