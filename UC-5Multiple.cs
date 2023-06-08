using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class UC_5Multiple
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> addressBook = new Dictionary<string, string>();

            while (true)
            {
                Console.WriteLine("Enter person's name (or 'quit' to exit):");
                string name = Console.ReadLine();

                if (name.ToLower() == "quit")
                {
                    break;
                }

                Console.WriteLine("Enter person's phone number:");
                string phoneNumber = Console.ReadLine();

                addressBook[name] = phoneNumber;

                Console.WriteLine("Person added to address book.");
            }

            Console.WriteLine("\nAddress Book:");
            foreach (var person in addressBook)
            {
                Console.WriteLine($"Name: {person.Key}, Phone Number: {person.Value}");
            }
        }
    }
}
