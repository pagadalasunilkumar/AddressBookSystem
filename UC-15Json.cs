using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace AddressBookSystem
{
    class UC-15Json

    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");

            AddressBook addressBook = new AddressBook();

            // Add contacts to address book
            addressBook.AddContact(new Contact("John", "Doe", "123 Main St", "New York", "New York", "12345", "1234567890", "john@example.com"));
            addressBook.AddContact(new Contact("Jane", "Smith", "456 Elm St", "New York", "New York", "67890", "9876543210", "jane@example.com"));

            // Save address book to JSON file
            string jsonFilePath = "addressbook.json";
            addressBook.SaveToJson(jsonFilePath);
            Console.WriteLine("Address book has been saved to the JSON file.");

            // Read address book from JSON file
            AddressBook loadedAddressBook = AddressBook.LoadFromJson(jsonFilePath);
            Console.WriteLine("Address book has been loaded from the JSON file:");
            loadedAddressBook.DisplayContacts();
        }
    }

    class AddressBook
    {
        private List<Contact> contacts;

        public AddressBook()
        {
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void SaveToJson(string filePath)
        {
            string json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static AddressBook LoadFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
            AddressBook addressBook = new AddressBook();
            addressBook.contacts.AddRange(contacts);
            return addressBook;
        }

        public void DisplayContacts()
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
    }

    class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Address: {Address}, City: {City}, State: {State}, Zip: {Zip}, Phone: {PhoneNumber}, Email: {Email}";
        }
    }
}
