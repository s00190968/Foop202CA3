using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation { get; set; }

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

            CurrentLocation = new Location
            {
                Name = "Home",
                X = 0,
                Y = -1,
                Description = "This is your home, for home is where the heart is and your bed, computer and consoles are inside of this building.",
                ImagePath = "/Engine;component/Images/Locations/home.jpg"
            };
        }
    }
}
