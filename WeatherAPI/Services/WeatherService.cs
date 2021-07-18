using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;


using WeatherAPI.Interfaces;
using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public class WeatherService : IWeather
    {
        public List<City> GetCountryCity()
        {
            List<City> cities = new List<City>
            {
                new City { CountryCode = "GB", State = "UK", CityName = "London" },
                new City { CountryCode = "GB", State = "UK", CityName = "Leicester" },
                new City { CountryCode = "GB", State = "UK", CityName = "Bristol" },
                new City { CountryCode = "FR", State = "France", CityName = "Paris" },
                new City { CountryCode = "FR", State = "France", CityName = "Rennes" },
                new City { CountryCode = "NL", State = "Netherlands", CityName = "Amsterdam" },
            };

            return cities;
        }

        public Task<List<City>> GetCities(string CountryCode)
        {
            var cities = GetCountryCity().Where(x => x.CountryCode == CountryCode).ToList();
            return Task.FromResult(cities);
        }

        public Task<List<City>> GetCountries()
        {
            var countries = GetCountryCity();
            return Task.FromResult(countries);
        }
    }
}
