using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WeatherAPI.Interfaces;

namespace WeatherAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeather _weather;
        public WeatherController(IWeather weather)
        {
            _weather = weather;
        }


        [HttpGet("Countries")]
        public async Task<ActionResult<ObjectReturn>> Countries()
        {
            var countries = await _weather.GetCountries();

            var obj = new ObjectReturn
            {
                statusCode = 200,
                message = "OK",
                data = countries
            };

            return Ok(obj);
        }

        [HttpGet("Cities/{code}")]
        public async Task<ActionResult<ObjectReturn>> Cities(string code)
        {
            var cities = await _weather.GetCities(code);

            var obj = new ObjectReturn
            {
                statusCode = 200,
                message = "OK",
                data = cities
            };

            return Ok(obj);
        }
    }
}
