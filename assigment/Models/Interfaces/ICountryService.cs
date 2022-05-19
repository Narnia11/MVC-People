using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
  public  interface ICountryService
    {
        List<Country> GetCountries();

        Country FindCountry(int id);
        Country SearchCountry(string search);

        void CreateCountry(Country person);
        void DeleteCountry(Country person);


    }
}
