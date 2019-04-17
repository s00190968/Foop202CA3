using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static List<GameItem> standardGameItems;

        static ItemFactory()
        {
            standardGameItems = new List<GameItem>();

            standardGameItems.Add(new Weapon(1001, "Pointy Stick", 1, 1, 2));
            standardGameItems.Add(new Weapon(1001, "Rsty Sword", 5, 1, 3));
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = standardGameItems.FirstOrDefault(item => item.ItemTypeId == itemTypeID);
            if(standardItem != null)
            {
                return standardItem.Clone();
            }
            return null;
        }
    }
}
