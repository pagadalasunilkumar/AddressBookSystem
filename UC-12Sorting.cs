using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class UC_12Sorting
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Address: {Address}, City: {City}, State: {State}, Zip: {Zip}";
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

        public void SortEntriesByCity()
        {
            people.Sort((p1, p2) => p1.City.CompareTo(p2.City));
        }

        public void SortEntriesByState()
        {
            people.Sort((p1, p2) => p1.State.CompareTo(p2.State));
        }

        public void SortEntriesByZip()
        {
            people.Sort((p1, p2) => p1.Zip.CompareTo(p2.Zip));
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

            addressBook.AddPerson(new Person { Name = "John Doe", Address = "123 Main St", City = "New York", State = "New York", Zip = "10001" });
            addressBook.AddPerson(new Person { Name = "Jane Smith", Address = "456 Elm St", City = "Los Angeles", State = "California", Zip = "90001" });
            addressBook.AddPerson(new Person { Name = "David Johnson", Address = "789 Oak St", City = "Chicago", State = "Illinois", Zip = "60601" });

            Console.WriteLine("Before sorting:");
            addressBook.PrintEntries();

            Console.WriteLine("After sorting by name:");
            addressBook.SortEntriesByName();
            addressBook.PrintEntries();

            Console.WriteLine("After sorting by city:");
            addressBook.SortEntriesByCity();
            addressBook.PrintEntries();

            Console.WriteLine("After sorting by state:");
            addressBook.SortEntriesByState();
            addressBook.PrintEntries();

            Console.WriteLine("After sorting by zip:");
            addressBook.SortEntriesByZip();
            addressBook.PrintEntries();

            Console.ReadLine();
        }
    }
}

    }
}
