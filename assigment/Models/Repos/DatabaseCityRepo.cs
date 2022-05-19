using Microsoft.EntityFrameworkCore;
using assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class DatabaseCityRepo: ICityRepo
    {
        private ExDBContext _DBContext;
        public DatabaseCityRepo(ExDBContext myDBContext)
        {
            _DBContext = myDBContext;
        }

        public City CreateCity(City city)
        {
            City p = new City()
            {

                Name = city.Name,
            };
            _DBContext.Cities.Add(city);
            _DBContext.SaveChanges();
            return city;
        }

        public bool DeleteCity(City city)
        {


            var result = _DBContext.Cities.FirstOrDefault(x => x.Id == city.Id);
            if (result != null)
            {
                _DBContext.Cities.Remove(result);
                _DBContext.SaveChanges();
                return true;
            }
            return false;
        }

        public City FindCity(int id)
        {
            return _DBContext.Cities.FirstOrDefault(x => x.Id == id);

        }

        public List<City> GetCities()
        {
            return _DBContext.Cities.ToList();

        }

        public City SearchCity(string search)
        {
            return _DBContext.Cities.FirstOrDefault(x => x.Name.ToLower().Contains(search.ToLower()) ||x.Name.Contains(search.ToLower()));

        }
    }
}
