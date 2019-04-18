using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Factories
{
    internal static class QuestFactory
    {
        private static readonly List<Quest> quests = new List<Quest>();

        static QuestFactory()
        {
            //items to complete the quest and rewards items
            List<ItemQuantity> questItems = new List<ItemQuantity>();
            List<ItemQuantity> rewardItems = new List<ItemQuantity>();

            questItems.Add(new ItemQuantity(9001, 5));
            rewardItems.Add(new ItemQuantity(1002, 1));

            //creating new quest
            quests.Add(new Quest(1, "Clear the herb garden", "Defeat the snakes in the herbalist's garden",
                25, 10, questItems,rewardItems));
        }

        internal static Quest GetQuestByID(int id)
        {
            return quests.FirstOrDefault(quest => quest.ID == id);
        }
    }
}
