﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static readonly List<GameItem> standardGameItems = new List<GameItem>();

        static ItemFactory()
        {
            standardGameItems.Add(new Weapon(1001, "Pointy Stick", 1, ItemType.Weapons, 1, 2));
            standardGameItems.Add(new Weapon(1002, "Rusty Sword", 5, ItemType.Weapons, 1, 3));
            standardGameItems.Add(new GameItem(9001, "Snake Fang", 1, ItemType.StandardItem));
            standardGameItems.Add(new GameItem(9002, "Snake Skin", 2, ItemType.StandardItem));
            standardGameItems.Add(new GameItem(9003, "Rat Tail", 1, ItemType.StandardItem));
            standardGameItems.Add(new GameItem(9004, "Rat Fur", 2, ItemType.StandardItem));
            standardGameItems.Add(new GameItem(9005, "Spider Fang", 1, ItemType.StandardItem));
            standardGameItems.Add(new GameItem(9006, "Spider Silk", 2, ItemType.StandardItem));
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

            if (standardItem != null)
            {
                if (standardItem is Weapon)
                {
                    return (standardItem as Weapon).Clone();
                }

                return standardItem.Clone();
            }

            return null;
        }
    }
}
