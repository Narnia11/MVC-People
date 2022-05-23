using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleAssignment.Models
{
  public  interface IPersonLanguageRepo
    {
        List<PersonLanguage> GetPersonLanguages(int personId);

        PersonLanguage FindPersonLanguage(int id);
        PersonLanguage SearchPersonLanguage(string search);

        PersonLanguage CreatePersonLanguage(PersonLanguage personLanguage);
        bool DeletePersonLanguage(PersonLanguage personLanguage);



    }
}
