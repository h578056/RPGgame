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
        }
        public override void IncreaseLevel()
        {
            this.Level = this.Level + 1;
            this.BaseAttributes = new PrimaryAttributes(BaseAttributes.Vitality + 5, BaseAttributes.Strength + 3, BaseAttributes.Dexterity + 2, BaseAttributes.Intelligence + 1);
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
