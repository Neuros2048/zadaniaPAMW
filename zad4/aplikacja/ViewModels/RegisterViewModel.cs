using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using P04WeatherForecastAPI.Client.Models;
using shared.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using P04WeatherForecastAPI.Client.Services;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthService _authService;
        public RegisterViewModel( IServiceProvider serviceProvider, IAuthService authService)
        {
            _authService = authService;
            UserRegisterDTO = new UserRegisterDTO();
            _serviceProvider = serviceProvider;
        }

        [ObservableProperty]
        private UserRegisterDTO userRegisterDTO;

        [ObservableProperty]
        private SomeInfo mess;


        [RelayCommand]
        public async Task Reg()
        {



            var response = await _authService.Register(UserRegisterDTO);
            if (response.Success)
            {
                
                Mess = new SomeInfo("Użytkonik został doday");
                UserRegisterDTO = new UserRegisterDTO();

            }
            else
            {
                Mess = new SomeInfo("Nie Udało się dodać użytokwnika");
            }
            

        }
    }
}
