using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace AddressBookSystem
{
    class UC_16JsonRestAssured
    {
        public class Contact
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

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");

            List<Contact> contacts = new List<Contact>
            {
                new Contact("John", "Doe", "123 Main St", "New York", "New York", "12345", "1234567890", "john@example.com"),
                new Contact("Jane", "Smith", "456 Elm St", "New York", "New York", "67890", "9876543210", "jane@example.com")
            };

            // Save contacts to JSON server
            SaveContactsToJSONServer(contacts);
            Console.WriteLine("Contacts have been saved to the JSON server.");

            // Read contacts from JSON server
            List<Contact> loadedContacts = LoadContactsFromJSONServer();
            Console.WriteLine("Contacts have been loaded from the JSON server:");
            foreach (Contact contact in loadedContacts)
            {
                Console.WriteLine(contact);
            }
        }

        public static void SaveContactsToJSONServer(List<Contact> contacts)
        {
            var client = new RestClient("http://localhost:3000/contacts");

            foreach (Contact contact in contacts)
            {
                var request = new RestRequest(Method.POST);
                request.AddJsonBody(contact);
                client.Execute(request);
            }
        }

        public static List<Contact> LoadContactsFromJSONServer()
        {
            var client = new RestClient("http://localhost:3000/contacts");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
                return contacts;
            }
            else
            {
                throw new Exception("Failed to load contacts from the JSON server.");
            }
        }
    }
}
