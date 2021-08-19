﻿
using RPGgame.Items;
using RPGgame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPGgame.Item;

namespace RPGgame.HeroClasses
{
    public class Ranger : Hero, IAllowedItems
    {
        public List<Enum> AllowedItemsForHero { get; set; }
        public Ranger(string name) : base(name)
        {
            this.BaseAttributes = new PrimaryAttributes(8, 1, 7, 1);
            this.SecondaryAttributes = new SecondaryAttributes(BaseAttributes);
            AllowedItemsForHero = new List<Enum>();
            AllowedItemsForHero.Add(AllowedItems.Leather);
            AllowedItemsForHero.Add(AllowedItems.Mail);
            AllowedItemsForHero.Add(AllowedItems.Bow);
            TotalAttributes = new PrimaryAttributes(BaseAttributes.Vitality, BaseAttributes.Strength, BaseAttributes.Dexterity, BaseAttributes.Intelligence);
        }

        public override void IncreaseLevel(int optionalint = 1)
        {
            if (optionalint > 0)
            {
                this.Level = this.Level + 1;
                this.BaseAttributes = new PrimaryAttributes(BaseAttributes.Vitality + 2 * optionalint, BaseAttributes.Strength + 1 * optionalint, BaseAttributes.Dexterity + 5 * optionalint, BaseAttributes.Intelligence + 1 * optionalint);
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
                CalculateHeroDPSForHero(weapon, totalAttrbutes.Dexterity);
            }
        }
    }
}
