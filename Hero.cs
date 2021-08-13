using RPGgame;
using System;

public abstract class Hero
{
    public string name { get; set; }
	public int level { get; set; }
	public PrimaryAttributes baseAttributes { get; set; }
	public SecondaryAttributes secondaryAttributes { get; set; }
	//private double totalAttributes { get; set; }

	public Hero (string name, PrimaryAttributes baseAttributes)//, int baseAtr, int secAtr, double totAtr)
	{
		this.name = name;
		this.level = 1;
		this.baseAttributes = baseAttributes;
		this.secondaryAttributes = new SecondaryAttributes(baseAttributes);
	}
	public void IncreaseSecAttr(PrimaryAttributes pa)
    {
		this.secondaryAttributes = new SecondaryAttributes(pa);
    }
    public abstract void IncreaseLevel();
}
