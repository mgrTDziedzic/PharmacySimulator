using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Pharmacy
    {
        private DateTime dateTime;
        private Queue<Patient> TodayPatients;

        public decimal Balance { get; set; }
        public int Reputation { get; set; }
        public int ChamberReputation { get; set; }

        public List<InventoryItem> Inventory { get; set; }
        public List<Employee> Employees { get; set; }
        
        public Queue<Patient> PatientsQueue;

        public Workstation[] Workstations { get; private set; }

        public Pharmacy()
        {
            Inventory = new List<InventoryItem>();
            Employees = new List<Employee>();
            Workstations = new Workstation[4];
            PatientsQueue = new Queue<Patient>();
            TodayPatients = new Queue<Patient>();
            ShufflePatients();
            dateTime = new DateTime(2019, 1, 1, 8, 0, 0);
            Initialize();
        }

        private void Initialize() // Do testów - tworzymy jakieś towary na magazynie i pracowników
        {          

            foreach (Item item in World.Items)
            {
                int quantity = RandomNumberGenerator.NumberBetween(0, 15);
                AddItemToInventory(item, quantity);
            }

            Workstations[0] = new Workstation(1, this);
            Workstations[0].CurrentEmployee = new Employee(1, "Janek", 100);

            Workstations[1] = new Workstation(2, this);
            Workstations[1].CurrentEmployee = new Employee(2, "MP", 10);

            Workstations[2] = new Workstation(3, this);
            Workstations[2].CurrentEmployee = new Employee(3, "Mała Mi", 30);

            Workstations[3] = new Workstation(4, this);

        }

        public void AddItemToInventory(Item itemToAdd, int quantity)
        {
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == itemToAdd.ID)
                {
                    // They have the item in their inventory, so increase the quantity by one
                    ii.Quantity += quantity;

                    return; // We added the item, and are done, so get out of this function
                }
            }
            // They didn't have the item so add it to the inventory with quantity of 1

            Inventory.Add(new InventoryItem(itemToAdd, quantity));
        }

        public string ProcessNextTurn()
        {
            string result = dateTime.ToShortTimeString() + "-------------------------------" + Environment.NewLine;

            if (RandomNumberGenerator.Chance(100) && (TodayPatients.Count > 0))
            {
                Patient newPatient = TodayPatients.Dequeue();
                PatientsQueue.Enqueue(newPatient);
                result += newPatient.Name + " przychodzi do apteki" + Environment.NewLine;
            }

            for (int i = 0; i < Workstations.Length - 1; i++)
            {
                result += Workstations[i].DoJob();
            }

            dateTime = dateTime.AddMinutes(5);

            return result;
        }

        private void ShufflePatients() // Przetasowanie pacjentów przed kolejnym dniem
        {
            List<Patient> randomizedPatients = World.Patients.OrderBy(x => RandomNumberGenerator.NumberBetween(0,1)).ToList();

            foreach (Patient patient in randomizedPatients)
            {
                TodayPatients.Enqueue(patient);
            }
        }
    }
}
