using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class CountryService : ICountryService
    {
        private ICountryRepo _CountryRepo;
        public CountryService(ICountryRepo PeopleRepo)
        {
           this._CountryRepo = PeopleRepo;
        }

        public void CreateCountry(Country country)
        {
            _CountryRepo.CreateCountry(country);
        }

        public void DeleteCountry(Country country)
        {
            _CountryRepo.DeleteCountry(country);

        }

        public Country FindCountry(int id)
        {
            return _CountryRepo.FindCountry(id);        }

        public List<Country> GetCountries()
        {
            return _CountryRepo.GetCountries();
        }

        public Country SearchCountry(string search)
        {
            return _CountryRepo.SearchCountry(search);
        }
    }
}
