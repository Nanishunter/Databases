using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Databasetask1.Models.Repositories
{
    class Program
    {
        public static object ViewPerson { get; private set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Database CRUD operations");
            UIForConsoleApp();





        }

        public static void UIForConsoleApp()
        {
            ConsoleKeyInfo info;
            PersonRepository personRepository = new PersonRepository();

            do
            {
                Console.Clear();
                Console.WriteLine("Database coding - CRUD");
                Console.WriteLine("Press <ESC> to Exit");
                Console.WriteLine("C) Create");
                Console.WriteLine("R) Read All");
                Console.WriteLine("U) Update");
                Console.WriteLine("D) Delete");
                Console.WriteLine("-------------");
                Console.WriteLine("G) Get by ID");
                Console.WriteLine("A) Update Phone");

                info = Console.ReadKey();

                switch (info.Key)
                {
                    case ConsoleKey.C:
                        ViewPerson.AddPerson();
                        //var person = new Person("Masa", 25);
                        //personRepository.Create(person);
                        break;
                    case ConsoleKey.R:
                        ViewPerson.PrintToScreen(personRepository.Get());
                        Console.WriteLine("Press <Enter> to continue ...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.U:
                        Person updatePerson = personRepository.GetPersonById(10);
                        updatePerson.Name = "Jouni";
                        updatePerson.Age = 50;
                        personRepository.Update(1, updatePerson);
                        break;
                    case ConsoleKey.D:
                        personRepository.Delete(5);
                        break;
                    case ConsoleKey.G:
                        Console.Write("\nSyötä henkilön <id>, jonka tiedot näytetään: ");
                        int id = int.Parse(Console.ReadLine());
                        ViewPerson.PrintToScreen(personRepository.GetPersonByIdAndPhones(id));
                        Console.WriteLine("Press <Enter> to continue ...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.A:
                        Console.Write("\nSyötä henkilön <id>, jonka tiedot näytetään: ");
                        id = int.Parse(Console.ReadLine());
                        Person updatePersonAndPhone = personRepository.GetPersonByIdAndPhones(id);
                        ViewPerson.PrintToScreen(personRepository.GetPersonByIdAndPhones(id));
                        Console.Write("Valitse <Id>, jonka haluat muuttaa: ");
                        int phnId = int.Parse(Console.ReadLine());
                        Console.Write("Syötä uusi numero: ");
                        string newNumber = Console.ReadLine();
                        foreach (var phn in updatePersonAndPhone.Phone)
                        {
                            if (phn.Id == phnId)
                                phn.Number = newNumber;
                        }
                        personRepository.Update(10, updatePersonAndPhone);
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("\nProgram end after 3 sec!");
                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write(".");
                            System.Threading.Thread.Sleep(1000);
                        }
                        break;
                    default:
                        Console.WriteLine("\nWrong KEY - try again!");
                        System.Threading.Thread.Sleep(2000);
                        break;
                }

            } while (info.Key != ConsoleKey.Escape);


        }

    }
}
        }
    }
}
