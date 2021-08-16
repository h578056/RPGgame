using RPGgame.HeroClasses;
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
        }

        public override void IncreaseLevel()
        {
            this.Level = this.Level + 1;
            this.BaseAttributes = new PrimaryAttributes(BaseAttributes.Vitality +3, BaseAttributes.Strength + 1, BaseAttributes.Dexterity + 1, BaseAttributes.Intelligence + 5) ;
            this.IncreaseSecAttr(BaseAttributes);
        }

        public override void EquipWeapon(Weapon weapon)
        {
            EquipWeapon2(weapon, AllowedItemsForHero);
        }

        public override void EquipArmor(Armor armor)
        {
            EquipArmor2(armor, AllowedItemsForHero);
        }
    }
}
