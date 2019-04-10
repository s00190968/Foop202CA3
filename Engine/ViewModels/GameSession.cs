using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.Factories;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation { get; set; }

        public World CurrentWorld;

        public GameSession()
        {
            CurrentPlayer = new Player //player needs the player class from under models
            {
                Name = "Gille",
                CharacterClass = "Bard",
                HitPoints = 15,
                ExperiencePoints = 0,
                Level = 1,
                Gold = 10
            };

            WorldFactory wFactory = new WorldFactory();
            CurrentWorld = wFactory.CreateWorld();
            CurrentLocation = CurrentWorld.GetLocationAt(0, -1);
        }
    }
}
