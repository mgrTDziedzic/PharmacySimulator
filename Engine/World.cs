using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Employee> Employees = new List<Employee>();
        public static readonly List<Patient> Patients = new List<Patient>();

        static World()
        {
            PopulateItems();
            PopulateOTCItems();
            PopulateEmployees();
            PopulatePatients();
        }

        private static void PopulateItems()
        {
            Items.Add(new Item(2, "Dupomox 1 g", 20M, 1, 1));
            Items.Add(new Item(4, "Dupomentin 1 g", 20M, 1, 1));
            Items.Add(new Item(5, "Simvasrak 20 mg", 20M, 1, 4));
            Items.Add(new Item(6, "Duporenal 10 mg", 10M, 1, 4));
        }

        private static void PopulateOTCItems()
        {
            Items.Add(new Item(1000, "Srakostop 200 mg", 9.90M, 1, 2));
            Items.Add(new Item(1001, "Senna Extra", 11.90M, 1, 2));
            Items.Add(new Item(1002, "Kutassum Extr. Sicc.", 49.90M, 1, 1));
            Items.Add(new Item(1003, "Asap 500 mg", 5.90M, 1, 1));
            Items.Add(new Item(1005, "Syrop Lewoślazowy", 3.90M, 1, 1));
            Items.Add(new Item(1006, "Dupoprofen 200 mg", 7.90M, 1, 1));
            Items.Add(new Item(1007, "Dupoprofen 400 mg", 10.90M, 1, 1));
            Items.Add(new Item(1008, "Diclosraja żel", 9.99M, 1, 1));
            Items.Add(new Item(1009, "Therasru saszetki", 14.90M, 1, 1));
            Items.Add(new Item(1100, "LaBroche-Possał krem", 69.90M, 1, 1));
            Items.Add(new Item(1101, "LaBroche-Possał tonik", 49.90M, 1, 1));
            Items.Add(new Item(1201, "Ścierac jour krem", 179.90M, 1, 1));
            Items.Add(new Item(1202, "Ścierac nuit krem", 179.90M, 1, 1));
            Items.Add(new Item(1302, "Kompresiki 5x5 cm", 0.70M, 3, 10));
            Items.Add(new Item(1303, "Kompresiki 7,5x7,5 cm", 0.80M, 3, 10));
            Items.Add(new Item(1304, "Kompresiki 9x9 cm", 0.90M, 3, 10));
        }    

        private static void PopulateEmployees()
        {
            Employees.Add(new Employee(1, "Janek", 100, FlavorText.combinedMaleText));
            Employees.Add(new Employee(2, "MP", 10, FlavorText.combinedMaleText));
            Employees.Add(new Employee(3, "Mała Mi", 30, FlavorText.combinedFemaleText));
        }

        private static void PopulatePatients()
        {
            Patients.Add(new Patient(1, "Babcia Marianna", 10, FlavorText.AggroTexts));
            Patients.Add(new Patient(2, "Jego Eminencja", 10, new string[] { "robi Sodomę i Gomorę", "grozi ekskomuniką" }));
            Patients.Add(new Patient(3, "Wujek Włodek", 10, FlavorText.AggroTexts));
            Patients.Add(new Patient(4, "Neo z Matrixa", 10, new string[] { "wygina zdalnie łyżki w socjalu" }));
            Patients.Add(new Patient(5, "Buka", 10, new string[] { "stoi i się patrzy" }));
            Patients.Add(new Patient(6, "Sasha Grey", 10, FlavorText.AggroTexts));
            Patients.Add(new Patient(7, "Bolec", 10, new string[] { "giba się jak pier... rezus" }));
            Patients.Add(new Patient(8, "Generał Italia", 10, FlavorText.AggroTexts));
            Patients.Add(new Patient(9, "Kapitan Bomba", 10, FlavorText.AggroTexts));
            Patients.Add(new Patient(10, "John Yossarian", 10, FlavorText.AggroTexts));
            Patients.Add(new Patient(11, "Major Major", 10, FlavorText.AggroTexts));
            Patients.Add(new Patient(12, "Morfeusz", 10, FlavorText.AggroTexts));
            Patients.Add(new Patient(13, "Genowefa Pigwa", 10, FlavorText.AggroTexts));
            Patients.Add(new Patient(14, "Bendżamin Fluor", 10, FlavorText.AggroTexts));
            Patients.Add(new Patient(15, "Pan Tymol Mentol", 10, FlavorText.AggroTexts));
            Patients.Add(new Patient(16, "Profesór Doktór Wiktór", 10, FlavorText.AggroTexts));
        }

        public static Item ItemByID(int id)
        {
            foreach(Item item in Items)
            {
                if(item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Employee EmployeeByID(int id)
        {
            foreach (Employee employee in Employees)
            {
                if (employee.ID == id)
                {
                    return employee;
                }
            }

            return null;
        }
    }
}
