
using RPGgame.HeroClasses;
using RPGgame.Items;
using RPGgame.Weapons;
using System;
using System.Collections.Generic;

namespace RPGgame
{
    class Program
    {
        private static PrimaryAttributes baseAttributes = new PrimaryAttributes(1, 1, 1, 1);
        public List<Armor> itemsA = new List<Armor>();
        public List<Weapon> itemsW = new List<Weapon>();
        public Hero hero = null;
        static void Main(string[] args)
        {
            /*
            Hero mage = new Mage("mage1");
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
            */
            Program p = new Program();
            p.RunGameInTerminal();
        }
        public void RunGameInTerminal()
        {
            Console.WriteLine("Create character: ");
            Console.WriteLine("Type <mage> for mage");
            Console.WriteLine("Type <warrior> for warrior");
            Console.WriteLine("Type <rogue> for rogue");
            Console.WriteLine("Type <ranger> for ranger");
            string heroType = Console.ReadLine().ToLower();
            string name = CreateHeroName();
            selectHeroType(heroType, name);
            //hero.PrintHeroStats();
            //hero.IncreaseLevel();
            //hero.PrintHeroStats();
            //hero.IncreaseLevel();
            //hero.PrintHeroStats();
            ActionToDo();
            //equip or level
            //if equip, then armor or weapon
            //then repeat
            //EquipWeapon(hero);
        }
        public void ActionToDo()
        {
            hero.PrintHeroStats();
            Console.WriteLine("Type <L> for level up");
            Console.WriteLine("Type <W> to equip weapon");
            Console.WriteLine("Type <A> to equip armor");
            Console.WriteLine("Type <END> to equip armor");
            string action = Console.ReadLine();
            switch (action)
            {

                case "W": // statement sequence
                    try
                    {
                        EquipWeapon(hero);
                    }
                    catch
                    {

                    }
                    ActionToDo();
                    break;

                case "A": // statement sequence
                    try
                    {
                        EquipArmor(hero);
                    }
                    catch
                    {

                    }
                    ActionToDo();
                    break;

                case "L": // statement sequence
                    hero.IncreaseLevel();
                    ActionToDo();
                    break;

                case "END": // statement sequence
                    hero.PrintHeroStats();
                    return ;
                    break;

                default:    // default statement sequence
                    ActionToDo();
                    break;
            }
        }
        public void EquipArmor(Hero hero)
        {

            int lvl = hero.Level;
            Random random = new Random();
            int number = random.Next(0, itemsA.Count - 1);
            Armor a = itemsA[number];
            hero.EquipArmor(a);
        }
        public void EquipWeapon(Hero hero)
        {
            int lvl = hero.Level;
            Random random = new Random();
            int number = random.Next(0, itemsW.Count-1);
            Weapon w = itemsW[number];
            hero.EquipWeapon(w);
        }
        public string CreateHeroName()
        {
            string name = "";
            Console.WriteLine("Type Character name: ");
            string heroName = Console.ReadLine();
            if (heroName != "" || heroName != null)
            {
                name = heroName;
                return name;
            }
            else
            {
                name=CreateHeroName();
            }
            return name;
        }

        public void LevelUp(Hero h)
        {
            Console.WriteLine("Want to level up(cannot level down)?");
            Console.WriteLine("type number you whant to level up or <N> if you dont want to level up, nb whole number");
            string level= Console.ReadLine().ToLower();

            if (level.Equals("n"))
            {
                //do nothing here instead continue
            }
            else
            {
                try
                {
                    int l= int.Parse(level);
                    h.IncreaseLevel(l);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    LevelUp(h);
                }catch(ArgumentException a)
                {
                    Console.WriteLine(a.Message);
                    LevelUp(h);
                }
            }
        }
        public void selectHeroType(string heroType, string name)
        {
            switch (heroType)
            {
                case "mage": // statement sequence
                    hero = new Mage(name);
                    itemsW.Add(new Weapon(1, 1.4, Weapon.WeaponType.Staff, "COOL-STAFF", 3, Item.SlotE.Weapon));
                    itemsW.Add(new Weapon(1, 1.2, Weapon.WeaponType.Staff, "COOL-WAND", 2, Item.SlotE.Weapon));
                    itemsW.Add(new Weapon(1, 1.1, Weapon.WeaponType.Staff, "COOL-WAND2", 1, Item.SlotE.Weapon));
                    itemsW.Add(new Weapon(1, 1.2, Weapon.WeaponType.Staff, "COOL-WAND3", 1, Item.SlotE.Weapon));
                    itemsA.Add(new Armor(new PrimaryAttributes(1, 1, 1, 2), Armor.ArmorType.Cloth, "COOL-CHESTPIECE", 1, Item.SlotE.Body));
                    itemsA.Add(new Armor(new PrimaryAttributes(1, 1, 1, 1), Armor.ArmorType.Cloth, "COOL-HEAD", 2, Item.SlotE.Head));
                    itemsA.Add(new Armor(new PrimaryAttributes(2, 2, 2, 3), Armor.ArmorType.Cloth, "COOL-LEGS", 3, Item.SlotE.Legs));
                    break;

                case "warrior": // statement sequence
                    hero = new Warrior(name);
                    itemsW.Add(new Weapon(1, 1.4, Weapon.WeaponType.Axe, "COOL-AXE", 2, Item.SlotE.Weapon));
                    itemsW.Add(new Weapon(1, 1.2, Weapon.WeaponType.Hammer, "COOL-HAMMER", 1, Item.SlotE.Weapon));
                    itemsW.Add(new Weapon(1, 1.3, Weapon.WeaponType.Hammer, "COOL-HAMMER2", 1, Item.SlotE.Weapon));
                    itemsW.Add(new Weapon(1, 1.1, Weapon.WeaponType.Hammer, "COOL-HAMMER3", 1, Item.SlotE.Weapon));
                    itemsA.Add(new Armor(new PrimaryAttributes(2, 1, 1, 2), Armor.ArmorType.Mail, "COOL-CHESTPIECE", 1, Item.SlotE.Body));
                    itemsA.Add(new Armor(new PrimaryAttributes(4, 4, 1, 1), Armor.ArmorType.Plate, "COOL-HEAD", 2, Item.SlotE.Head));
                    itemsA.Add(new Armor(new PrimaryAttributes(2, 2, 2, 3), Armor.ArmorType.Plate, "COOL-LEGS", 3, Item.SlotE.Legs));
                    break;

                case "rogue": // statement sequence
                    hero = new Rogue(name);
                    itemsW.Add(new Weapon(1, 1.1, Weapon.WeaponType.Dagger, "COOL-DAGGER", 2, Item.SlotE.Weapon));
                    itemsW.Add(new Weapon(1, 1.2, Weapon.WeaponType.Sword, "COOL-SWORD", 1, Item.SlotE.Weapon));
                    itemsA.Add(new Armor(new PrimaryAttributes(1, 1, 4, 2), Armor.ArmorType.Mail, "COOL-CHESTPIECE", 1, Item.SlotE.Body));
                    itemsA.Add(new Armor(new PrimaryAttributes(1, 1, 1, 1), Armor.ArmorType.Leather, "COOL-HEAD", 2, Item.SlotE.Head));
                    itemsA.Add(new Armor(new PrimaryAttributes(2, 2, 2, 3), Armor.ArmorType.Leather, "COOL-LEGS", 3, Item.SlotE.Legs));
                    break;

                case "ranger": // statement sequence
                    hero = new Ranger(name);
                    itemsW.Add(new Weapon(1, 1.1, Weapon.WeaponType.Bow, "COOL-er-BOW", 2, Item.SlotE.Weapon));
                    itemsW.Add(new Weapon(1, 1.2, Weapon.WeaponType.Bow, "COOL-BOW", 1, Item.SlotE.Weapon));
                    itemsA.Add(new Armor(new PrimaryAttributes(1, 1, 4, 2), Armor.ArmorType.Mail, "COOL-CHESTPIECE", 1, Item.SlotE.Body));
                    itemsA.Add(new Armor(new PrimaryAttributes(1, 1, 1, 1), Armor.ArmorType.Leather, "COOL-HEAD", 2, Item.SlotE.Head));
                    itemsA.Add(new Armor(new PrimaryAttributes(2, 2, 2, 3), Armor.ArmorType.Mail, "COOL-LEGS", 3, Item.SlotE.Legs));
                    break;

                default:    // default statement sequence
                    Console.WriteLine("Error type valid character");
                    RunGameInTerminal();
                    break;
            }
        }
    }
}
