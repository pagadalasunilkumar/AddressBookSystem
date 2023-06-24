using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class UC_13UsingFileIO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Address: {Address}, City: {City}, State: {State}";
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

        public void PrintEntries()
        {
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Person person in people)
                {
                    writer.WriteLine(person.Name);
                    writer.WriteLine(person.Address);
                    writer.WriteLine(person.City);
                    writer.WriteLine(person.State);
                    writer.WriteLine();
                }
            }

            Console.WriteLine("Address book saved to file.");
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            people.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                string name = null;
                string address = null;
                string city = null;
                string state = null;

                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (name != null && address != null && city != null && state != null)
                        {
                            Person person = new Person
                            {
                                Name = name,
                                Address = address,
                                City = city,
                                State = state
                            };

                            people.Add(person);
                        }

                        name = address = city = state = null;
                    }
                    else if (name == null)
                    {
                        name = line;
                    }
                    else if (address == null)
                    {
                        address = line;
                    }
                    else if (city == null)
                    {
                        city = line;
                    }
                    else if (state == null)
                    {
                        state = line;
                    }
                }

                if (name != null && address != null && city != null && state != null)
                {
                    Person person = new Person
                    {
                        Name = name,
                        Address = address,
                        City = city,
                        State = state
                    };

                    people.Add(person);
                }
            }

            Console.WriteLine("Address book loaded from file.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();

            // Add people to the address book
            addressBook.AddPerson(new Person { Name = "John Doe", Address = "123 Main St", City = "New York", State = "New York" });
            addressBook.AddPerson(new Person { Name = "Jane Smith", Address = "456 Elm St", City = "Los Angeles", State = "California" });
            addressBook.AddPerson(new Person
            {
                Name = "David Johnson",
                Address = "789 Oak St",
            }


        }