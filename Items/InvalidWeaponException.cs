using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Items
{
    [Serializable]
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException()
            : base("Invalid Weapon Equip, to high level item or incorrect item type")
        {
           
        }
    }
}
