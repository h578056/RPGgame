using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame
{
    public class Item
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public string Slot { get; set; }

        public Item(string name, int reqLevel, string slot)
        {
            this.Name = name;
            this.RequiredLevel = reqLevel;
            this.Slot = slot;
        }
    }
}
