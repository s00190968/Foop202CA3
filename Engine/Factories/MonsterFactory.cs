using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Factories
{
    public static class MonsterFactory
    {
        public static Monster GetMonster(int id)
        {
            switch (id)
            {
                case 1:
                    Monster snake = new Monster("Snake", "Snake.png", 4, 1, 2, 5, 1);
                    addLoot(snake, 9001, 25);
                    addLoot(snake, 9002, 75);

                    return snake;
                case 2:
                    Monster rat = new Monster("Rat", "Rat.jpg", 5, 1, 2, 5, 1);
                    addLoot(rat, 9003, 25);
                    addLoot(rat, 9004, 75);

                    return rat;

                case 3:
                    Monster spider = new Monster("Giant Spider", "Spider.jpg", 10, 2, 4, 10, 3);
                    addLoot(spider, 9005, 25);
                    addLoot(spider, 9006, 75);

                    return spider;

                default:
                    throw new ArgumentException(string.Format($"Monster type {0} doesn't exist.", id));

            }
        }
        private static void addLoot(Monster m, int itemId, int percentage)
        {
            if (RandNumGen.NumBetween(1, 100) <= percentage)
            {
                m.Inventory.Add(new ItemQuantity(itemId, 1));
            }
        }
    }
}
