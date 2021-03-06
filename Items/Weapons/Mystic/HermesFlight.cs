using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using Laugicality;

namespace Laugicality.Items.Weapons.Mystic
{
	public class HermesFlight : ModItem
	{
        public string tt = "";
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hermes' Flight");
            Tooltip.SetDefault("Weild the power of Hermes \nRight click while holding to change Mysticism");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 8;
            //item.magic = true;
            item.mana = 4;
            item.width = 28;
			item.height = 28;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("HermesDestruction");
			item.shootSpeed = 6f;
		}

        
        
        /*
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            damage = (int) modPlayer.mysticDamage;
            knockBack = modPlayer.mysticDuration;
            return true;
        }


        //Mystic Stuff
        public override bool AltFunctionUse(Player player)
        {

            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticMode += 1;
            if (modPlayer.mysticMode > 3) modPlayer.mysticMode = 1;
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            return true;
            if (player.altFunctionUse == 2)
            {
                
            }
        }*/

        public virtual void GetWeaponDamage(Player player, ref int damage)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            item.damage = (int)(item.damage * modPlayer.mysticDamage);
        }

        public override void HoldItem(Player player)
        {
            
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            //Main.NewText(modPlayer.mysticMode.ToString(), 200, 200, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color

            if (modPlayer.mysticMode  == 1)
            {
                player.AddBuff(mod.BuffType("Destruction"), 1, true);
                item.damage = 8;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.destructionDamage);
                item.mana = 4;
                item.useTime = 12;
                item.useAnimation = 12;
                item.knockBack = 1;
                item.shootSpeed = 14f;
                item.shoot = mod.ProjectileType("HermesDestruction");
            }
            else if(modPlayer.mysticMode == 2)
            {
                player.AddBuff(mod.BuffType("Illusion"), 1, true);
                item.damage = 10;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.illusionDamage);
                item.mana = 4;
                item.useTime = 18;
                item.useAnimation = 18;
                item.knockBack = 18;
                item.shootSpeed = 8f;
                item.shoot = mod.ProjectileType("HermesIllusion");
            }
            else if (modPlayer.mysticMode == 3)
            {
                player.AddBuff(mod.BuffType("Conjuration"), 1, true);
                item.damage = 8;
                item.damage = (int)(item.damage * modPlayer.mysticDamage * modPlayer.conjurationDamage);
                item.mana = 6;
                item.useTime = 18;
                item.useAnimation = 18;
                item.knockBack = 5;
                item.shootSpeed = 8f;
                item.shoot = mod.ProjectileType("HermesConjuration");
            }
        }


        /*
        public override bool CanRightClick()
        {
                return true;
        }
        
        public override void RightClick(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticMode += 1;
            if (modPlayer.mysticMode > 3) modPlayer.mysticMode = 1;
        }*/
        
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 12);
            recipe.anyWood = true;
            recipe.AddIngredient(ItemID.Feather, 4);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}