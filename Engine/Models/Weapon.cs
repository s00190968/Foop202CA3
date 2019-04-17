﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    class Weapon : GameItem
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public Weapon(int id, string name, int price, int minDamage, int maxDamage) : base(id, name, price)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        public Weapon Copy()
        {
            return new Weapon(ItemTypeId, Name, Price, MinDamage, MaxDamage);
        }
    }
}
