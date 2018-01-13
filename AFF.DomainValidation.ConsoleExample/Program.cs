using System;
using AFF.DomainValidation.ConsoleExample.Entity;
using AFF.DomainValidation.ConsoleExample.Service;

namespace AFF.DomainValidation.ConsoleExample
{
    class Program
    {
        private const int MENU_EXIT = 9;
        private static ServicePerson _ServicePerson;

        static void Main(string[] args)
        {
            Console.Title = "AFF.DomainValidation";

            _ServicePerson = new ServicePerson();

            Menu();
        }

        private static void Menu()
        {
            int menuOption = 0;

            while (menuOption != MENU_EXIT)
            {
                Console.Clear();
                Console.WriteLine(" MENU");
                Console.WriteLine(" Change a option:");
                Console.WriteLine(" 1 - Create a Person.");
                Console.WriteLine(" 9 - Exit.");
                Console.Write(" Option: ");
                menuOption = GetInt32();
                if (menuOption == 1)
                    CreatePerson();
                else if (menuOption == 9)
                    break;
            }
        }

        private static void CreatePerson()
        {
            Console.Clear();
            Console.WriteLine(" CREATE PERSON.");
            Console.Write(" Cod: ");
            var cod = GetInt32();
            Console.Write(" Name: ");
            var name = Console.ReadLine();
            Console.Write(" Age: ");
            var age = GetInt32();

            var person = new Person()
            {
                Cod = cod,
                Name = name,
                Age = age
            };

            _ServicePerson.Add(person);

            Console.WriteLine("Press a key to continue.");
            Console.Read();
        }

        private static int GetInt32(int _default = 0)
        {
            var read = Console.ReadLine();
            try
            {
                return Convert.ToInt32(read);
            }
            catch
            {

                return _default;
            }
        }
    }
}
