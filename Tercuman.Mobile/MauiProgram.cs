using Microsoft.Extensions.Logging;
using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Mobile.Core.Services;
using Tercuman.Mobile.Features.Auth.ViewModels;
using Tercuman.Mobile.Features.Auth.Views;
using Tercuman.Mobile.Features.Dashboard.ViewModels;
using Tercuman.Mobile.Features.Dashboard.Views;
using Tercuman.Mobile.Features.Ads.ViewModels;
using Tercuman.Mobile.Features.Ads.Views;
using Tercuman.Mobile.Features.Profile.ViewModels;
using Tercuman.Mobile.Features.Profile.Views;
using Tercuman.Mobile.Features.Messages.Services;
using Tercuman.Mobile.Features.Messages.ViewModels;
using Tercuman.Mobile.Features.Messages.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;


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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // ==========================================
        // 1. CORE & INFRASTRUCTURE (SINGLETON)
        // ==========================================
        builder.Services.AddSingleton(sp =>
        {
            // 1. Sertifika hatalarını es geçmek için bir handler oluşturuyoruz
            var handler = new HttpClientHandler();

#if DEBUG
            // Geliştirme aşamasında emülatörün SSL hatası vermesini engeller
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
#endif

            // 2. HttpClient'ı bu handler ile oluşturuyoruz
            var client = new HttpClient(handler)
            {
                // Senin ApiSettings dosendaki 10.0.2.2 veya localhost adresini otomatik alır
                BaseAddress = new Uri(Tercuman.Mobile.Core.Config.ApiSettings.BaseUrl)
            };

            return client;
        });
        builder.Services.AddSingleton<ITokenStorage, TokenStorage>();
        builder.Services.AddSingleton<IUserSession, UserSession>();
        builder.Services.AddSingleton<IApiService, ApiService>();

        // İş mantığı servisleri
        builder.Services.AddSingleton<IAuthService, AuthService>();
        builder.Services.AddSingleton<IChatService, ChatService>();

        // ==========================================
        // 2. VIEWMODELS (TRANSIENT)
        // ==========================================
        // Auth Modülü
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<ForgotPasswordViewModel>();
        builder.Services.AddTransient<CreateAdPage>();
        builder.Services.AddTransient<CreateAdViewModel>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<MessagesViewModel>();
        builder.Services.AddTransient<ConversationDetailViewModel>();
        builder.Services.AddTransient<Features.Listings.ViewModels.ListingDetailViewModel>();

        // Dashboard Modülü
        builder.Services.AddTransient<DashboardViewModel>();

        // ==========================================.
        // 3. PAGES (TRANSIENT)
        // ==========================================.
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<ForgotPasswordPage>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<MessagesPage>();
        builder.Services.AddTransient<ConversationDetailPage>();
        builder.Services.AddTransient<Features.Listings.Views.ListingDetailPage>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}