using System;
using System.Collections.Generic;
using System.Linq;
using KMA.CSharp2024.Gomenyuk_lab01.Models;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace KMA.CSharp2024.Gomenyuk_lab01.ViewModels
{
    internal class PersonDatabase
    {
        private Person[] _personsArray;

        public PersonDatabase()
        {
            if (!File.Exists("people.dat"))
            {
                populateDatabase();
                Serialize();
            }
            else
            {
                Deserialize();
            }
        }
        public ObservableCollection<Person> GetBase()
        {
            return new ObservableCollection<Person>(_personsArray);
        }
        private void populateDatabase()
        {
            _personsArray = new Person[50];
            string[] names = { "John", "Sarah", "Jack", "Ted", "Tom", "Mary" };
            string[] surnames = { "Stevenson", "Lee", "Smith", "Brown", "Walker", "Abrams" };
            string[] domains = { "gmail.com", "ukr.net", "ms.com", "example.com" };

            Random rnd = new Random();

            for (int i = 0; i < 50; i++)
            {
                string name = names[rnd.Next(0, 6)];
                string surname = surnames[rnd.Next(0, 6)];
                string email = name + "." + surname + "@" + domains[rnd.Next(0, 4)];

                DateTime start = new DateTime(1910, 1, 1);
                int range = (DateTime.Today - start).Days;
                DateTime date = start.AddDays(rnd.Next(range));

                _personsArray[i] = new Person(name, surname, email, date);
            }
        }
        private void Serialize()
        {
            FileStream s = new("people.dat", FileMode.Create);
            BinaryFormatter b = new();
#pragma warning disable SYSLIB0011
            b.Serialize(s, _personsArray);
#pragma warning restore SYSLIB0011
            s.Close();
        }

        private void Deserialize()
        {
            FileStream s = new("people.dat", FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
#pragma warning disable SYSLIB0011
            _personsArray = (Person[])b.Deserialize(s);
#pragma warning restore SYSLIB0011
            Console.WriteLine(_personsArray);
            s.Close();
        }

    }
}
