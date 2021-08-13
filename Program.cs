using System;

namespace RPGgame
{
    class Program
    {
        private static PrimaryAttributes baseAttributes = new PrimaryAttributes(1, 1, 8, 5);
        static void Main(string[] args)
        {
            
            Mage mage = new Mage("mage1", baseAttributes);
            Console.WriteLine("level beforhand: " + mage.level + "--"+ mage.baseAttributes.ToString() + " secAttr: " + mage.secondaryAttributes);
            
            Console.WriteLine(mage.baseAttributes.strength);
            mage.IncreaseLevel();
           Console.WriteLine("level after: " + mage.level + "--" + mage.baseAttributes.ToString()+ " secAttr: " + mage.secondaryAttributes);
        }
    }
}
