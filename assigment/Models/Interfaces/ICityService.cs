using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
  public  interface ICityService
    {
        List<City> GetCities();

        City FindCity(int id);
        City SearchCity(string search);

        void CreateCity(City person);
        void DeleteCity(City person);


    }
}
