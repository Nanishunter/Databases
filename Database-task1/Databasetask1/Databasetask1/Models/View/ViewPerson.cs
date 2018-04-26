using System;
using System.Collections.Generic;
using System.Text;

namespace Databasetask1.Models.Repositories
{
    class ViewPerson
    {
        /// <summary>
        /// Print data to screen from list
        /// </summary>
        /// <param name="persons"></param>
        public static void PrintToScreen(List<Person> persons)
        {
            Console.WriteLine("Id, Name, Age\n" +
                              "-------------------\n");
            foreach (var p in persons)
            {
                Console.WriteLine(p.ShowData());
            }
        }

        /// <summary>
        /// Print only one record 
        /// </summary>
        /// <param name="person"></param>
        public static void PrintToScreen(Person person)
        {
            Console.WriteLine($"{person.Name}, {person.Age}");
            if (person.Phone.Count == 0)
                Console.WriteLine("Ei puhelinta!");
            foreach (var phnPhone in person.Phone)
            {
                Console.WriteLine($"\n   {phnPhone.ToString()}");
            }
            Console.WriteLine("\n-------------\n");
        }
        public static void AddPerson()
        {
            PersonRepository personRepository = new PersonRepository();
            Console.Write("Type name: ");
            string name = Console.ReadLine();
            Console.Write("Type age: ");
            short age = short.Parse(Console.ReadLine());

            List<Phone> phones = new List<Phone>();
            string addAnother = "Y";
            Console.WriteLine("Add phones");
            do
            {

                Console.Write("Write phonetype: ");
                string type = Console.ReadLine();
                Console.Write("Write phonenumber: ");
                string phone = Console.ReadLine();

                var addPhone = new Phone(type, phone);

                Console.Write("Add an other phone Y/N?: ");
                addAnother = Console.ReadLine();

            } while (addAnother.ToUpper() != "N");

            var addPerson = new Person(name, age, phones);
            personRepository.Create(addPerson);
        }
    }
}
