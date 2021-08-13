using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame
{
    public class Ranger : Hero
    {
        public Ranger(string name) : base(name)
        {
            this.BaseAttributes = new PrimaryAttributes(8, 1, 7, 1);
        }
        public override void IncreaseLevel()
        {
            this.Level = this.Level + 1;
            this.BaseAttributes = new PrimaryAttributes(BaseAttributes.Vitality + 2, BaseAttributes.Strength + 1, BaseAttributes.Dexterity + 5, BaseAttributes.Intelligence + 1);
            this.IncreaseSecAttr(BaseAttributes);
        }
    }
}
