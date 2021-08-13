using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.HeroClasses
{
    public class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {
            this.BaseAttributes = new PrimaryAttributes(8, 2, 6, 1);
        }
        public override void IncreaseLevel()
        {
            this.Level = this.Level + 1;
            this.BaseAttributes = new PrimaryAttributes(BaseAttributes.Vitality + 3, BaseAttributes.Strength + 1, BaseAttributes.Dexterity + 4, BaseAttributes.Intelligence + 1);
            this.IncreaseSecAttr(BaseAttributes);
        }
    }
}
