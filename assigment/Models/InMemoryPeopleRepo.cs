﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleAssignment.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> _people = new List<Person>()
            {
                new Person{Id=1,PersonName="Amir",City="tehran" },
                new Person{Id=2,PersonName="Narges",City="shahrood" },
                new Person{Id=3,PersonName="Ali",City="Sari" },
            };
        private static int idCounter = 0;

   
        public Person CreatePerson(Person person)
        {
            Person p = new Person()
            {

                Id = ++idCounter,
                PersonName = person.PersonName,
                PersonPhoneNumber = person.PersonPhoneNumber,
                City = person.City,
            };

            _people.Add(p);
            return person;
        }

        public bool DeletePerson(Person person)
        {
            bool result = _people.Remove(person);
            return result;
        }

        public Person FindPerson(int id)
        {
            foreach (Person person in _people)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }
            return null;
        }

        public List<Person> GetPeoples()
        {
            return InMemoryPeopleRepo._people;
        }

        public Person SearchPerson(string search)
        {
            foreach (Person person in _people)
            {
                if (person.PersonName.ToLower().Contains(search.ToLower()) || person.City.ToLower().Contains(search.ToLower()))
                {
                    return person;
                }
            }
            return null;
        }
    }
}