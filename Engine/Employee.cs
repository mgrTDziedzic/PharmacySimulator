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

        public Employee(int id, string name, int assertiveness)
        {
            ID = id;
            Name = name;
            Assertiveness = assertiveness;
            Assertiveness = 0; // test
        }
    }
}
