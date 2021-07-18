using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class Weather
    {
        public string CountryCode { get; set; }
        public string CityCode { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
    }
}
