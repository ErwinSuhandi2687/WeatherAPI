using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI.Interfaces
{
    public interface IWeather
    {
        Task<List<City>> GetCountries();
        Task<List<City>> GetCities(string CountryCode);
    }
}
