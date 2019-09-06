using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using AFF.DomainValidation.ConsoleExample.Entity;
using AFF.DomainValidation.ConsoleExample.Services;
using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.ConsoleExample
{
    class Program
    {
        private const int MENU_EXIT = 9;
        private static ServicePerson _ServicePerson;

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
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
                Console.WriteLine(" 1 - Person");
                Console.WriteLine(" 9 - Exit");
                Console.Write(" Option: ");
                menuOption = GetInt32(0).Value;
                if (menuOption == 1)
                    MenuPerson();
                else if (menuOption == 9)
                    break;
            }
        }

        private static void MenuPerson()
        {
            int menuOption = 0;

            while (menuOption != MENU_EXIT)
            {
                Console.Clear();
                Console.WriteLine(" Person");
                Console.WriteLine(" Change a action:");
                Console.WriteLine(" 1 - Create");
                Console.WriteLine(" 2 - List");
                Console.WriteLine(" 8 - Back");
                Console.WriteLine(" 9 - Exit");
                Console.Write(" Option: ");
                menuOption = GetInt32(0).Value;
                if (menuOption == 1)
                    CreatePerson();
                if (menuOption == 2)
                    ListPerson();
                else if (menuOption == 8)
                    Menu();
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
            Console.Write(" CPF: ");
            var cpf = Console.ReadLine();

            var person = new Person()
            {
                Cod = cod,
                Name = name,
                Age = age,
                Cpf = cpf
            };

            var response = _ServicePerson.Add(person);

            DisplayMessage(response);

            Console.WriteLine("Press a key to continue.");
            Console.Read();
        }

        private static void ListPerson()
        {
            Console.Clear();
            Console.WriteLine(" PERSON.");

            var list = _ServicePerson.Get();
            if (list.Any())
            {
                foreach (var item in list)
                    Console.WriteLine(string.Format("Cod: {0} - Name: {1} - Age: {2}.", item.Cod, item.Name, item.Age)); 
            }
            else
                Console.WriteLine("Empty");

            Console.WriteLine("Press a key to continue.");
            Console.Read();
        }

        private static int? GetInt32(int? _default = null)
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

        private static void DisplayMessage(ValidationResponse response)
        {
            ConfigMessage(response.Status, response.Message);

            foreach (var item in response.ItensError)
                ConfigMessage(item.Status, item.Message);

            foreach (var item in response.ItensWarning)
                ConfigMessage(item.Status, item.Message);

            foreach (var item in response.ItensAlert)
                ConfigMessage(item.Status, item.Message);

            foreach (var item in response.ItensInfo)
                ConfigMessage(item.Status, item.Message);

            Console.ResetColor();
        }

        private static void ConfigMessage(EStatus status, string message)
        {
            switch (status)
            {
                case EStatus.SUCCESS:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case EStatus.INFO:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case EStatus.ALERT:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case EStatus.WARNING:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case EStatus.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.WriteLine(message);
        }
    }
}
