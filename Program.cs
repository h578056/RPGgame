using System;

namespace RPGgame
{
    class Program
    {
        private static PrimaryAttributes baseAttributes = new PrimaryAttributes(1, 1, 8, 5);
        static void Main(string[] args)
        {
            
            Mage mage = new Mage("mage1");
            Console.WriteLine("level beforhand: " + mage.Level + "--" + mage.BaseAttributes.ToString() + " secAttr: "+ mage.SecondaryAttributes);
            
            //Console.WriteLine(mage.BaseAttributes.Strength);
            mage.IncreaseLevel();
            Console.WriteLine("level after: " + mage.Level + "--" + mage.BaseAttributes.ToString() + " secAttr: " + mage.SecondaryAttributes);
        }
    }
}
