using System;

namespace AddressBookSystem
{
    public class UC_1CreatingContacts
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Address Book Program");

            // TODO: Implement the Address Book functionality

            // Create contacts
            Contact contact1 = new("John", "Doe", "123 Main St", "City", "State", "12345", "1234567890", "john@example.com");
            Contact contact2 = new("Jane", "Smith", "456 Elm St", "City", "State", "67890", "9876543210", "jane@example.com");

            // Display the contacts
            Console.WriteLine("Contacts:");
            Console.WriteLine(contact1);
            Console.WriteLine(contact2);

            // TODO: Implement the rest of the Address Book functionality
        }
    }

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
            return $"Name: {FirstName} {LastName}\nAddress: {Address}\nCity: {City}\nState: {State}\nZip: {Zip}\nPhone: {PhoneNumber}\nEmail: {Email}";
        }
    }
}
