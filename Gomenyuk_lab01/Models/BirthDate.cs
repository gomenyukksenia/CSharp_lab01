using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KMA.CSharp2024.Gomenyuk_lab01.Models
{
    enum ChineseZodiac
    {
        Monkey = 0,
        Rooster,
        Dog,
        Pig,
        Rat,
        Ox,
        Tiger,
        Rabbit,
        Dragon,
        Snake,
        Horse,
        Sheep
    }
    enum WesternZodiac
    {
        Aquarius = 1,
        Pisces,
        Aries,
        Taurus,
        Gemini,
        Cancer,
        Leo,
        Virgo,
        Libra,
        Scorpio,
        Sagittarius,
        Capricorn
    }

    internal class BirthDate
    {
        private DateTime _birthDate;

        public BirthDate(DateTime birthDate)
        {
            _birthDate = birthDate;
    }

        public DateTime BDdate 
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

        public int Age
        {
            get 
            {
                var age = DateTime.Now.Year - _birthDate.Year;

                if (_birthDate > DateTime.Now.AddYears(-age))
                {
                    age -= 1;
                }
                return age;
            }
        }

        public string DetailedAge
        {
            get
            {
                var age = Age;
                if(age < 0)
                {
                    return "You are lucky. You haven`t been born!";
                }

                var lastBirthday = new DateTime(DateTime.Now.Year, _birthDate.Month, _birthDate.Day);
                var days = (DateTime.Now - lastBirthday).Days;

                var months = 0;
                if (DateTime.Now.Month > _birthDate.Month || (DateTime.Now.Month == _birthDate.Month && DateTime.Now.Day >= _birthDate.Day))
                {
                    months += DateTime.Now.Month - _birthDate.Month;
                }
                else
                {
                    months += DateTime.Now.Month - _birthDate.Month - 1;
                }
                return $"{age} years; {months} months; {days} days";
            }
        }

        public bool IsBirthdayToday
        {
            get
            {
                return (_birthDate.Day == DateTime.Now.Day && _birthDate.Month == DateTime.Now.Month);
            }
        }

       public ChineseZodiac chineseZodiac
        { 
            get 
            {
                return (ChineseZodiac)(_birthDate.Year % 12);
            }
        }

        public WesternZodiac westZodiac
        {
            get
            {
                int day = _birthDate.Day;
                int month = _birthDate.Month;
                WesternZodiac zodiac = WesternZodiac.Aquarius;

                switch (month)
                {
                    case 1:
                        zodiac = day < 20 ? WesternZodiac.Capricorn : WesternZodiac.Aquarius;
                        break;
                    case 2:
                        zodiac = day < 20 ? WesternZodiac.Aquarius : WesternZodiac.Pisces;
                        break;
                    case 3:
                        zodiac = day < 22 ? WesternZodiac.Pisces : WesternZodiac.Aries;
                        break;
                    case 4:
                        zodiac = day < 22 ? WesternZodiac.Aries : WesternZodiac.Taurus;
                        break;
                    case 5:
                        zodiac = day < 22 ? WesternZodiac.Taurus : WesternZodiac.Gemini;
                        break;
                    case 6:
                        zodiac = day < 22 ? WesternZodiac.Gemini : WesternZodiac.Cancer;
                        break;
                    case 7:
                        zodiac = day < 23 ? WesternZodiac.Cancer : WesternZodiac.Leo;
                        break;
                    case 8:
                        zodiac = day < 23 ? WesternZodiac.Leo : WesternZodiac.Virgo;
                        break;
                    case 9:
                        zodiac = day < 23 ? WesternZodiac.Virgo : WesternZodiac.Libra;
                        break;
                    case 10:
                        zodiac = day < 23 ? WesternZodiac.Libra : WesternZodiac.Scorpio;
                        break;
                    case 11:
                        zodiac = day < 22 ? WesternZodiac.Scorpio : WesternZodiac.Sagittarius;
                        break;
                    case 12:
                        zodiac = day < 22 ? WesternZodiac.Sagittarius : WesternZodiac.Capricorn;
                        break;
                }
                return zodiac;
            }
        }
    }
}
