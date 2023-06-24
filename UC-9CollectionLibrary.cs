using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class UC_9CollectionLibrary
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

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
        private Dictionary<string, List<Person>> peopleByCity;
        private Dictionary<string, List<Person>> peopleByState;

        public AddressBook()
        {
            people = new List<Person>();
            peopleByCity = new Dictionary<string, List<Person>>();
            peopleByState = new Dictionary<string, List<Person>>();
        }

        public bool AddPerson(Person person)
        {
            if (people.Contains(person))
            {
                Console.WriteLine("Duplicate entry found. Person with the same name already exists.");
                return false;
            }

            people.Add(person);
            AddPersonToDictionary(peopleByCity, person.City, person);
            AddPersonToDictionary(peopleByState, person.State, person);

            Console.WriteLine("Person added to the address book.");
            return true;
        }

        private void AddPersonToDictionary(Dictionary<string, List<Person>> dictionary, string key, Person person)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key].Add(person);
            }
            else
            {
                dictionary[key] = new List<Person> { person };
            }
        }

        public List<Person> GetPeopleByCity(string city)
        {
            if (peopleByCity.ContainsKey(city))
            {
                return peopleByCity[city];
            }

            return new List<Person>();
        }

        public List<Person> GetPeopleByState(string state)
        {
            if (peopleByState.ContainsKey(state))
            {
                return peopleByState[state];
            }

            return new List<Person>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an address book
            AddressBook addressBook = new AddressBook();

            // Add people to the address book
            addressBook.AddPerson(new Person { Name = "John Doe", Address = "123 Main St", City = "New York", State = "New York" });
            addressBook.AddPerson(new Person { Name = "Jane Smith", Address = "456 Elm St", City = "New York", State = "New York" });
            addressBook.AddPerson(new Person { Name = "David Johnson", Address = "789 Oak St", City = "Los Angeles", State = "California" });

            // View people by city
            string cityToView = "New York";
            List<Person> peopleInCity = addressBook.GetPeopleByCity(cityToView);
            Console.WriteLine($"People in {cityToView}:");
            foreach (Person person in peopleInCity)
            {
                Console.WriteLine($"{person.Name}, {person.Address}");
            }

            // View people by state
            string stateToView = "California";
            List<Person> peopleInState = addressBook.GetPeopleByState(stateToView);
            Console.WriteLine($"People in {stateToView}:");
            foreach (Person person in peopleInState)
            {
                Console.WriteLine($"{person.Name}, {person.Address}");
            }

            Console.ReadLine();
        }

    }
}
