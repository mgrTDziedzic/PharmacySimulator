using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Patient
    {
        public int Id { get; }
        public string Name { get; }
        public int Aggressiveness { get; }
        public string AggroText
        {
            get
            {
                int randomIndex = RandomNumberGenerator.NumberBetween(0, aggroTextArray.Length - 1);
                return Name + " " + aggroTextArray[randomIndex];
            }   
        }


        private string[] aggroTextArray;

        public List<InventoryItem> Prescription { get; set; }
        public Queue<InventoryItem> OTCList { get; private set; }

        public Patient(int id, string name, int aggressiveness, string[] aggroTextsArray)
        {
            Id = id;
            Name = name;
            Aggressiveness = aggressiveness;
         //   Aggressiveness = 100; // test
            this.aggroTextArray = aggroTextsArray;
            PopulateOTCList();
        }

        private void PopulateOTCList()
        {
            this.OTCList = new Queue<InventoryItem>();

            int numberOfOTCLines = RandomNumberGenerator.NumberBetween(1, 10);

            for (int i = 0; i < numberOfOTCLines; i++)
            {
                int randomIndex = RandomNumberGenerator.NumberBetween(0, World.Items.Count - 1);
                Item wantedItem = World.Items[randomIndex];

                OTCList.Enqueue(new InventoryItem(wantedItem, RandomNumberGenerator.NumberBetween(wantedItem.MinQuantityBought, wantedItem.MaxQuantityBought)));
            }
        }
    }
}
