using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame
{
   public class PrimaryAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Vitality { get; set; }

        public PrimaryAttributes()
        {
        }
        public PrimaryAttributes(int vit, int str, int dex, int intelli)
        {
            this.Strength = str;
            this.Dexterity = dex;
            this.Intelligence = intelli;
            this.Vitality = vit;
        }
        public override string ToString()
        {
            string atrTxt = "STR: " + this.Strength + " DEX: " + this.Dexterity + " INT: " + this.Intelligence + " VIT: " + this.Vitality; 

            return atrTxt; 
        }

    }
}
