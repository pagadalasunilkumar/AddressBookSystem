using System;
using static AddressBookSystem.UC_3EditContacts;

namespace AddressBookSystem
{
    internal class UC_4DeleteContacts
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

            // Edit an existing contact
            Console.WriteLine("Enter the name of the contact to edit:");
            Console.Write("First Name: ");
            string editFirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string editLastName = Console.ReadLine();

            addressBook.EditContact(editFirstName, editLastName);

            // Display the updated contacts
            addressBook.DisplayContacts();

            // Delete a contact
            Console.WriteLine("Enter the name of the contact to delete:");
            Console.Write("First Name: ");
            string deleteFirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string deleteLastName = Console.ReadLine();

            addressBook.DeleteContact(deleteFirstName, deleteLastName);

            // Display the updated contacts
            addressBook.DisplayContacts();

            // TODO: Implement the rest of the Address Book functionality
        }
    }
}
