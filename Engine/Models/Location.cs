using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
