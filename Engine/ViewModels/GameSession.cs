﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;
using Engine.Factories;
using System.ComponentModel;
using Engine.EventArgs;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotification
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        private Location currentLoc;
        private Monster currentMonster;

        public Player CurrentPlayer { get; set; }
        public Weapon CurrentWeapon { get; set; }

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

                if(CurrentMonster != null)
                {
                    RaiseMessage($"You see a {CurrentMonster.Name} here!");
                }
            }
        }

        public bool HasMonster => CurrentMonster != null;

        #region direction checks

        //returns true if there is a place up from current
        public bool CanMoveUp => CurrentWorld.GetLocationAt(CurrentLocation.X, CurrentLocation.Y + 1) != null;
        
        //return true if there is a place down from current
        public bool CanMoveDown => CurrentWorld.GetLocationAt(CurrentLocation.X, CurrentLocation.Y - 1) != null;

        //return true if there is a place to the left from current
        public bool CanMoveLeft => CurrentWorld.GetLocationAt(CurrentLocation.X - 1, CurrentLocation.Y) != null;

        //return true if there is a place to the right from current
        public bool CanMoveRight => CurrentWorld.GetLocationAt(CurrentLocation.X + 1, CurrentLocation.Y) != null;

        #endregion

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

            if (!CurrentPlayer.Weapons.Any())
            {
                CurrentPlayer.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            }

            CurrentWorld = WorldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.GetLocationAt(0, -1);
        }

        #region movement

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
        #endregion

        public void AttackCurrentMonster()
        {
            if(CurrentWeapon == null)
            {
                RaiseMessage("You must select a weapon to attack with!");
                return;
            }

            //random amount of damage to monster
            int damageToMonster = RandNumGen.NumBetween(CurrentWeapon.MinDamage, CurrentWeapon.MaxDamage);

            if(damageToMonster == 0)
            {
                RaiseMessage($"You missed the {CurrentMonster.Name}.");
            }
            else
            {
                currentMonster.Hp -= damageToMonster;
                RaiseMessage($"You dealt the {CurrentMonster.Name} with {damageToMonster} points of damage!");
            }

            //if monster was killed get loot
            if(currentMonster.Hp <= 0)
            {
                RaiseMessage("");
                RaiseMessage($"You defeated the {CurrentMonster.Name}!");
                RaiseMessage("");

                CurrentPlayer.ExperiencePoints += CurrentMonster.RewardExp;
                CurrentPlayer.Gold += CurrentMonster.RewardGold;

                RaiseMessage($"You received {CurrentMonster.RewardExp} of EXP \n and {CurrentMonster.RewardGold} gold.");

                foreach(ItemQuantity iq in CurrentMonster.Inventory)//loop though all items carried by monster
                {
                    GameItem item = ItemFactory.CreateGameItem(iq.ItemId);//create a new item with item fsctory using the itemid
                    CurrentPlayer.AddItemToInventory(item);//add item to player's inventory
                    RaiseMessage($"You received {iq.Quantity} {item.Name}.");
                }

                GetMonsterAtLocation();//get a new monster for the location
            }
            else//let monster attack
            {
                int damageToPlayer = RandNumGen.NumBetween(CurrentMonster.MinDamage, CurrentMonster.MaxDamage);

                if(damageToPlayer == 0)
                {
                    RaiseMessage($"{CurrentMonster.Name} attacks, but misses you. :( \nIt seems sad.");
                }
                else
                {
                    CurrentPlayer.HitPoints -= damageToPlayer;
                    RaiseMessage($"{CurrentMonster.Name} hits you for {damageToPlayer} points of damage. :) \nIt's very happy.");
                }

                //if player dies move them back home and restore hp
                if(CurrentPlayer.HitPoints <= 0)
                {
                    RaiseMessage("");
                    RaiseMessage($"{CurrentMonster.Name} defeated you! XDD \nIt's dancing in joy.");
                    RaiseMessage("");

                    RaiseMessage("A random adventurer saves you and takes you back to the nearest village.");
                    CurrentLocation = CurrentWorld.GetLocationAt(0, -1);//home
                    CurrentPlayer.HitPoints = CurrentPlayer.Level * 10;
                }
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

        private void RaiseMessage(string msg)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(msg));
        }
    }
}
