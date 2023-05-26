using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class UC_3EditContacts
    {
        public class AddressBook
        {
            private List<Contact> contacts;

            public AddressBook()
            {
                contacts = new List<Contact>();
            }

            public void AddContact(Contact contact)
            {
                contacts.Add(contact);
                Console.WriteLine("Contact added successfully.");
            }

            public void DisplayContacts()
            {
                Console.WriteLine("Contacts:");
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }

            public void EditContact(string firstName, string lastName)
            {
                Contact contact = FindContactByName(firstName, lastName);

                if (contact != null)
                {
                    Console.WriteLine("Enter the new details for the contact:");
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

                    // Update the contact details
                    contact.Address = address;
                    contact.City = city;
                    contact.State = state;
                    contact.Zip = zip;
                    contact.PhoneNumber = phoneNumber;
                    contact.Email = email;

                    Console.WriteLine("Contact updated successfully.");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }

            private Contact FindContactByName(string firstName, string lastName)
            {
                return contacts.Find(c => c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) && c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
