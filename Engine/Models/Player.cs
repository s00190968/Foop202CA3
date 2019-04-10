using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Player : INotifyPropertyChanged
    {
        private string name;
        private string characterClass;
        private int hp;
        private int xp;
        private int level;
        private int gold;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string CharacterClass
        {
            get { return characterClass; }
            set
            {
                characterClass = value;
                OnPropertyChanged("CharacterClass");

            }
        }
        public int HitPoints
        {
            get { return hp; }
            set
            {
                hp = value;
                OnPropertyChanged("HitPoints");

            }
        }
        public int ExperiencePoints
        {
            get { return xp; }
            set
            {
                xp = value;
                OnPropertyChanged("ExperiencePoints");

            }
        }
        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                OnPropertyChanged("Level");

            }
        }
        public int Gold
        {
            get { return gold; }
            set
            {
                gold = value;
                OnPropertyChanged("Gold");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}