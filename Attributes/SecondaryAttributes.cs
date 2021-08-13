using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame
{
    public class SecondaryAttributes
    {
        public int health { get; set; }
        public int armorRating { get; set; }
        public int elementalResistance { get; set; }

        public SecondaryAttributes(PrimaryAttributes pa)
        {
            if (pa != null)
            {
                this.health = (pa.Vitality * 10);
                this.armorRating = (pa.Strength + pa.Dexterity);
                this.elementalResistance = pa.Intelligence;
            }
        }
        public SecondaryAttributes(int vit, int str, int dex, int intelligence)
        {
            this.health = (vit * 10);
            this.armorRating = (str + dex);
            this.elementalResistance = intelligence;
        }
        public override string ToString()
        {
            string secAttrTxt = " Health: " + this.health + " ArmorRating: " + this.armorRating + " ElementalResistance: " + this.elementalResistance;
            return secAttrTxt;
        }
    }
}
