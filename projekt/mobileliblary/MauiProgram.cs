using Microsoft.Extensions.Logging;
using mobileliblary.Messagebox;
using mobileliblary.services;
using mobileliblary.shared.Configutations;
using mobileliblary.shared.Messagebox;
using mobileliblary.viewmodels;


namespace mobileliblary
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            ConfigureServices(builder.Services);
            return builder.Build();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = ConfigureAppSettings(services);
            ConfigureAppServices(services);
            ConfigureViewModels(services);
            ConfigureViews(services);
            ConfigureHttpClients(services, appSettingsSection);
        }

        private static AppSettings ConfigureAppSettings(IServiceCollection services)
        {

            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5209"
                : "http://localhost:5209";
            var appSettingsSection = new AppSettings()
            {

                BaseAPIUrl = baseUrl,
                BaseProductEndpoints = new BaseProductEndpoint()
                {
                    Base_url = "/api/Library",
                    GetAllProductsEndpoint = "/getBooksList",
                    GetProductEndpoint = "/getBook?id={0}",
                    AddProductEndpoint = "/addBook?Title={0}&Author={1}&Description={2}&NumberOfBooks={3}",
                    ChangeProductEndpoint = "/changeBook?Title={0}&Author={1}&Description={2}&NumberOfBooks={3}&Id={4}",
                    DeleteProductEndpoint = "/deleteBook?id={0}"
                },
            };
            services.AddSingleton(appSettingsSection);

            return appSettingsSection;
        }


        private static void ConfigureAppServices(IServiceCollection services)
        {
            services.AddSingleton<IConnectivity>(Connectivity.Current);
            services.AddSingleton<IGeolocation>(Geolocation.Default);
            services.AddSingleton<IMap>(Map.Default);

            // konfiguracja serwisów 
            services.AddSingleton<ILiblaryServis, LiblaryServis>();
            services.AddSingleton<IMessageDialogService, MauiMessageDialogService>();

        }


        private static void ConfigureViewModels(IServiceCollection services)
        {

            // konfiguracja viewModeli 


            services.AddSingleton<BooksViewModel>();
            services.AddTransient<BookDetailViewModel>();

            // services.AddSingleton<BaseViewModel,MainViewModelV3>();
        }

        private static void ConfigureViews(IServiceCollection services)
        {
            // konfiguracja okienek 
            services.AddSingleton<MainPage>();
            services.AddTransient<BookDetailsView>();
        }

        private static void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
        {
            var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
            {
                Path = appSettingsSection.BaseProductEndpoints.Base_url,
            };
            //Microsoft.Extensions.Http
            services.AddHttpClient<ILiblaryServis, LiblaryServis>(client => client.BaseAddress = uriBuilder.Uri);
        }
    }
}
