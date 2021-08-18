using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public SlotE Slot { get; set; }
        public Item() { }
        public Item(string name, int reqLevel, SlotE slot)
        {
            this.Name = name;
            this.RequiredLevel = reqLevel;
            this.Slot = slot;
        }
        public enum SlotE
        {
            Head,
            Body,
            Legs,
            Weapon
        }
    }
}
