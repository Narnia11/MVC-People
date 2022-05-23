using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
  public  interface ILanguageRepo
    {
        List<Language> GetLanguages();

        Language FindLanguage(int id);
        Language SearchLanguage(string search);

        Language CreateLanguage(Language person);
        bool DeleteLanguage(Language person);



    }
}
