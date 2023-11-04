using shared.Books;
using shared.service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Configurations;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    // przekazywanie wartosci do innego formularza 
    public partial class MainViewModelV4 : ObservableObject
    {
        private CityViewModel _selectedCity;
        
        private readonly IAccuWeatherService _accuWeatherService;
        LiblaryView _LiblaryView;
        LiblaryViewModel _LiblaryViewModel;

        private readonly IServiceProvider _serviceProvider;

        public MainViewModelV4(IAccuWeatherService accuWeatherService, IServiceProvider serviceProvider)
        {
            _accuWeatherService = accuWeatherService;
            _serviceProvider = serviceProvider;
            Cities = new ObservableCollection<CityViewModel>(); // podejście nr 2 
        }


        public CityViewModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
                LoadWeather();
            }
        }




        [ObservableProperty]
        public CurrentConditionViewModel condition;




        private async void LoadWeather()
        {
            if(SelectedCity != null)
            {
                
                var weather = await _accuWeatherService.GetCurrentConditions(SelectedCity.Key);
                var forcast = await _accuWeatherService.GetCurrentForcast(SelectedCity.Key);
                var hourforcast = await _accuWeatherService.GetHourForcast(SelectedCity.Key);
                var day5forcast = await _accuWeatherService.Get5daysForcast(SelectedCity.Key);
                var nearcities = await _accuWeatherService.GetNearCitys(SelectedCity.Key);
                var cityinfo = await _accuWeatherService.GetCityInfo(SelectedCity.Key);
                Condition = new CurrentConditionViewModel(weather, forcast, hourforcast, day5forcast, nearcities,cityinfo);
                
            }
        } 

        // podajście nr 2 do przechowywania kolekcji obiektów:
        public ObservableCollection<CityViewModel> Cities { get; set; }

        [RelayCommand]
        public async void LoadCities(string locationName)
        {
            // podejście nr 2:
            var cities = await _accuWeatherService.GetLocations(locationName);
            Cities.Clear();
            foreach (var city in cities) 
                Cities.Add(new CityViewModel(city));
        }
        [RelayCommand]
        public void OpenShopWindow()
        {

            //ILiblaryServis aa = _serviceProvider.GetService<ILiblaryServis>();
            HttpClient bb =_serviceProvider.GetService<HttpClient>();
            
            //IOptions<AppSettings> d =_serviceProvider.GetService(typeof(IOptions<AppSettings>));
            //var cc = bb.BaseAddress;
            //var response = bb.GetAsync(_appSettings.BaseProductEndpoint.GetAllProductsEndpoint);
            //var json = await response.Content.ReadAsStringAsync();
            //var result = JsonConvert.DeserializeObject<ServiceResponse<List<Book>>>(json);
           // aa.GetProductsAsync();
            LiblaryView liblaryView = _serviceProvider.GetService<LiblaryView>();
            LiblaryViewModel productsViewModel = _serviceProvider.GetService<LiblaryViewModel>();
            liblaryView.Show();
            
            productsViewModel.GetProducts();
        }




    }
}
