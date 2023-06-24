using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }

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
    }

    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();

            Person person1 = new Person { Name = "John Doe", Address = "123 Main St" };
            Person person2 = new Person { Name = "Jane Smith", Address = "456 Elm St" };
            Person person3 = new Person { Name = "John Doe", Address = "789 Oak St" };

            addressBook.AddPerson(person1);
            addressBook.AddPerson(person2);
            addressBook.AddPerson(person3);

            Console.ReadLine();
        }
    }
}
