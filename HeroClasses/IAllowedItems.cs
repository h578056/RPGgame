using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.HeroClasses
{
    public interface IAllowedItems
    {
        List<Enum> AllowedItemsForHero { get; set;} //NB all lower case or
    }
}
