using Microsoft.EntityFrameworkCore;
using assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleAssignment.Models;

namespace assignment.Models
{
    public class DatabasePersonLanguageRepo: IPersonLanguageRepo
    {
        private ExDBContext _DBContext;
        public DatabasePersonLanguageRepo(ExDBContext myDBContext)
        {
            _DBContext = myDBContext;
        }

        public PersonLanguage CreatePersonLanguage(PersonLanguage personLanguage)
        {
            PersonLanguage p = new PersonLanguage()
            {

                LanguageId = personLanguage.LanguageId,
                PersonId = personLanguage.PersonId,
            };
            _DBContext.PersonLanguages.Add(personLanguage);
            _DBContext.SaveChanges();
            return personLanguage;
        }

        public bool DeletePersonLanguage(PersonLanguage personLanguage)
        {


            var result = _DBContext.PersonLanguages.FirstOrDefault(x => x.PersonId == personLanguage.PersonId&& x.LanguageId==personLanguage.LanguageId);
            if (result != null)
            {
                _DBContext.PersonLanguages.Remove(result);
                _DBContext.SaveChanges();
                return true;
            }
            return false;
        }

        public PersonLanguage FindPersonLanguage(int id)
        {
            return _DBContext.PersonLanguages.FirstOrDefault(x => x.PersonId == id);

        }

        public List<PersonLanguage> GetPersonLanguages(int personId)
        {
            return _DBContext.PersonLanguages.Where(x=>x.PersonId== personId).ToList();

        }

        public PersonLanguage SearchPersonLanguage(string search)
        {
            throw new NotImplementedException();
        }
    }
}
