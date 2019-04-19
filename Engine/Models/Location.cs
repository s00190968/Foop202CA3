using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;

namespace Engine.Models
{
    public class Location
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();
        public List<MonsterEncounter> MonstersHere { get; set; } = new List<MonsterEncounter>();

        public void AddMonster(int monsterId, int encounterChance)
        {
            //if monster already exists in location
            if (MonstersHere.Exists(m => m.MonsterId == monsterId))
            {
                //change the chance of encounter only
                MonstersHere.First(m => m.MonsterId == monsterId).EncounterChance = encounterChance;
            }
            else
            {
                MonstersHere.Add(new MonsterEncounter(monsterId, encounterChance));
            }
        }

        public Monster GetMonster()
        {
            if (!MonstersHere.Any())//if there are no montsers here
            {
                return null;
            }

            //total percentage of all monsters in this location
            int total = MonstersHere.Sum(m => m.EncounterChance);

            //random number between 1 and total chanches
            int randChance = RandNumGen.NumBetween(1, total);

            //when random chance is less than running total, return that monster
            int runningTotal = 0;
            foreach ( MonsterEncounter me in MonstersHere)
            {
                runningTotal += me.EncounterChance;

                if(randChance <= runningTotal)
                {
                    return MonsterFactory.GetMonster(me.MonsterId);
                }
            }
            //in case of a problem return last
            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterId);
        }
    }
}
