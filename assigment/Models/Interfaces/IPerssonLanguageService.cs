using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
  public  interface IPersonLanguageService
    {
        List<PersonLanguage> GetPersonLanguages(int personId);

        PersonLanguage FindPersonLanguage(int id);
        PersonLanguage SearchPersonLanguage(string search);

        void CreatePersonLanguage(PersonLanguage personLanguage);
        void DeletePersonLanguage(PersonLanguage personLanguage);


    }
}
