using System;
using System.Threading.Tasks;


using WeatherAPI.Interfaces;
using System.Collections.Generic;
using WeatherAPI.Models;
using Moq;
using Xunit;
using WeatherAPI.Services;
using System.Linq;

namespace WeatherAPI.Tests
{
    public class WeatherServicesTests
    {
        //private readonly WeatherController _weatherServices;
        private readonly WeatherService _weatherService;
        private readonly Mock<IWeather> _weatherMock;

        public WeatherServicesTests()
        {
            // _weatherServices = new WeatherController(_weatherMock.Object);
            _weatherService = new WeatherService();
            _weatherMock = new Mock<IWeather>();
        }

        [Fact]
        public async Task GetCity_ReturnEmpty_WhenCountryDoesntExist()
        {
            //arrange
            string CountryCode = "FR";
            var cities = new List<City>();
            _weatherMock.Setup(x => x.GetCities(CountryCode)).ReturnsAsync(cities);

            //act
            var cityList = await _weatherService.GetCities("IN");

            //assert
            Assert.Empty(cityList);          
        }

        [Fact]
        public async Task GetCity_WhenCountrySelected()
        {
            //arrange
            string CountryCode = "FR";
            var cities = new List<City>();
            _weatherMock.Setup(x => x.GetCities(CountryCode)).ReturnsAsync(cities);

            //act
            var cityList = await _weatherService.GetCities(CountryCode);

            //assert
            Assert.Equal(CountryCode, cityList[0].CountryCode);

        }
    }
}
