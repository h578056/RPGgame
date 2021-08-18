using RPGgame.Items;
using RPGgame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.HeroClasses
{
    public class Warrior : Hero, IAllowedItems
    {
        public List<Enum> AllowedItemsForHero { get; set; }
        public Warrior(string name) : base(name)
        {
            this.BaseAttributes = new PrimaryAttributes(10, 5, 2, 1);
            AllowedItemsForHero = new List<Enum>();
            AllowedItemsForHero.Add(AllowedItems.Mail);
            AllowedItemsForHero.Add(AllowedItems.Plate);
            AllowedItemsForHero.Add(AllowedItems.Axe);
            AllowedItemsForHero.Add(AllowedItems.Hammer);
            AllowedItemsForHero.Add(AllowedItems.Sword);
            TotalAttributes = new PrimaryAttributes(BaseAttributes.Vitality, BaseAttributes.Strength, BaseAttributes.Dexterity, BaseAttributes.Intelligence);
        }
        public override void IncreaseLevel(int optionalint = 1)
        {
            this.Level = this.Level + 1;
            this.BaseAttributes = new PrimaryAttributes(BaseAttributes.Vitality + 5* optionalint, BaseAttributes.Strength + 3 * optionalint, BaseAttributes.Dexterity + 2 * optionalint, BaseAttributes.Intelligence + 1 * optionalint);
            this.IncreaseSecAttr(BaseAttributes);
            CalculateTotalAttributes(BaseAttributes, Equipment);
        }
        public override void EquipWeapon(Weapon weapon) //remeamber to make custom throw
        {
            EquipWeapon2(weapon, AllowedItemsForHero);
            CalculateHeroDPS(weapon, TotalAttributes);
        }

        public override void EquipArmor(Armor armor)
        {
            EquipArmor2(armor, AllowedItemsForHero);
        }
        public override void CalculateHeroDPS(Weapon weapon, PrimaryAttributes totalAttrbutes)
        {
            if (weapon != null && weapon.DPS != 0 && totalAttrbutes != null)
            {
                double h = (double)(1) + ((double)(totalAttrbutes.Strength) / (double)(100));
                this.DPS = Math.Round(weapon.DPS * h, 3);
            }
        }
    }
}
