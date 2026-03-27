using Microsoft.Maui.Networking;
using Tercuman.Mobile.Core.Abstractions;

namespace Tercuman.Mobile.Core.Services;

public class ConnectivityService : IConnectivityService
{
    public bool HasInternet() => Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
}
