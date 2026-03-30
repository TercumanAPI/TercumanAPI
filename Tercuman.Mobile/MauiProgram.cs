using Microsoft.Extensions.Logging;
using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Mobile.Core.Services;
using Tercuman.Mobile.Features.Auth.ViewModels;
using Tercuman.Mobile.Features.Auth.Views;
using Tercuman.Mobile.Features.Dashboard.ViewModels;
using Tercuman.Mobile.Features.Dashboard.Views;
using Tercuman.Mobile.Features.Ads.ViewModels;
using Tercuman.Mobile.Features.Ads.Views;

namespace Tercuman.Mobile;

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

        // ==========================================
        // 1. CORE & INFRASTRUCTURE (SINGLETON)
        // ==========================================
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<ITokenStorage, TokenStorage>();
        builder.Services.AddSingleton<IUserSession, UserSession>();
        builder.Services.AddSingleton<IApiService, ApiService>();

        // İş mantığı servisleri
        builder.Services.AddSingleton<IAuthService, AuthService>();

        // ==========================================
        // 2. VIEWMODELS (TRANSIENT)
        // ==========================================
        // Auth Modülü
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<ForgotPasswordViewModel>();
        builder.Services.AddTransient<CreateAdPage>();
        builder.Services.AddTransient<CreateAdViewModel>();

        // Dashboard Modülü
        builder.Services.AddTransient<DashboardViewModel>();

        // ==========================================
        // 3. PAGES (TRANSIENT)
        // ==========================================
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<ForgotPasswordPage>();
        builder.Services.AddTransient<DashboardPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}