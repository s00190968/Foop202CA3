using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.Factories;
using System.ComponentModel;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotification
    {
        private Location currentLoc;
        private Monster currentMonster;

        public Player CurrentPlayer { get; set; }

        public Location CurrentLocation
        {
            get
            {
                return currentLoc;
            }
            set
            {
                currentLoc = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CanMoveUp));
                OnPropertyChanged(nameof(CanMoveDown));
                OnPropertyChanged(nameof(CanMoveLeft));
                OnPropertyChanged(nameof(CanMoveRight));

                GivePlayerQuestsAtLocation();
                GetMonsterAtLocation();
            }
        }

        public Monster CurrentMonster
        {
            get
            {
                return currentMonster;
            }
            set
            {
                currentMonster = value;
                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));
            }
        }

        public bool HasMonster => CurrentMonster != null;

        public bool CanMoveUp//returns true if there is a place up from current
        {
            get
            {
                return CurrentWorld.GetLocationAt(CurrentLocation.X, CurrentLocation.Y + 1) != null;
            }
        }
        public bool CanMoveDown//return true if there is a place down from current
        {
            get
            {
                return CurrentWorld.GetLocationAt(CurrentLocation.X, CurrentLocation.Y - 1) != null;
            }
        }
        public bool CanMoveLeft//return true if there is a place to the left from current
        {
            get
            {
                return CurrentWorld.GetLocationAt(CurrentLocation.X - 1, CurrentLocation.Y) != null;
            }
        }
        public bool CanMoveRight//return true if there is a place to the right from current
        {
            get
            {
                return CurrentWorld.GetLocationAt(CurrentLocation.X + 1, CurrentLocation.Y) != null;
            }
        }

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
            CurrentWorld = WorldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.GetLocationAt(0, -1);
        }

        public void MoveUp()
        {
            if (CanMoveUp)
            {
                CurrentLocation = CurrentWorld.GetLocationAt(CurrentLocation.X, CurrentLocation.Y + 1);
            }
        }
        public void MoveDown()
        {
            if (CanMoveDown)
            {
                CurrentLocation = CurrentWorld.GetLocationAt(CurrentLocation.X, CurrentLocation.Y - 1);
            }
        }
        public void MoveLeft()
        {
            if (CanMoveLeft)
            {
                CurrentLocation = CurrentWorld.GetLocationAt(CurrentLocation.X - 1, CurrentLocation.Y);
            }
        }
        public void MoveRight()
        {
            if (CanMoveRight)
            {
                CurrentLocation = CurrentWorld.GetLocationAt(CurrentLocation.X + 1, CurrentLocation.Y);
            }
        }

        private void GivePlayerQuestsAtLocation()
        {
            foreach(Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                //if player doesn't have a quest with the id in location
                if(!CurrentPlayer.Quests.Any(q => q.PlayerQuest.ID == quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));//add quest to player
                }
            }
        }

        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }
    }
}
