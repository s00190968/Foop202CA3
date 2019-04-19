using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class MonsterEncounter
    {
        public int MonsterId { get; set; }
        public int EncounterChance { get; set; }

        public MonsterEncounter(int id, int chance)
        {
            MonsterId = id;
            EncounterChance = chance;
        }
    }
}
