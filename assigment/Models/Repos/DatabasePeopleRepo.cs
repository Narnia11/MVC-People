using Microsoft.EntityFrameworkCore;
using assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class DatabasePeoplesRepo : IPeopleRepo
    {
        private ExDBContext _DBContext;
        public DatabasePeoplesRepo(ExDBContext myDBContext)
        {
            _DBContext = myDBContext;
        }

        public Person CreatePerson(Person person)
        {
            Person p = new Person()
            {

                PersonName = person.PersonName,
                PersonPhoneNumber = person.PersonPhoneNumber,
                City = person.City,
            };
            _DBContext.Peoples.Add(p);
            _DBContext.SaveChanges();
            return person;
        }

        public bool DeletePerson(Person person)
        {


            var result = _DBContext.Peoples.FirstOrDefault(x => x.Id == person.Id);
            if (result != null)
            {
                _DBContext.Peoples.Remove(result);
                _DBContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Person FindPerson(int id)
        {
            return _DBContext.Peoples.FirstOrDefault(x => x.Id == id);

        }

        public List<Person> GetPeoples()
        {
            return _DBContext.Peoples.ToList();

        }

        public Person SearchPerson(string search)
        {
            return _DBContext.Peoples.FirstOrDefault(x => x.City.ToLower().Contains(search.ToLower()) || x.PersonName.Contains(search.ToLower()));

        }
        public void UpdatePerson(Person person)
        {
            _DBContext.Peoples.Update(person);
            _DBContext.SaveChanges();
        }
    }
}
