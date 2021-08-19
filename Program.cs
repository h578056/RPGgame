
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
            Program p = new Program();
            p.RunGameInTerminal();
        }
        public void RunGameInTerminal()
        {
            SelectHeroType();
            ActionToDo();
        }
        public void ActionToDo() //repeats if level or equip either armor or weapon
        {
            hero.PrintHeroStats();
            Console.WriteLine("Type <L> for level up");
            Console.WriteLine("Type <W> to equip weapon");
            Console.WriteLine("Type <A> to equip armor");
            Console.WriteLine("Type <END> to end game");
            string action = Console.ReadLine();
            switch (action)
            {

                case "W": // statement sequence
                    try
                    {
                        EquipWeapon(hero);
                    }
                    catch(InvalidWeaponException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    ActionToDo();
                    break;

                case "A": // statement sequence
                    try
                    {
                        EquipArmor(hero);
                    }
                    catch(InvalidArmorException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    ActionToDo();
                    break;

                case "L": // statement sequence
                    //hero.IncreaseLevel();
                    LevelUp(hero);
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
        public void EquipArmor(Hero hero) //equip random armor from list of armors
        {
            int lvl = hero.Level;
            Random random = new Random();
            int number = random.Next(0, itemsA.Count - 1);
            Armor a = itemsA[number];
            hero.EquipArmor(a);
        }
        public void EquipWeapon(Hero hero)//equip random weapon from list of weapons
        {
            int lvl = hero.Level;
            Random random = new Random();
            int number = random.Next(0, itemsW.Count-1);
            Weapon w = itemsW[number];
            hero.EquipWeapon(w);
        }
        public string CreateHeroName()//takse input for hero name
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

        public void LevelUp(Hero h) //level up character pisible to type new level
        {
            Console.WriteLine("Level up(cannot level down)?");
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
        public void SelectHeroType() //select type of hero then create som items for that hero type
        {
            Console.WriteLine("Create character: ");
            Console.WriteLine("Type <mage> for mage");
            Console.WriteLine("Type <warrior> for warrior");
            Console.WriteLine("Type <rogue> for rogue");
            Console.WriteLine("Type <ranger> for ranger");
            string heroType = Console.ReadLine().ToLower();
            string name = CreateHeroName();
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
