using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Accessories;

namespace Laugicality.Items.Loot
{
    public class DuneSharkronTreasureBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.width = 44;
            item.height = 34;
            item.maxStack = 20;
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item9;
            item.consumable = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }


        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(mod.ItemType("DarkShard"), Main.rand.Next(1,4));
            player.QuickSpawnItem(mod.ItemType("Pyramind"), 1);
            int ran = Main.rand.Next(1, 5);
            if (ran == 1) player.QuickSpawnItem(934, 1);
            if (ran == 2) player.QuickSpawnItem(857, 1);
            if (ran == 3) player.QuickSpawnItem(848, 1);
            if (ran == 4) player.QuickSpawnItem(866, 1);

            player.QuickSpawnItem(188, Main.rand.Next(10, 15));
        }
        
    }
}