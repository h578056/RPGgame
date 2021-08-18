using RPGgame;
using RPGgame.HeroClasses;
using RPGgame.Items;
using RPGgame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static RPGgame.Item;

public abstract class Hero
{
    public string Name { get; set; }
	public int Level { get; set; }
	public PrimaryAttributes BaseAttributes { get; set; }
	public SecondaryAttributes SecondaryAttributes { get; set; }
	public Dictionary<Weapon.SlotE, Item> Equipment { get; set; }
	//equipment enumerator?//map that allows key to be item type the value that is the item object? created default empty
	public PrimaryAttributes TotalAttributes { get; set; }
	public double DPS { get; set; } = 1;
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
		//DPS= 
	}
	public void IncreaseSecAttr(PrimaryAttributes pa)// method to increase secondary attribute
    {
		this.SecondaryAttributes = new SecondaryAttributes(pa);
    }
	public string EquipWeapon2(Weapon weapon, List<Enum> allowedItemsForHero)// checks if level ok and correct type of item
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
			CalculateHeroDPS(weapon, TotalAttributes);
			return "New weapon equipped!";
		}
		else
		{
			throw new InvalidWeaponException();
		}
	}
	public string EquipArmor2(Armor armor, List<Enum> allowedItemsForHero) // checks if level ok and correct type of item
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

			CalculateTotalAttributes(BaseAttributes, Equipment);
			CalculateHeroDPS((Weapon)Equipment[SlotE.Weapon], TotalAttributes);
			return "New armour equipped!";
		}
		else
		{
			throw new InvalidWeaponException();
		}
	}
	public void CalculateTotalAttributes(PrimaryAttributes pa, Dictionary<Weapon.SlotE, Item> inventory)
    {
		List<SlotE> slotKeys = new List<SlotE>();
		slotKeys.Add(SlotE.Head);
		slotKeys.Add(SlotE.Body);
		slotKeys.Add(SlotE.Legs);
		List<Item> ar = slotKeys.Select(x => Equipment[x]).ToList(); //Gets all items of type Armor
		TotalAttributes = new PrimaryAttributes();// makes TotalAttribute values=0;
		foreach (Armor a in ar)
		{
			
			if (a.PrimaryAttr != null) 
			{
				//adds item attributes to total attributes
				TotalAttributes.Strength += a.PrimaryAttr.Strength;
				TotalAttributes.Vitality +=  a.PrimaryAttr.Vitality;
				TotalAttributes.Dexterity += a.PrimaryAttr.Dexterity;
				TotalAttributes.Intelligence += a.PrimaryAttr.Intelligence;
			}

		}
		if (pa != null)
		{
			//adds hero attributes to total attributes
			TotalAttributes.Strength += pa.Strength;
			TotalAttributes.Vitality += pa.Vitality;
			TotalAttributes.Dexterity += pa.Dexterity;
			TotalAttributes.Intelligence += pa.Intelligence;
		}


	}
	
	public void CalculateHeroDPSForHero(Weapon weapon, int AttrbuteForDPS)
	{
		if (weapon != null && weapon.DPS != 0)//checks that neither weapon not weapon dps value is zero
		{
			double h = (double)(1) + ((double)(AttrbuteForDPS) / (double)(100));//damage from stats
			this.DPS = Math.Round(weapon.DPS * h, 3);//weapon dps * with stat damage=total DPS
		}
	}
	
	public void PrintHeroStats() // prints stat overview for hero
    {
		StringBuilder sb = new StringBuilder();
		sb.AppendLine("Name: " + this.Name);
		sb.AppendLine("Level: " + this.Level);
		sb.AppendLine("Strenght " + TotalAttributes.Strength);
		sb.AppendLine("Dexterity: " + TotalAttributes.Dexterity);
		sb.AppendLine("Intelligence: " + TotalAttributes.Intelligence);
		sb.AppendLine("Health: " + SecondaryAttributes.Health);
		sb.AppendLine("Armor Rating: " + SecondaryAttributes.ArmorRating);
		sb.AppendLine("Elemental Resistance: " + SecondaryAttributes.ArmorRating);
		Console.WriteLine(sb);
	}
	public abstract string EquipWeapon(Weapon weapon); //call method EquipWeapon2

	public abstract string EquipArmor(Armor armor);//call method EquipArmor2

	public abstract void IncreaseLevel(int optionalint = 1); //method to increase each heroes level and primary attributes
	public abstract void CalculateHeroDPS(Weapon weapon, PrimaryAttributes totalAttrbutes); //calls CalculateHeroDPSForHero after checking if atribute for hero dps is ok
	

}
