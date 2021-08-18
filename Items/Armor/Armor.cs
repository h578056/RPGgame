using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Items
{
    public class Armor : Item
    {
        public PrimaryAttributes PrimaryAttr { get; set; }
        public ArmorType ArmorT { get; set; }
        public Armor() { }
        public Armor(PrimaryAttributes pa, ArmorType at, string name, int reqLevel, SlotE slot) : base(name, reqLevel, slot)
        {
            this.PrimaryAttr = pa;
            this.ArmorT = at;
        }
        public enum ArmorType
        {
            Cloth, 
            Leather,
            Mail,
            Plate
        }
    }
}
