
using RPGgame.Items;
using RPGgame.Weapons;
using System;

namespace RPGgame
{
    class Program
    {
        private static PrimaryAttributes baseAttributes = new PrimaryAttributes(1, 1, 8, 5);
        static void Main(string[] args)
        {
            
            Mage mage = new Mage("mage1");
           // Console.WriteLine("level beforhand: " + mage.Level + "--" + mage.BaseAttributes.ToString() + " secAttr: "+ mage.SecondaryAttributes);

            //create weapon the equip
            Weapon weapon = new Weapon(1, 1.1, Weapon.WeaponType.Staff, "COOL-STAFF", 1, Item.SlotE.Weapon);
            mage.EquipWeapon(weapon);
            Console.WriteLine("Weapon name: " + mage.Equipment[Item.SlotE.Weapon].Name );

            //new weapon new equip after levelup
            Weapon weapon2 = new Weapon(1, 1.1, Weapon.WeaponType.Staff, "COOL-STAFF2", 2, Item.SlotE.Weapon);
            mage.IncreaseLevel();
            mage.EquipWeapon(weapon2);
            Console.WriteLine("Weapon name: " + mage.Equipment[Item.SlotE.Weapon].Name);

            //new head armor and and equip
            Armor armorHead = new Armor(baseAttributes, Armor.ArmorType.Cloth, "COOL-HAT", 2, Item.SlotE.Head);
            mage.EquipArmor(armorHead);
            Console.WriteLine("Head armor name: " + mage.Equipment[Item.SlotE.Head].Name);
            Console.WriteLine("level after: " + mage.Level + "--" + mage.BaseAttributes.ToString() + " secAttr: " + mage.SecondaryAttributes);
        }
    }
}
