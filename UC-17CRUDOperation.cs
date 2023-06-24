using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace AddressBookSystem
{
    class UC_17CRUDOperation
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

        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");

            List<Contact> contacts = new List<Contact>
            {
                new Contact("John", "Doe", "123 Main St", "New York", "New York", "12345", "1234567890", "john@example.com"),
                new Contact("Jane", "Smith", "456 Elm St", "New York", "New York", "67890", "9876543210", "jane@example.com")
            };

            // Save contacts to JSON server asynchronously
            await SaveContactsToJSONServerAsync(contacts);
            Console.WriteLine("Contacts have been saved to the JSON server.");

            // Read contacts from JSON server asynchronously
            List<Contact> loadedContacts = await LoadContactsFromJSONServerAsync();
            Console.WriteLine("Contacts have been loaded from the JSON server:");
            foreach (Contact contact in loadedContacts)
            {
                Console.WriteLine(contact);
            }
        }

        public static async Task SaveContactsToJSONServerAsync(List<Contact> contacts)
        {
            var client = new HttpClient();
            var jsonContent = JsonConvert.SerializeObject(contacts);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:3000/contacts", httpContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to save contacts to the JSON server.");
            }
        }

        public static async Task<List<Contact>> LoadContactsFromJSONServerAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:3000/contacts");

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonContent);
                return contacts;
            }
            else
            {
                throw new Exception("Failed to load contacts from the JSON server.");
            }
        }
    }
}
