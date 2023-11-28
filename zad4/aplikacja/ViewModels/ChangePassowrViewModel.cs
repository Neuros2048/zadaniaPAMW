using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using shared.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class ChangePassowrViewModel : ObservableObject
    {
        private readonly IAuthService _authService;

        private readonly IServiceProvider _serviceProvider;

        public ChangePassowrViewModel(IAuthService authService, IServiceProvider serviceProvider)
        {
            _authService = authService;
            _serviceProvider = serviceProvider;
            Passs = new UserRegisterDTO();
        }


        [ObservableProperty]
        private UserRegisterDTO passs;

        [ObservableProperty]
        private SomeInfo mess;

        [RelayCommand]
        public async Task Chang()
        {
            if (passs.Password == passs.ConfirmPassword)
            {
                var response = await _authService.ChangePassword(passs.Password);
                if (response.Success)
                {

                    Mess = new SomeInfo("Hasło zostało zmienione");
                    passs = new UserRegisterDTO();

                }
                else
                {
                    Mess = new SomeInfo("Nie Udało się zmienić hasła");
                }
            }
            else
            {
                Mess = new SomeInfo("Hasła nie są takie same");
            }
            
        }
    }
}
