using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Prescription
    {
        public List<InventoryItem> Contents { get; set; }

        public Prescription()
        {
            Contents = new List<InventoryItem>();
        }
    }
}
