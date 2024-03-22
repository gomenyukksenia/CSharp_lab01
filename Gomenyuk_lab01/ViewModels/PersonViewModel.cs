using KMA.CSharp2024.Gomenyuk_lab01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KMA.CSharp2024.Gomenyuk_lab01.ViewModels
{
    class PersonViewModel
    {
        private Person _person;

        public PersonViewModel(string firstName, string lastName, string emailAddress, DateTime birthDate)
        {
            _person = new Person(firstName, lastName, emailAddress, birthDate);
            
            ValidatePerson(_person);
        }

        public string Name 
        {
            get
            {
                return _person.FirstName + " " + _person.LastName;
            }
        }

        public string EmailAddress
        { 
            get 
            { 
                return _person.EmailAddress;
            } 
        }

        public DateTime DateTime
        {
            get
            {
                return _person.BirthDate.BDdate;
            }
        }

        public string AgeDescription
        {
            get
            {
                if (_person.BirthDate.Age < 0)
                {
                    return "You don`t exsist yet, too young!";
                }
                else if (_person.BirthDate.Age > 135)
                {
                    return "You don`t exsist, too old!";
                }

                return _person.IsAdult ? "Adult" : "Child yet";
            }
        }

        public string chineseSignName
        {
            get
            {
                return BirthDate.ChinesZodiacName(_person.ChineseSign);
            }
        }

        public string sunSignName
        {
            get
            {
                return BirthDate.WesternZodiacName(_person.SunSign);
            }
        }

        public string IsBirthdayToday
        {
            get
            {
                return _person.IsBirthday ? "You survived another year! Happy birthday!" : "Just another day";
            }
        }

        public static bool isNameValid(string name) { return name.Length > 0; }
        public static bool isEmailValid(string email)
        { 
            return email.Length > 3 && email.Contains('@');
        } // a@b

        private static bool ValidatePerson(Person p)
        {
            // Validate first name 
            if (Regex.Match(p.FirstName, @"[^a-zA-Z]").Success)
            {
                throw new WrongNameException("Your first name must contain letters only");
            }

            // Validate last name 
            if (Regex.Match(p.LastName, @"[^a-zA-Z]").Success)
            {
                throw new WrongNameException("Your last name must contain letters only");
            }

            // Validate age
            if (p.BirthDate.Age < 0)
            {
                throw new ArgumentOutOfRangeException("You don`t exsist yet, too young!");
            }
            else if(p.BirthDate.Age > 135)
            {
                throw new ArgumentOutOfRangeException("You don`t exsist, too old!");
            }

            // Validate email 
            if (!p.EmailAddress.Contains("@"))
            {
                throw new WrongEmailException("Your email is invalid: missing @");
            }
            else if (!p.EmailAddress.Contains("."))
            {
                throw new WrongEmailException("Your email is invalid: missing .");
            }
            else if(p.EmailAddress.Length < 5)
            {
                throw new WrongEmailException("Your email is too short");
            }

            return true;
        }

    }
}
