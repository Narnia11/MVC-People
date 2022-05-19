using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class CityService : ICityService
    {
        private ICityRepo _CityRepo;
        public CityService(ICityRepo CityRepo)
        {
           this._CityRepo = CityRepo;
        }

        public void CreateCity(City person)
        {
            _CityRepo.CreateCity(person);
        }

        public void DeleteCity(City person)
        {
            _CityRepo.DeleteCity(person);

        }

        public City FindCity(int id)
        {
            return _CityRepo.FindCity(id);        }

        public List<City> GetCities()
        {
            return _CityRepo.GetCities();
        }

        public City SearchCity(string search)
        {
            return _CityRepo.SearchCity(search);
        }
    }
}
