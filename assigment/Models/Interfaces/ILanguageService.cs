using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleAssignment.Models
{
  public  interface ILanguageService
    {
        List<Language> GetLanguages();

        Language FindLanguage(int id);
        Language SearchLanguage(string search);

        void CreateLanguage(Language person);
        void DeleteLanguage(Language person);


    }
}
