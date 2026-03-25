using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Refit;
using Tercuman.Mobile.Handlers;
using Tercuman.Mobile.Services;
using Tercuman.Mobile.Storage;
using Tercuman.Mobile.View;
using Tercuman.Mobile.ViewModels;

namespace Tercuman.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // 🔥 STORAGE
        builder.Services.AddSingleton<TokenStorageService>();

        // 🔥 SERVICES
        builder.Services.AddSingleton<AuthService>();
        builder.Services.AddTransient<AuthHeaderHandler>();
        builder.Services.AddTransient<ApiExceptionHandler>();

        // 🔥 API
        builder.Services
            .AddRefitClient<IApiService>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://10.0.2.2:5001");
                c.Timeout = TimeSpan.FromSeconds(30);
            })
            .AddHttpMessageHandler<AuthHeaderHandler>()
            .AddHttpMessageHandler<ApiExceptionHandler>();

        // 🔥 VIEWMODELS
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<ListingsViewModel>();

        // 🔥 PAGES
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<ListingsPage>();
        builder.Services.AddTransient<ListingDetailPage>(); // 🔥 KRİTİK

        // 🔥 SHELL
        builder.Services.AddSingleton<AppShell>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}