using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
  public  interface ICountryRepo
    {
        List<Country> GetCountries();

        Country FindCountry(int id);
        Country SearchCountry(string search);

        Country CreateCountry(Country country);
        bool DeleteCountry(Country country);



    }
}
