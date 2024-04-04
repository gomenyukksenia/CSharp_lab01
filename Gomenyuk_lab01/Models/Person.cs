using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.CSharp2024.Gomenyuk_lab01.Models
{
    [Serializable]
    class Person
    {
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private string _emailDomain;
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
            int aIndex = _emailAddress.IndexOf("@");
            _emailDomain = _emailAddress.Substring(aIndex + 1);
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
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        { 
            get 
            { 
                return _lastName; 
            } 
            set 
            {
                _lastName = value;
            }
        }

        public string EmailAddress
        { 
            get 
            {
                return _emailAddress;
            } 
            set 
            { 
                _emailAddress = value;
            }
        }

        public string EmailDomain
        {
            get
            {
                return _emailDomain;
            }
            set
            {
                _emailDomain = value;
            }
        }


        public BirthDate BirthDate
        {
            get
            {
                return _birthDate;
            }
            set 
            { 
                _birthDate = value;
            }
        }

        public bool IsAdult
        {
            get 
            { 
                return _isAdult;
            }
            set
            {
                _isAdult = value;
            }
        }
        public string AgeDescription
        {
            get
            {
                if (BirthDate.Age < 0)
                {
                    return "You don`t exsist yet, too young!";
                }
                else if (BirthDate.Age > 135)
                {
                    return "You don`t exsist, too old!";
                }

                return IsAdult ? "Adult" : "Child yet";
            }
        }


        public WesternZodiac SunSign
        {
            get
            {
                return _sunSign;
            }
            set
            {
                _sunSign = value;
            }
        }

        public ChineseZodiac ChineseSign
        {
            get
            {
                return _chineseSign;
            }
            set
            {
                _chineseSign = value;
            }
        }

        public bool IsBirthday
        {
            get 
            { 
                return _isBirthdayToday; 
            }
            set
            {
                _isBirthdayToday = value;
            }
        }
    }
}
