using RPGgame;
using RPGgame.Items;
using RPGgame.Weapons;
using System;

public abstract class Hero
{
    public string Name { get; set; }
	public int Level { get; set; }
	public PrimaryAttributes BaseAttributes { get; set; }
	public SecondaryAttributes SecondaryAttributes { get; set; }
	//equipment enumerator?//map that allows key to be item type the value that is the item object? created default empty
	//private double totalAttributes { get; set; }

	public Hero (string name)//, int baseAtr, int secAtr, double totAtr)
	{
		this.Name = name;
		this.Level = 1;
		this.BaseAttributes = BaseAttributes;
		this.SecondaryAttributes = new SecondaryAttributes(BaseAttributes);
	}
	public void IncreaseSecAttr(PrimaryAttributes pa)
    {
		this.SecondaryAttributes = new SecondaryAttributes(pa);
    }
	public void EquipWeapon(Weapon weapon)
    {
		//check if character can equip weapon the equip over previously equiped one
		//throw custom exception if not
    }
	public void EquipArmor(Armor armor)
    {
		//check if character can equip item then equip
		//custom exception if not
    }
    public abstract void IncreaseLevel();
}
