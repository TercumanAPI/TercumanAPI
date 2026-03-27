using Microsoft.Extensions.DependencyInjection;
using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Mobile.Core.Config;
using Tercuman.Mobile.Core.Handlers;
using Tercuman.Mobile.Core.Services;
using Tercuman.Mobile.Features.Auth.ViewModels;
using Tercuman.Mobile.Features.Auth.Views;
using Tercuman.Mobile.Features.Dashboard.ViewModels;
using Tercuman.Mobile.Features.Dashboard.Views;
using Tercuman.Mobile.Features.Favorites.ViewModels;
using Tercuman.Mobile.Features.Favorites.Views;
using Tercuman.Mobile.Features.Listings.ViewModels;
using Tercuman.Mobile.Features.Listings.Views;
using Tercuman.Mobile.Features.Messages.Services;
using Tercuman.Mobile.Features.Messages.ViewModels;
using Tercuman.Mobile.Features.Messages.Views;
using Tercuman.Mobile.Features.Notifications.ViewModels;
using Tercuman.Mobile.Features.Notifications.Views;
using Tercuman.Mobile.Features.Profile.ViewModels;
using Tercuman.Mobile.Features.Profile.Views;
using Tercuman.Mobile.Features.Settings.ViewModels;
using Tercuman.Mobile.Features.Settings.Views;

namespace Tercuman.Mobile.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMobileCoreServices(this IServiceCollection services)
    {
        services.AddTransient<AuthHeaderHandler>();
        services.AddTransient<LoggingHandler>();
        services.AddTransient<RetryHandler>();

        services.AddHttpClient<IApiService, ApiService>(client =>
        {
            client.BaseAddress = new Uri(ApiSettings.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(ApiSettings.TimeoutSeconds);
        })
        .AddHttpMessageHandler<AuthHeaderHandler>()
        .AddHttpMessageHandler<LoggingHandler>()
        .AddHttpMessageHandler<RetryHandler>();

        services.AddSingleton<ITokenStorage, TokenStorage>();
        services.AddSingleton<IUserSession, UserSession>();
        services.AddSingleton<IAuthService, AuthService>();
        services.AddSingleton<IConnectivityService, ConnectivityService>();
        services.AddSingleton<IAlertService, AlertService>();
        services.AddSingleton<INavigationService, NavigationService>();

        return services;
    }

    public static IServiceCollection AddMobileFeatureServices(this IServiceCollection services)
    {
        services.AddTransient<SplashViewModel>();
        services.AddTransient<LoginViewModel>();
        services.AddTransient<RegisterViewModel>();
        services.AddTransient<ForgotPasswordViewModel>();
        services.AddTransient<DashboardViewModel>();
        services.AddTransient<ProfileViewModel>();
        services.AddTransient<EditProfileViewModel>();
        services.AddTransient<ListingsViewModel>();
        services.AddTransient<ListingDetailViewModel>();
        services.AddTransient<CreateListingViewModel>();
        services.AddTransient<ListingFilterViewModel>();
        services.AddTransient<MyListingsViewModel>();
        services.AddTransient<FavoritesViewModel>();
        services.AddTransient<MessagesViewModel>();
        services.AddTransient<ConversationDetailViewModel>();
        services.AddTransient<NewConversationViewModel>();
        services.AddTransient<NotificationsViewModel>();
        services.AddTransient<SettingsViewModel>();

        services.AddSingleton<IChatService, ChatService>();

        services.AddTransient<SplashPage>();
        services.AddTransient<LoginPage>();
        services.AddTransient<RegisterPage>();
        services.AddTransient<ForgotPasswordPage>();
        services.AddTransient<DashboardPage>();
        services.AddTransient<ProfilePage>();
        services.AddTransient<EditProfilePage>();
        services.AddTransient<ListingsPage>();
        services.AddTransient<ListingDetailPage>();
        services.AddTransient<CreateListingPage>();
        services.AddTransient<ListingFilterPage>();
        services.AddTransient<MyListingsPage>();
        services.AddTransient<FavoritesPage>();
        services.AddTransient<MessagesPage>();
        services.AddTransient<ConversationDetailPage>();
        services.AddTransient<NewConversationPage>();
        services.AddTransient<NotificationsPage>();
        services.AddTransient<SettingsPage>();

        return services;
    }
}
