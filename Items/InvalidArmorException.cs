using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Items
{
    [Serializable]
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException()
            : base("Invalid Armor Equip, to high level item or incorrect item type")
        {

        }
    }
}
