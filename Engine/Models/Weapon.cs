using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public Weapon(int id, string name, int price, ItemType type, int minDamage, int maxDamage) : base(id, name, price, type)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Type = type;
        }

        public Weapon Copy()
        {
            return new Weapon(ItemTypeID, Name, Price, Type, MinDamage, MaxDamage);
        }
    }
}
