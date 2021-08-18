
using RPGgame.Items;
using RPGgame.Weapons;
using System;

namespace RPGgame
{
    class Program
    {
        private static PrimaryAttributes baseAttributes = new PrimaryAttributes(1, 1, 1, 1);
        static void Main(string[] args)
        {
            
            Mage mage = new Mage("mage1");
            // Console.WriteLine("level beforhand: " + mage.Level + "--" + mage.BaseAttributes.ToString() + " secAttr: "+ mage.SecondaryAttributes);

            //TotalAttributes affterEquip
            Console.WriteLine("Totalattributes: " + mage.TotalAttributes.ToString());
            Console.WriteLine("Hero DPS: " + mage.DPS);
            //create weapon the equip
            Weapon weapon = new Weapon(1, 1.1, Weapon.WeaponType.Staff, "COOL-STAFF", 2, Item.SlotE.Weapon);
            try
            {
                mage.EquipWeapon(weapon);
            }
            catch(InvalidWeaponException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine("Weapon name: " + mage.Equipment[Item.SlotE.Weapon].Name );
            Console.WriteLine("Totalattributes: " + mage.TotalAttributes.ToString());
            Console.WriteLine("Hero DPS: " + mage.DPS);

            //new weapon new equip after levelup
            // Weapon weapon2 = new Weapon(1, 1.1, Weapon.WeaponType.Staff, "COOL-STAFF2", 2, Item.SlotE.Weapon);
            mage.IncreaseLevel(2);//optionalint: 2);
            //mage.EquipWeapon(weapon2);
            //Console.WriteLine("Weapon name: " + mage.Equipment[Item.SlotE.Weapon].Name);

            //new head armor and and equip
            Armor armorHead = new Armor(baseAttributes, Armor.ArmorType.Cloth, "COOL-HAT", 1, Item.SlotE.Head);
            mage.EquipArmor(armorHead);
            Console.WriteLine("Head armor name: " + mage.Equipment[Item.SlotE.Head].Name + " Armor stats: " + mage.Equipment[Item.SlotE.Head]);
            Console.WriteLine("level after: " + mage.Level + "--" + mage.BaseAttributes.ToString() + " secAttr: " + mage.SecondaryAttributes);

            //TotalAttributes affterEquip
            Console.WriteLine("Totalattributes: "+ mage.TotalAttributes.ToString());
            Console.WriteLine("Hero DPS: " + mage.DPS);
            //create bodyarmor and equip
            Armor armorBody = new Armor(baseAttributes, Armor.ArmorType.Cloth, "COOL-CHESTPIECE", 1, Item.SlotE.Body);
            mage.EquipArmor(armorBody);
            //Hero stats
            Console.WriteLine();
            mage.PrintHeroStats();
        }
    }
}
