using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame.Weapons
{
    public class Weapon : Item
    {
        public int BaseDamage { get; set; }
        public double AttacksPerSecond { get; set; }
        public WeaponType WeaponT { get; set; }
        public double DPS { get; }
        public Weapon() { }
        public Weapon(int baseDamage, double attacksPerSecond, WeaponType weaponType,string name,int reqLevel, SlotE slot) : base(name, reqLevel, slot)
        {
            this.BaseDamage = baseDamage;
            this.AttacksPerSecond = attacksPerSecond;
            this.DPS = this.BaseDamage * this.AttacksPerSecond;
            this.WeaponT = weaponType;
        }
        public enum WeaponType
        {
            Axe,
            Bow,
            Dagger,
            Hammer,
            Staff,
            Sword,
            Wand
        }
    }
}
