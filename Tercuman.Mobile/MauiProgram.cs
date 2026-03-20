using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Refit;
using Tercuman.Mobile.Handlers;
using Tercuman.Mobile.Services;
using Tercuman.Mobile.Storage;
using Tercuman.Mobile.View;
using Tercuman.Mobile.ViewModels;


namespace Tercuman.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();

            builder.Services
                     .AddRefitClient<IApiService>()
                     .ConfigureHttpClient(c =>
               {
                   c.BaseAddress = new Uri("https://10.0.2.2:5001/");
               });

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<ListingsViewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddSingleton<TokenStorageService>();
            builder.Services.AddTransient<AuthHeaderHandler>();
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddTransient<ListingsPage>();


            builder.Services
                .AddRefitClient<IApiService>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("http://10.0.2.2:5216");
                })
                .AddHttpMessageHandler<AuthHeaderHandler>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}