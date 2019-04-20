using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    //internal because it should only be used inside of engine project
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            #region locations

            newWorld.AddLocation(-2, -1, "Farmer's Field",
                "There are rows of corn growing here, with giant rats hiding between them.",
                "FarmFields.png");

            newWorld.AddLocation(-1, -1, "Farmer's House",
                "This is the house of your neighbor, Farmer Ted.",
                "Farmhouse.png");

            newWorld.AddLocation(0, -1, "Home",
                "This is your home",
                "Home.png");

            newWorld.AddLocation(-1, 0, "Trading Shop",
                "The shop of Susan, the trader.",
                "Trader.jpg");

            newWorld.AddLocation(0, 0, "Town square",
                "You see a fountain here.",
                "TownSquare.jpg");

            newWorld.AddLocation(1, 0, "Town Gate",
                "There is a gate here, protecting the town from giant spiders.",
                "TownGate.jpg");

            newWorld.AddLocation(2, 0, "Spider Forest",
                "The trees in this forest are covered with spider webs.",
                "SpiderForest.jpg");

            newWorld.AddLocation(0, 1, "Herbalist's hut",
                "You see a small hut, with plants drying from the roof.",
                "HerbalistsHut.jpg");

            newWorld.AddLocation(0, 2, "Herbalist's garden",
                "There are many plants here, with snakes hiding behind them.",
                "HerbalistsGarden.jpg");

            #endregion

            #region quests

            newWorld.GetLocationAt(0, 1).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(1));

            #endregion

            #region monsters

            //rats to farmers field
            newWorld.GetLocationAt(-2, -1).AddMonster(2,100);

            //spiders to spider forest
            newWorld.GetLocationAt(2, 0).AddMonster(3, 100);
            
            //snakes to herb garden
            newWorld.GetLocationAt(0, 2).AddMonster(1, 100);

            #endregion

            return newWorld;
        }
    }
}
