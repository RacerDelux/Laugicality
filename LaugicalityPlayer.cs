using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Laugicality.Items.Accessories;

namespace Laugicality
{
    public class LaugicalityPlayer : ModPlayer
    {
        public const int maxBuffs = 42;
        public bool obsidium = false;
        //Summons
        public bool mCore = false;
        public bool tV = false;
        public bool sShark = false;


        public bool skp = false;
        public bool douche = false;
        public int mysticCrit = 4;
        public bool eFied = false; //Electrified Debuff
        public bool meFied = false;
        public bool mFied = false; //Mystified Debuff
        public bool toyTrain = false; //Toy Train Pet
        public bool bRage = false;
        public bool qB = false;

        //Soul Stone class
        public int Class = 0;


        //Mystic vars
        public float mysticDamage = 1f;
        public float mysticDuration = 1f;
        public int mysticMode = 1; //1 = Destruction, 2 = Illusion, 3 = Conjuration

        public float illusionDamage = 1f;
        public float destructionDamage = 1f;
        public float conjurationDamage = 1f;
        public float illusionPower = 1f;
        public float destructionPower = 1f;
        public float conjurationPower = 1f;


        public bool ZoneObsidium = false;

        public override void ResetEffects()
        {
            obsidium = false;
            mCore = false;
            sShark = false;
            skp = false;
            douche = false;
            tV = false;
            eFied = false;
            meFied = false;
            mFied = false;
            toyTrain = false;
            bRage = false;
            qB = false;

            //Mystic
            mysticCrit = 4;
            mysticDamage = 1f;
            mysticDuration = 1f;

            illusionDamage = 1f;
            destructionDamage = 1f;
            conjurationDamage = 1f;
            illusionPower = 1f;
            destructionPower = 1f;
            conjurationPower = 1f;
        }

        public override TagCompound Save()
        {
            return new TagCompound {
                {"Class", Class }
            };
        }


        public override void Load(TagCompound tag)
        {
            Class = tag.GetInt("Class");
        }


        public override void UpdateBiomes()
        {
            ZoneObsidium = (LaugicalityWorld.obsidiumTiles > 250);
        }


        public override bool CustomBiomesMatch(Player other)
        {
            LaugicalityPlayer modOther = other.GetModPlayer<LaugicalityPlayer>(mod);
            return ZoneObsidium == modOther.ZoneObsidium;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            LaugicalityPlayer modOther = other.GetModPlayer<LaugicalityPlayer>(mod);
            modOther.ZoneObsidium = ZoneObsidium;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = ZoneObsidium;
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            ZoneObsidium = flags[0];
        }

        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneObsidium)
            {
                return mod.GetTexture("ObsidiumBiomeMapBackground");
            }
            return null;
        }
        /*
        public override int GetWeaponDamage(Item sItem)
        {
            bool flag23 = false;
            bool critTry = false;
            int mCrit = this.inventory[this.selectedItem].crit; +this.mysticCrit;
            Random mCritChance = new Random();
            int mCritTry = mCritChance.Next(1,100);
            if (mCritTry < mCrit) {
                critTry = true;
                bool flag23 = true;
            }
            
            int num = sItem.damage;
            if (critTry == true) num *= 2;
            if (num > 0)
            {
                if (sItem.mystic)
                {
                    num = (int)((float)num * this.mysticDamage + 5E-06f);
                }
            }
            return num;
        }*/

        public override void UpdateDead()
        {
            eFied = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (eFied)//Electrified
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 16;
            }
            if (mFied)//Mystified
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 4;
            }
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            int rand = Main.rand.Next(4);
            if (obsidium)
            {
                target.AddBuff(24, (int)((120 + 60 * rand)*mysticDuration), false);
            }
            if (skp)
            {
                target.AddBuff(39, (int)((120 + 60 * rand) * mysticDuration), false);
            }
            if (douche)
            {
                target.AddBuff(70, (int)((120 + 60 * rand) * mysticDuration), false);
            }
            if (qB)
            {
                target.AddBuff(20, (int)((120 + 60 * rand) * mysticDuration), false);
            }
            if (meFied)
            {
                target.AddBuff(mod.BuffType("Electrified"), (int)((120 + 60 * rand) * mysticDuration), false);
            }
        }


        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (eFied)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, mod.DustType("Lightning"), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.1f;
                g *= 0.8f;
                b *= 0.8f;
                fullBright = true;
            }
        }

        //Hotkey
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Laugicality.ToggleMystic.JustPressed)
            {
                mysticMode += 1;
                if (mysticMode > 3) mysticMode = 1;
            }
        }

        public virtual void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (bRage)
            {
                player.AddBuff(mod.BuffType("BloodRage"), 420);
            }
        }

    }
}
       
