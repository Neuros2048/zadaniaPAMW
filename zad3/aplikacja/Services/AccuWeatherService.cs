using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    public class AccuWeatherService : IAccuWeatherService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language{2}";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language{2}";
        private const string forcast_endpoint = "forecasts/v1/daily/1day/{0}?apikey={1}&language{2}";
        private const string forcast_hour_endpoint = "currentconditions/v1/{0}?apikey={1}&language{2}";
        private const string forcast_5days_endpoint = "forecasts/v1/daily/5day/{0}?apikey={1}&language{2}";
        private const string near_cities = "locations/v1/cities/neighbors/{0}?apikey={1}&language{2}";
        private const string city_info = "locations/v1/{0}?apikey={1}&language{2}";
        // private const string api_key = "5hFl75dja3ZuKSLpXFxUzSc9vXdtnwG5";
        string api_key;
        //private const string language = "pl";
        string language;

        public AccuWeatherService()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetings.json");

            var configuration = builder.Build();
            api_key = configuration["AppSettings:api_key"];
            language = configuration["AppSettings:DefaultLanguage"];
        }


        public async Task<City[]> GetLocations(string locationName)
        {
            string uri = base_url + "/" + string.Format(autocomplete_endpoint, api_key, locationName, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;

            }
        }

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers = JsonConvert.DeserializeObject<Weather[]>(json);
                return weathers.FirstOrDefault();
            }
        }
        public async Task<Focast> GetCurrentForcast(string cityKey)
        {
            string uri = base_url + "/" + string.Format(forcast_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Focast forcast = JsonConvert.DeserializeObject<Focast>(json);
                return forcast;
            }
        }

        public async Task<HourForcast> GetHourForcast(string cityKey)
        {
            string uri = base_url + "/" + string.Format(forcast_hour_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                HourForcast[] hourforc = JsonConvert.DeserializeObject<HourForcast[]>(json);
                return hourforc.FirstOrDefault();
            }
        }

        public async Task<Focast> Get5daysForcast(string cityKey)
        {
            string uri = base_url + "/" + string.Format(forcast_5days_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Focast forcast = JsonConvert.DeserializeObject<Focast>(json);
                return forcast;
            }
        }

        public async Task<NearCities[]> GetNearCitys(string cityKey)
        {
            string uri = base_url + "/" + string.Format(near_cities, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                NearCities[] cities = JsonConvert.DeserializeObject<NearCities[]>(json);
                return cities;

            }
        }

        public async Task<Cityinfo> GetCityInfo(string cityKey)
        {
            string uri = base_url + "/" + string.Format(city_info, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Cityinfo cityinfo = JsonConvert.DeserializeObject<Cityinfo>(json);
                return cityinfo;

            }
        }
    }
}
