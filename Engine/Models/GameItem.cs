using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public enum ItemType { Weapons, StandardItem };
    public class GameItem
    {
        public int ItemTypeID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public ItemType Type { get; set; }

        public GameItem(int id, string name, int price, ItemType type)
        {
            ItemTypeID = id;
            Name = name;
            Price = price;
            Type = type;
        }

        public GameItem Clone()
        {
            return new GameItem(ItemTypeID, Name, Price, Type);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
