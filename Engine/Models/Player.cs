using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Player : BaseNotification
    {
        private string name;
        private string characterClass;
        private int hp;
        private int xp;
        private int level;
        private int gold;

        public ObservableCollection<GameItem> Inventory { get; set; }

        //get weapons from inventory to their own list
        public List<GameItem> Weapons => Inventory.Where(i => i is Weapon).ToList();
        public ObservableCollection<QuestStatus> Quests { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string CharacterClass
        {
            get { return characterClass; }
            set
            {
                characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));

            }
        }
        public int HitPoints
        {
            get { return hp; }
            set
            {
                hp = value;
                OnPropertyChanged(nameof(HitPoints));

            }
        }
        public int ExperiencePoints
        {
            get { return xp; }
            set
            {
                xp = value;
                OnPropertyChanged(nameof(ExperiencePoints));

            }
        }
        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                OnPropertyChanged(nameof(Level));

            }
        }
        public int Gold
        {
            get { return gold; }
            set
            {
                gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
            Quests = new ObservableCollection<QuestStatus>();
        }

        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);
            OnPropertyChanged(nameof(Weapons));
        }
    }
}