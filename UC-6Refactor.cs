using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AddressBookSystem.UC_3EditContacts;

namespace AddressBookSystem
{
    internal class UC_6Refactor
    {
        private Dictionary<string, string> contacts;

        public AddressBook()
        {
            contacts = new Dictionary<string, string>();
        }

        public void AddContact(string name, string phoneNumber)
        {
            contacts[name] = phoneNumber;
        }

        public void PrintContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found in the address book.");
            }
            else
            {
                foreach (var person in contacts)
                {
                    Console.WriteLine($"Name: {person.Key}, Phone Number: {person.Value}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, AddressBook> addressBooks = new Dictionary<string, AddressBook>();

            while (true)
            {
                Console.WriteLine("Enter address book name (or 'quit' to exit):");
                string bookName = Console.ReadLine();

                if (bookName.ToLower() == "quit")
                {
                    break;
                }

                if (addressBooks.ContainsKey(bookName))
                {
                    Console.WriteLine("An address book with that name already exists. Please choose a different name.");
                    continue;
                }

                AddressBook addressBook = new AddressBook();

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

                    addressBook.AddContact(name, phoneNumber);

                    Console.WriteLine("Person added to address book.");
                }

                addressBooks[bookName] = addressBook;
                Console.WriteLine("Address book added to the system.");
            }

            Console.WriteLine("\nAddress Books:");
            foreach (var book in addressBooks)
            {
                Console.WriteLine($"Address Book: {book.Key}");
                book.Value.PrintContacts();
                Console.WriteLine();
            }
        }
    }
}
