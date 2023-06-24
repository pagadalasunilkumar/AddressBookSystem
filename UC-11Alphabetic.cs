using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Address: {Address}, City: {City}, State: {State}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Person otherPerson = (Person)obj;
            return Name.Equals(otherPerson.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }

    class AddressBook
    {
        private List<Person> people;

        public AddressBook()
        {
            people = new List<Person>();
        }

        public bool AddPerson(Person person)
        {
            if (people.Contains(person))
            {
                Console.WriteLine("Duplicate entry found. Person with the same name already exists.");
                return false;
            }

            people.Add(person);
            Console.WriteLine("Person added to the address book.");
            return true;
        }

        public void SortEntriesByName()
        {
            people.Sort();
        }

        public void PrintEntries()
        {
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }

    class UC_11Alphabetic
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();

            addressBook.AddPerson(new Person { Name = "John Doe", Address = "123 Main St", City = "New York", State = "New York" });
            addressBook.AddPerson(new Person { Name = "Jane Smith", Address = "456 Elm St", City = "New York", State = "New York" });
            addressBook.AddPerson(new Person { Name = "David Johnson", Address = "789 Oak St", City = "Los Angeles", State = "California" });

            Console.WriteLine("Before sorting:");
            addressBook.PrintEntries();

            Console.WriteLine("After sorting by name:");
            addressBook.SortEntriesByName();
            addressBook.PrintEntries();

            Console.ReadLine();
        }
    }
}
