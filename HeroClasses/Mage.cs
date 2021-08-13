using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame
{
    public class Mage : Hero
    {
        public Mage(string name) : base(name)
        {
            this.BaseAttributes= new PrimaryAttributes(5, 1, 1, 8);
            this.SecondaryAttributes = new SecondaryAttributes(BaseAttributes);
        }
        public override void IncreaseLevel()
        {
            this.Level = this.Level + 1;
            this.BaseAttributes = new PrimaryAttributes(BaseAttributes.Vitality +3, BaseAttributes.Strength + 1, BaseAttributes.Dexterity + 1, BaseAttributes.Intelligence + 5) ;
            this.IncreaseSecAttr(BaseAttributes);
        }
    }
}
