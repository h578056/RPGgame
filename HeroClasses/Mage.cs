﻿using RPGgame.HeroClasses;
using RPGgame.Items;
using RPGgame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPGgame.Item;

namespace RPGgame
{
    public class Mage : Hero, IAllowedItems
    {
        public List<Enum> AllowedItemsForHero { get; set; }
        //List<Enum> IAllowedItems.AllowedItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Mage(string name) : base(name)
        {
            this.BaseAttributes = new PrimaryAttributes(5, 1, 1, 8);
            this.SecondaryAttributes = new SecondaryAttributes(BaseAttributes);
            AllowedItemsForHero = new List<Enum>();
            AllowedItemsForHero.Add(AllowedItems.Cloth);
            AllowedItemsForHero.Add(AllowedItems.Staff);
            AllowedItemsForHero.Add(AllowedItems.Wand);
            TotalAttributes = new PrimaryAttributes(BaseAttributes.Vitality, BaseAttributes.Strength, BaseAttributes.Dexterity, BaseAttributes.Intelligence);
        }

        public override void IncreaseLevel(int optionalint = 1)
        {
            if (optionalint > 0 )
            {
                this.Level = this.Level + optionalint;
                this.BaseAttributes = new PrimaryAttributes(BaseAttributes.Vitality + 3*optionalint, BaseAttributes.Strength + 1 * optionalint, BaseAttributes.Dexterity + 1 * optionalint, BaseAttributes.Intelligence + 5 * optionalint);
                this.IncreaseSecAttr(BaseAttributes);
                CalculateTotalAttributes(BaseAttributes, Equipment);
                CalculateHeroDPS((Weapon)Equipment[SlotE.Weapon], TotalAttributes);
            }
            else
            {
                throw new ArgumentException();
            }
        }  

        public override string EquipWeapon(Weapon weapon)
        {
            return EquipWeapon2(weapon, AllowedItemsForHero);
        }

        public override string EquipArmor(Armor armor)
        {
            return EquipArmor2(armor, AllowedItemsForHero);
        }

        public override void CalculateHeroDPS(Weapon weapon, PrimaryAttributes totalAttrbutes)
        {
            if (totalAttrbutes != null)
            {
                CalculateHeroDPSForHero(weapon, totalAttrbutes.Intelligence);
            }
        }
    }
}
