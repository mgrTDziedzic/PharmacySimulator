using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Employee
    {
        public int ID { get; }
        public string Name { get; }
        public int Assertiveness { get; set; }

        public string IdleText
        {
            get
            {
                int randomIndex = RandomNumberGenerator.NumberBetween(0, idleTextArray.Length - 1);
                return Name + " " + idleTextArray[randomIndex];
            }
        }

        private string[] idleTextArray;

        public Employee(int iD, string name, int assertiveness, string[] idleTextArray)
        {
            ID = iD;
            Name = name;
            Assertiveness = assertiveness;
            this.idleTextArray = idleTextArray;
        }
    }
}
