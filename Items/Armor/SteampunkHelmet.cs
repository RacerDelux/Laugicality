using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SteampunkHelmet : ModItem
	{
public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Melee attacks inflict 'Electrified' \n +1 Minion capacity");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 5;
			item.defense = 12;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("SteampunkJacket") && legs.type == mod.ItemType("SteampunkBoots");
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.meFied = true;
            player.maxMinions++;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased Minion capacity, +10% Minion damage";
            player.maxMinions += 2;
            player.minionDamage += 0.10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamBar", 12);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}