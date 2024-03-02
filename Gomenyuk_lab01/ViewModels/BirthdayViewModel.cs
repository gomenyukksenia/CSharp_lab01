using KMA.CSharp2024.Gomenyuk_lab01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.CSharp2024.Gomenyuk_lab01.ViewModels
{
    internal class BirthdayViewModel
    {
        private BirthDate _birthDate;
        public BirthdayViewModel(DateTime date) {
            _birthDate = new BirthDate(date);
        }

        public void UpdateDate(DateTime date) 
        {
            _birthDate = new BirthDate(date);
        }

        public string AgeDescription()
        {
            return _birthDate.DetailedAge;
        }

        public string Description()
        {
            return _birthDate.BDdate.ToShortDateString();
        }

        public string Greating()
        {
            if (_birthDate.Age < 0)
            {
               return "You don`t exsist yet, too young!";
            }
            else if (_birthDate.Age >= 135)
            {
                return "You don`t exsist, too old!";
            }
            else
            {
                if (_birthDate.IsBirthdayToday)
                {
                    return "You survived another year! Happy birthday!";
                }
            }
            return "Just another day";
        }

        public string WesternZodiacName() 
        {
            switch(_birthDate.westZodiac)
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

        public string ChinesZodiacName()
        {
            switch(_birthDate.chineseZodiac) 
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
