using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.HeroClasses
{
    public class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {
            this.BaseAttributes = new PrimaryAttributes(10, 5, 2, 1);
        }
        public override void IncreaseLevel()
        {
            this.Level = this.Level + 1;
            this.BaseAttributes = new PrimaryAttributes(BaseAttributes.Vitality + 5, BaseAttributes.Strength + 3, BaseAttributes.Dexterity + 2, BaseAttributes.Intelligence + 1);
            this.IncreaseSecAttr(BaseAttributes);
        }
    }
}
