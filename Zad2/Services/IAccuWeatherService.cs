using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    public interface IAccuWeatherService
    {
        Task<City[]> GetLocations(string locationName);
        Task<Weather> GetCurrentConditions(string cityKey);
        Task<Focast> GetCurrentForcast(string cityKey);
        Task<HourForcast> GetHourForcast(string cityKey);
        Task<Focast> Get5daysForcast(string cityKey);
        Task<NearCities[]> GetNearCitys(string cityKey);
        Task<Cityinfo> GetCityInfo(string cityKey);
    }
}
