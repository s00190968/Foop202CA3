using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardXP { get; set; }
        public int RewardGold { get; set; }

        public List<ItemQuantity> QuestItems { get; set; }//itmes to hand in 
        public List<ItemQuantity> RewardItems { get; set; }//items player gets as a reward

        public Quest(int id, string name, string description, int rewardXp, int rewardGold, List<ItemQuantity> questItems, List<ItemQuantity> rewardItems)
        {
            ID = id;
            Name = name;
            Description = description;
            RewardXP = rewardXp;
            RewardGold = rewardGold;
            QuestItems = questItems;
            RewardItems = rewardItems;
        }
    }
}
