
using RPGgame.Items;
using RPGgame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.HeroClasses
{
    public class Ranger : Hero, IAllowedItems
    {
        public List<Enum> AllowedItemsForHero { get; set; }
        public Ranger(string name) : base(name)
        {
            this.BaseAttributes = new PrimaryAttributes(8, 1, 7, 1);
            AllowedItemsForHero = new List<Enum>();
            AllowedItemsForHero.Add(AllowedItems.Leather);
            AllowedItemsForHero.Add(AllowedItems.Mail);
            AllowedItemsForHero.Add(AllowedItems.Bow);
        }

        public override void IncreaseLevel()
        {
            this.Level = this.Level + 1;
            this.BaseAttributes = new PrimaryAttributes(BaseAttributes.Vitality + 2, BaseAttributes.Strength + 1, BaseAttributes.Dexterity + 5, BaseAttributes.Intelligence + 1);
            this.IncreaseSecAttr(BaseAttributes);
        }
        public override void EquipWeapon(Weapon weapon) //remeamber to make custom throw
        {
            EquipWeapon2(weapon, AllowedItemsForHero);
        }

        public override void EquipArmor(Armor armor)
        {
            EquipArmor2(armor, AllowedItemsForHero);
        }
    }
}
