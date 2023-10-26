using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using P04WeatherForecastAPI.Client.Services;
using P04WeatherForecastAPI.Client.ViewModels;
using P04WeatherForecastAPI.Client.Configurations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace P04WeatherForecastAPI.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IServiceProvider _serviceProvider;
        IConfiguration _configuration;

        public App()
        {

            var builder = new ConfigurationBuilder()
              .AddUserSecrets<App>()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsetings.json");
            _configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var appSettingsSection = ConfigureAppSettings(serviceCollection);
            ConfigureHttpClients(serviceCollection, appSettingsSection);
            _serviceProvider = serviceCollection.BuildServiceProvider();


        }
        private AppSettings ConfigureAppSettings(IServiceCollection services)
        {
            // pobranie appsettings z konfiguracji i zmapowanie na klase AppSettings 
            //Microsoft.Extensions.Options.ConfigurationExtensions
            var appSettings = _configuration.GetSection(nameof(AppSettings));
            var appSettingsSection = appSettings.Get<AppSettings>();
            services.Configure<AppSettings>(appSettings);
            return appSettingsSection;
        }




        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAccuWeatherService, AccuWeatherService>();
            services.AddSingleton<ILiblaryServis, LiblaryServis>();

            services.AddSingleton<MainViewModelV4>();
            services.AddSingleton<LiblaryViewModel>();

            services.AddTransient<MainWindow>();
            services.AddTransient<LiblaryView>();



        }

         private void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
        {
            var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
            {
                Path = appSettingsSection.BaseProductEndpoint.Base_url,
            };
            //Microsoft.Extensions.Http
            services.AddHttpClient<ILiblaryServis, LiblaryServis>(client => client.BaseAddress = uriBuilder.Uri);
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

    }
}
