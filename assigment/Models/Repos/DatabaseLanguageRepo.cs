using Microsoft.EntityFrameworkCore;
using assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.Models;

namespace assignment.Models
{
    public class DatabaseLanguageRepo: ILanguageRepo
    {
        private ExDBContext _DBContext;
        public DatabaseLanguageRepo(ExDBContext myDBContext)
        {
            _DBContext = myDBContext;
        }

        public Language CreateLanguage(Language language)
        {
            Language p = new Language()
            {

                LanguageName = language.LanguageName,
            };
            _DBContext.Languages.Add(language);
            _DBContext.SaveChanges();
            return language;
        }

        public bool DeleteLanguage(Language language)
        {


            var result = _DBContext.Languages.FirstOrDefault(x => x.Id == language.Id);
            if (result != null)
            {
                _DBContext.Languages.Remove(result);
                _DBContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Language FindLanguage(int id)
        {
            return _DBContext.Languages.FirstOrDefault(x => x.Id == id);

        }

        public List<Language> GetLanguages()
        {
            return _DBContext.Languages.ToList();

        }

        public Language SearchLanguage(string search)
        {
            throw new NotImplementedException();
        }
    }
}
