using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame
{
    public class SecondaryAttributes
    {
        public int Health { get; set; }
        public int ArmorRating { get; set; }
        public int ElementalResistance { get; set; }

        public SecondaryAttributes(PrimaryAttributes pa)
        {
            if (pa != null)
            {
                this.Health = (pa.Vitality * 10);
                this.ArmorRating = (pa.Strength + pa.Dexterity);
                this.ElementalResistance = pa.Intelligence;
            }
        }
        public SecondaryAttributes(int vit, int str, int dex, int intelligence)
        {
            this.Health = (vit * 10);
            this.ArmorRating = (str + dex);
            this.ElementalResistance = intelligence;
        }
        public override string ToString()
        {
            string secAttrTxt = " Health: " + this.Health + " ArmorRating: " + this.ArmorRating + " ElementalResistance: " + this.ElementalResistance;
            return secAttrTxt;
        }
    }
}
