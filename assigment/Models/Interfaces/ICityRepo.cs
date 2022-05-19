using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
  public  interface ICityRepo
    {
        List<City> GetCities();

        City FindCity(int id);
        City SearchCity(string search);

        City CreateCity(City person);
        bool DeleteCity(City person);



    }
}
