using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame
{
   public class PrimaryAttributes
    {
        public int strength { get; set; }
        public int dexterity { get; set; }
        public int intelligence { get; set; }
        public int vitality { get; set; }

        public PrimaryAttributes()
        {
        }
        public PrimaryAttributes(int str, int dex, int intelli, int vit)
        {
            this.strength = str;
            this.dexterity = dex;
            this.intelligence = intelli;
            this.vitality = vit;
        }
        public override string ToString()
        {
            string atrTxt = "STR: " + this.strength + " DEX: " + this.dexterity + " INT: " + this.intelligence + " VIT: " + this.vitality; 

            return atrTxt; 
        }

    }
}
