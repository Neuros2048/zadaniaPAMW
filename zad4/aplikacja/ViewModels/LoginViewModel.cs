using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using shared.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        public static string Token { get; set; } = string.Empty;
        private readonly IServiceProvider _serviceProvider;

        public LoginViewModel(IAuthService authService , IServiceProvider serviceProvider)
        {
            UserLoginDTO = new UserLoginDTO();
            _authService = authService;
            _serviceProvider = serviceProvider;
        }

        [ObservableProperty]
        private UserLoginDTO userLoginDTO;

        [ObservableProperty]
        private SomeInfo mess;

        [RelayCommand]
        public async Task Log()
        {

           
            var response = await _authService.Login(UserLoginDTO);
            if (response.Success)
            {
                Token = response.Data;
                HttpClient http = _serviceProvider.GetService<HttpClient>();

                //IOptions<AppSettings> d =_serviceProvider.GetService(typeof(IOptions<AppSettings>));
                //var cc = bb.BaseAddress;
                //var response = bb.GetAsync(_appSettings.BaseProductEndpoint.GetAllProductsEndpoint);
                //var json = await response.Content.ReadAsStringAsync();
                //var result = JsonConvert.DeserializeObject<ServiceResponse<List<Book>>>(json);
                // aa.GetProductsAsync();
                LiblaryView liblaryView = _serviceProvider.GetService<LiblaryView>();
                LiblaryViewModel productsViewModel = _serviceProvider.GetService<LiblaryViewModel>();
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Replace("\"", ""));

                productsViewModel.setToken(Token);
                liblaryView.Show();

                productsViewModel.GetProducts();
                Mess = new SomeInfo("Poprawne hasło");
                UserLoginDTO = new UserLoginDTO();


            }
            else
            {
                Mess = new SomeInfo("Nie poprawne hasło");
            }

        }

       

    }
}
