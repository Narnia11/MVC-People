using assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class LanguageService : ILanguageService
    {
        private ILanguageRepo _LanguageRepo;
        public LanguageService(ILanguageRepo LanguageRepo)
        {
           this._LanguageRepo = LanguageRepo;
        }

        public void CreateLanguage(Language person)
        {
            _LanguageRepo.CreateLanguage(person);
        }

        public void DeleteLanguage(Language person)
        {
            _LanguageRepo.DeleteLanguage(person);

        }

        public Language FindLanguage(int id)
        {
            return _LanguageRepo.FindLanguage(id);        }

        public List<Language> GetLanguages()
        {
            return _LanguageRepo.GetLanguages();
        }

        public Language SearchLanguage(string search)
        {
            return _LanguageRepo.SearchLanguage(search);
        }
    }
}
