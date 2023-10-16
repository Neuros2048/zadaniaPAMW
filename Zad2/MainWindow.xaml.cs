using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P04WeatherForecastAPI.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccuWeatherService accuWeatherService;
        public MainWindow()
        {
            InitializeComponent();
            accuWeatherService = new AccuWeatherService();
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            City[] cities= await accuWeatherService.GetLocations(txtCity.Text);

            // standardowy sposób dodawania elementów
            //lbData.Items.Clear();
            //foreach (var c in cities)
            //    lbData.Items.Add(c.LocalizedName);

            // teraz musimy skorzystac z bindowania danych bo chcemy w naszej kontrolce przechowywac takze id miasta 
            lbData.ItemsSource = cities;
        }

        private async void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCity= (City)lbData.SelectedItem;
            if(selectedCity != null)
            {
                var weather = await accuWeatherService.GetCurrentConditions(selectedCity.Key);
                lblCityName.Content = selectedCity.LocalizedName;
                double tempValue = weather.Temperature.Metric.Value;
                lblTemperatureValue.Content = Convert.ToString(tempValue);
                var forcast = await accuWeatherService.GetCurrentForcast(selectedCity.Key);
                lblforcast.Content = forcast.Headline.Text;
                var hourforcast = await accuWeatherService.GetHourForcast(selectedCity.Key);
                lblhourforcast.Content = hourforcast.WeatherText;
                var day5forcast = await accuWeatherService.Get5daysForcast(selectedCity.Key);
                lbl5dayforcast.Content = day5forcast.DailyForecasts[1].Day.IconPhrase;
                var nearcities = await accuWeatherService.GetNearCitys(selectedCity.Key);
                lblnearcities1.Content = nearcities[0].EnglishName;
                lblnearcities2.Content = nearcities[1].EnglishName;
                lblnearcities3.Content = nearcities[2].EnglishName;
                var cityinfo = await accuWeatherService.GetCityInfo(selectedCity.Key);
                lblLatitude.Content = cityinfo.GeoPosition.Latitude;
                lblLongitude.Content = cityinfo.GeoPosition.Longitude;
    }
        }
    }
}
