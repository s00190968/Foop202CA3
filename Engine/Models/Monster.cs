using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Monster : BaseNotification
    {
        private int hp;

        public string Name { get; private set; }
        public string ImageName { get; set; }
        public int MaxHp { get; set; }
        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
                OnPropertyChanged(nameof(Hp));
            }
        }

        public int RewardExp { get; private set; }
        public int RewardGold { get; private set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monster(string name, string imageName, int maxhp, int minDamage, int maxDamage, int rewardxp, int rewardgold)
        {
            Name = name;
            ImageName = $"/Engine;component/Images/Monsters/{imageName}";
            MaxHp = maxhp;
            Hp = maxhp;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            RewardExp = rewardxp;
            RewardGold = rewardgold;

            Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}
