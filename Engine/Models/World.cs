﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class World
    {
        private List<Location> locations = new List<Location>();

         //internal because only world factory should use this function
         internal void AddLocation(int x, int y, string name, string description, string imagePath)
        {
            locations.Add(new Location
            {
                Name = name,
                X = x,
                Y = y,
                Description = description,
                ImagePath = imagePath
            });
        }

        public Location GetLocationAt(int x, int y)
        {
            foreach(Location l in locations)
            {
                if(l.X == x && l.Y == y)
                {
                    return l;
                }
            }
            Console.WriteLine("Location at (" + x + ", " + y + ") not found!");
            return null;
        }
    }
}
