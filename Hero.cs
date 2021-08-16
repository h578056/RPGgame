using RPGgame;
using RPGgame.HeroClasses;
using RPGgame.Items;
using RPGgame.Weapons;
using System;
using System.Collections.Generic;

public abstract class Hero
{
    public string Name { get; set; }
	public int Level { get; set; }
	public PrimaryAttributes BaseAttributes { get; set; }
	public SecondaryAttributes SecondaryAttributes { get; set; }
	public Dictionary<Weapon.SlotE, Item> Equipment { get; set; }
	//equipment enumerator?//map that allows key to be item type the value that is the item object? created default empty
	//private double totalAttributes { get; set; }
	public Hero (string name)
	{
		this.Name = name;
		this.Level = 1;
		this.BaseAttributes = BaseAttributes;
		this.SecondaryAttributes = new SecondaryAttributes(BaseAttributes);
		Equipment = new Dictionary<Weapon.SlotE, Item>();
		Equipment.Add(Weapon.SlotE.Head, new Armor());
		Equipment.Add(Weapon.SlotE.Body, new Armor());
		Equipment.Add(Weapon.SlotE.Legs, new Armor());
		Equipment.Add(Weapon.SlotE.Weapon, new Weapon());
	}
	public void IncreaseSecAttr(PrimaryAttributes pa)// method to incresae secondary attribute
    {
		this.SecondaryAttributes = new SecondaryAttributes(pa);
    }
	public void EquipWeapon2(Weapon weapon, List<Enum> allowedItemsForHero)// checks if level ok and correct type of item
	{
		bool isAllowed = false;
		foreach (AllowedItems e in allowedItemsForHero)
		{
			if (weapon.WeaponT.ToString().CompareTo(e.ToString()) == 0 && weapon.RequiredLevel <= this.Level)
			{
				isAllowed = true;
			}
		}
		if (isAllowed == true)
		{
			this.Equipment[weapon.Slot] = weapon;

		}
		else
		{
			throw new InvalidWeaponException();
		}
	}
	public void EquipArmor2(Armor armor, List<Enum> allowedItemsForHero) // checks if level ok and correct type of item
    {
		bool isAllowed = false;
		foreach (AllowedItems e in allowedItemsForHero)
		{
			if (armor.ArmorT.ToString().CompareTo(e.ToString()) == 0 && armor.RequiredLevel <= this.Level)
			{
				isAllowed = true;
			}
		}
		if (isAllowed == true)
		{
			this.Equipment[armor.Slot] = armor;

		}
		else
		{
			throw new InvalidWeaponException();
		}
	}
	public abstract void EquipWeapon(Weapon weapon); //call method EquipWeapon2

	public abstract void EquipArmor(Armor armor);//call method EquipArmor2

	public abstract void IncreaseLevel(); //meathod to increase each heroes level and attributes
	

}
