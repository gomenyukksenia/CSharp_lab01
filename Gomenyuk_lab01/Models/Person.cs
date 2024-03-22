using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.CSharp2024.Gomenyuk_lab01.Models
{
    class Person
    {
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private BirthDate _birthDate;
        private bool _isAdult = false;
        private bool _isBirthdayToday = false;
        private ChineseZodiac _chineseSign;
        private WesternZodiac _sunSign;

        public Person(string firstName, string lastName, string emailAddress, DateTime birthDate)
        {
            _firstName = firstName;
            _lastName = lastName;
            _emailAddress = emailAddress;
            _birthDate = new BirthDate(birthDate);

            _isAdult = _birthDate.Age >= 18;
            _isBirthdayToday = _birthDate.IsBirthdayToday;

            _chineseSign = _birthDate.chineseZodiac;
            _sunSign = _birthDate.westZodiac;
        }

        public Person(string firstName, string lastName, string emailAddress)
            : this(firstName, lastName, emailAddress, DateTime.MinValue) { }

        public Person(string firstName, string lastName, DateTime birthDate)
            : this(firstName, lastName, string.Empty, birthDate) { }

        public string FirstName
        {
            get 
            { 
                return _firstName;
            }
        }

        public string LastName
        { 
            get 
            { 
                return _lastName; 
            } 
        }

        public string EmailAddress
        { 
            get 
            {
                return _emailAddress;
            } 
        }

        public BirthDate BirthDate
        {
            get
            {
                return _birthDate;
            }
        }

        public bool IsAdult
        {
            get 
            { 
                return _isAdult;
            }
        }

        public WesternZodiac SunSign
        {
            get
            {
                return _sunSign;
            }
        }

        public ChineseZodiac ChineseSign
        {
            get
            {
                return _chineseSign;
            }
        }

        public bool IsBirthday
        {
            get 
            { 
                return _isBirthdayToday; 
            }
        }
    }
}
