using assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class PersonLanguageService : IPersonLanguageService
    {
        private IPersonLanguageRepo _PersonLanguageRepo;
        private assignment.Models.ILanguageService _languageService;

        public PersonLanguageService(IPersonLanguageRepo PersonLanguageRepo, ILanguageService languageService)
        {
           this._PersonLanguageRepo = PersonLanguageRepo;
            _languageService = languageService;
        }

 
        public void CreatePersonLanguage(PersonLanguage person)
        {
            _PersonLanguageRepo.CreatePersonLanguage(person);
        }

        public void DeletePersonLanguage(PersonLanguage person)
        {
            _PersonLanguageRepo.DeletePersonLanguage(person);

        }

        public PersonLanguage FindPersonLanguage(int id)
        {
            return _PersonLanguageRepo.FindPersonLanguage(id);        }

        public List<PersonLanguage> GetPersonLanguages(int personId)
        {
            return _PersonLanguageRepo.GetPersonLanguages(personId);
        }

        public PersonLanguage SearchPersonLanguage(string search)
        {
            return _PersonLanguageRepo.SearchPersonLanguage(search);
        }
    }
}
