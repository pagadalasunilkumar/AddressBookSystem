using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class AddingNewContact
    {
        internal class AddressBookMain
        {
            public static void Main()
            {
                Console.WriteLine("Welcome to Address Book Program");

                AddressBook addressBook = new AddressBook();

                // Create contacts
                Contact contact1 = new Contact("John", "Doe", "123 Main St", "City", "State", "12345", "1234567890", "john@example.com");
                Contact contact2 = new Contact("Jane", "Smith", "456 Elm St", "City", "State", "67890", "9876543210", "jane@example.com");

                // Add contacts to address book
                addressBook.AddContact(contact1);
                addressBook.AddContact(contact2);

                // Display the contacts
                addressBook.DisplayContacts();

                // Add a new contact
                Console.WriteLine("Enter the details of the new contact:");
                Console.Write("First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();
                Console.Write("Address: ");
                string address = Console.ReadLine();
                Console.Write("City: ");
                string city = Console.ReadLine();
                Console.Write("State: ");
                string state = Console.ReadLine();
                Console.Write("Zip: ");
                string zip = Console.ReadLine();
                Console.Write("Phone Number: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();

                Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                addressBook.AddContact(newContact);

                // Display the updated contacts
                addressBook.DisplayContacts();

                // TODO: Implement the rest of the Address Book functionality
            }
        }
    }
}
