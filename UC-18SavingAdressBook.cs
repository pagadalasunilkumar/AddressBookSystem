using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AddressBookSystem
{
    interface IAddressBookStorage
    {
        void SaveContacts(List<Contact> contacts);
        List<Contact> LoadContacts();
    }

    class CsvAddressBookStorage : IAddressBookStorage
    {
        private string filePath;

        public CsvAddressBookStorage(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveContacts(List<Contact> contacts)
        {
            // CSV file saving logic
            // ...
            Console.WriteLine("Contacts saved to CSV file.");
        }

        public List<Contact> LoadContacts()
        {
            // CSV file loading logic
            // ...
            Console.WriteLine("Contacts loaded from CSV file.");
            return new List<Contact>();
        }
    }

    class JsonAddressBookStorage : IAddressBookStorage
    {
        private string filePath;

        public JsonAddressBookStorage(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveContacts(List<Contact> contacts)
        {
            // JSON file saving logic
            // ...
            Console.WriteLine("Contacts saved to JSON file.");
        }

        public List<Contact> LoadContacts()
        {
            // JSON file loading logic
            // ...
            Console.WriteLine("Contacts loaded from JSON file.");
            return new List<Contact>();
        }
    }

    class DatabaseAddressBookStorage : IAddressBookStorage
    {
        private string connectionString;

        public DatabaseAddressBookStorage(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void SaveContacts(List<Contact> contacts)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Clear existing data
                SqlCommand clearCommand = new SqlCommand("DELETE FROM Contacts", connection);
                clearCommand.ExecuteNonQuery();

                // Insert new data
                foreach (var contact in contacts)
                {
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO Contacts (FirstName, LastName, Address, City, State, Zip, PhoneNumber, Email) " +
                                                              "VALUES (@FirstName, @LastName, @Address, @City, @State, @Zip, @PhoneNumber, @Email)", connection);
                    insertCommand.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    insertCommand.Parameters.AddWithValue("@LastName", contact.LastName);
                    insertCommand.Parameters.AddWithValue("@Address", contact.Address);
                    insertCommand.Parameters.AddWithValue("@City", contact.City);
                    insertCommand.Parameters.AddWithValue("@State", contact.State);
                    insertCommand.Parameters.AddWithValue("@Zip", contact.Zip);
                    insertCommand.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                    insertCommand.Parameters.AddWithValue("@Email", contact.Email);
                    insertCommand.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Contacts saved to the database.");
        }

        public List<Contact> LoadContacts()
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM Contacts", connection);
                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    string firstName = reader.GetString(0);
                    string lastName = reader.GetString(1);
                    string address = reader.GetString(2);
                    string city = reader.GetString(3);
                    string state = reader.GetString(4);
                    string zip = reader.GetString(5);
                    string phoneNumber = reader.GetString(6);
                    string email = reader.GetString(7);

                    Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                    contacts.Add(contact);
                }

                reader.Close();
            }

            Console.WriteLine("Contacts loaded from the database.");
            return contacts;
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

    class AddressBook
    {
        private List<Contact> contacts;
        private IAddressBookStorage storage;

        public AddressBook(IAddressBookStorage storage)
        {
            this.storage = storage;
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void SaveContacts()
        {
            storage.SaveContacts(contacts);
        }

        public void LoadContacts()
        {
            contacts = storage.LoadContacts();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string csvFilePath = "contacts.csv";
            string jsonFilePath = "contacts.json";
            string databaseConnectionString = "your_database_connection_string";

            AddressBook addressBook = new AddressBook(new DatabaseAddressBookStorage(databaseConnectionString));

            // Add contacts to the address book
            addressBook.AddContact(new Contact("John", "Doe", "123 Main St", "New York", "New York", "12345", "123-456-7890", "john@example.com"));
            addressBook.AddContact(new Contact("Jane", "Smith", "456 Elm St", "New York", "New York", "12345", "123-456-7890", "jane@example.com"));

            // Save contacts to the database
            addressBook.SaveContacts();

            // Load contacts from the database
            addressBook.LoadContacts();

            Console.ReadLine();
        }
    }
}
