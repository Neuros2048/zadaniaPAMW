using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{


    public class CurrentConditionViewModel
    {

        public string lblCityName { get; set; }
        public double lblTemperatureValue { get; set; }
        public string lblforcast { get; set; }
        public string lblhourforcast { get; set; }
        public string lbl5dayforcast { get; set; }
        public string lblnearcities1 { get; set; }
        public string lblnearcities2 { get; set; }
        public string lblnearcities3 { get; set; }
        public double lblLatitude { get; set; }
        public double lblLongitude { get; set; }
        

        public CurrentConditionViewModel(Weather weather,  Focast forcast, HourForcast hourforcast, Focast day5forcast, NearCities[] nearcities,Cityinfo cityinfo)
        {

            // lblCityName = weather.
            lblCityName = "palecholder";
            lblTemperatureValue  = weather.Temperature.Metric.Value;
            
            lblforcast = forcast.Headline.Text;
            
            lblhourforcast = hourforcast.WeatherText;
            
            lbl5dayforcast = day5forcast.DailyForecasts[1].Day.IconPhrase;
            
            lblnearcities1 = nearcities[0].EnglishName;
            lblnearcities2 = nearcities[1].EnglishName;
            lblnearcities3 = nearcities[2].EnglishName;
            
            lblLatitude = cityinfo.GeoPosition.Latitude;
            lblLongitude = cityinfo.GeoPosition.Longitude;
        }
    }
}
