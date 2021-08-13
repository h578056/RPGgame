using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame
{
    public class Mage : Hero
    {
        //public PrimaryAttributes baseAttributes { get; set; }
        public Mage(string name, PrimaryAttributes baseAttributes) : base(name, baseAttributes)
        {
            //baseAttributes = new PrimaryAttributes(1, 1, 8, 5);
            //this.baseAttributes.s

        }
        public override void IncreaseLevel()
        {
            this.level = this.level + 1;
            this.baseAttributes = new PrimaryAttributes(baseAttributes.strength + 1, baseAttributes.dexterity + 1, baseAttributes.intelligence + 5, baseAttributes.vitality +3) ;
            this.IncreaseSecAttr(baseAttributes);
        }
    }
}
