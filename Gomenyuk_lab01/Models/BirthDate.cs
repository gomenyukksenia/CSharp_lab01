﻿using System;
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
    [Serializable]
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
        public string BDateAsString
        {
            get
            { 
                return _birthDate.ToString("d");
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
                if (age < 0)
                {
                    return "You are lucky. You haven`t been born!";
                }

                var days = 0;
                var months = 0;

                if (DateTime.Now.Month > _birthDate.Month || (DateTime.Now.Month == _birthDate.Month && DateTime.Now.Day >= _birthDate.Day))
                {
                    months = DateTime.Now.Month - _birthDate.Month;
                    DateTime lastBirthday = new DateTime(DateTime.Now.Year, months, _birthDate.Day);
                    days = (DateTime.Now - lastBirthday).Days;
                }
                else
                {
                    months = 12 - _birthDate.Month + DateTime.Now.Month;
                    DateTime lastBirthday = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, _birthDate.Day);
                    days = (DateTime.Now - lastBirthday).Days;
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
        public string westZodiacName
        {
            get
            {
                return WesternZodiacName(westZodiac);
            }
        }

        public string ChZodiacName
        {
            get
            {
                return ChinesZodiacName(chineseZodiac);
            }
        }
        public static string WesternZodiacName(WesternZodiac zd)
        {
            switch (zd)
            {
                case WesternZodiac.Capricorn:
                    return "Capricorn";
                case WesternZodiac.Aquarius:
                    return "Aquarius";
                case WesternZodiac.Pisces:
                    return "Pisces";
                case WesternZodiac.Aries:
                    return "Aries";
                case WesternZodiac.Taurus:
                    return "Taurus";
                case WesternZodiac.Gemini:
                    return "Gemini";
                case WesternZodiac.Cancer:
                    return "Cancer";
                case WesternZodiac.Leo:
                    return "Leo";
                case WesternZodiac.Virgo:
                    return "Virgo";
                case WesternZodiac.Libra:
                    return "Libra";
                case WesternZodiac.Scorpio:
                    return "Scorpio";
                case WesternZodiac.Sagittarius:
                    return "Sagittarius";
                default:
                    return "Unknown";
            }
        }

        public static string ChinesZodiacName(ChineseZodiac cz)
        {
            switch (cz)
            {
                case ChineseZodiac.Monkey:
                    return "Monkey";
                case ChineseZodiac.Rooster:
                    return "Rooster";
                case ChineseZodiac.Dog:
                    return "Dog";
                case ChineseZodiac.Pig:
                    return "Pig";
                case ChineseZodiac.Rat:
                    return "Rat";
                case ChineseZodiac.Ox:
                    return "Ox";
                case ChineseZodiac.Tiger:
                    return "Tiger";
                case ChineseZodiac.Rabbit:
                    return "Rabbit";
                case ChineseZodiac.Dragon:
                    return "Dragon";
                case ChineseZodiac.Snake:
                    return "Snake";
                case ChineseZodiac.Horse:
                    return "Horse";
                case ChineseZodiac.Sheep:
                    return "Sheep";
                default: return "Unknown";
            }
        }
    }
}
