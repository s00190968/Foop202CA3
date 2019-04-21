using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Factories
{
    public static class TraderFactory
    {
        private static readonly List<Trader> traders = new List<Trader>();

        static TraderFactory()
        {
            Trader susan = new Trader("Susan");
            susan.AddItemToInventory(ItemFactory.CreateGameItem(1001));

            Trader ted = new Trader("Farmer Ted");
            ted.AddItemToInventory(ItemFactory.CreateGameItem(1001));

            Trader herbalistPete = new Trader("Herbalist Pete");
            herbalistPete.AddItemToInventory(ItemFactory.CreateGameItem(1001));
        }

        public static Trader GetTraderByName(string name)
        {
            return traders.FirstOrDefault(t => t.Name == name);
        }

        private static void AddTrader(Trader trader)
        {
            if(traders.Any(t=>t.Name == trader.Name))
            {
                throw new ArgumentException($"There is already a trader called {trader.Name}");
            }
            traders.Add(trader);
        }
    }
}
