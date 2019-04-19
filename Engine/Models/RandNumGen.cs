using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public static class RandNumGen
    {
        private static readonly Random rand = new Random();

        public static int NumBetween(int a, int b)
        {
            return rand.Next(a, b + 1);
        }
    }
}
