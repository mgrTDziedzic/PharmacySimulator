using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal SellPrice { get; set; }
        //public string NamePlural { get; set; }
        public int MaxQuantityBought { get; set; }
        public int MinQuantityBought { get; set; }

        public Item(int iD, string name, decimal sellPrice, int maxQuanittyBought, int minQuantityBought)
        {
            ID = iD;
            Name = name;
            SellPrice = sellPrice;
            MaxQuantityBought = maxQuanittyBought;
            MinQuantityBought = minQuantityBought;
        }
    }
}
