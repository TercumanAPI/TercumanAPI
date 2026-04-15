using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Mobile.Core.Config;

public static class ApiSettings
{
    // Cihazın platformuna göre doğru adresi seçer
    // Windows Machine için 'localhost', Android Emulator için '10.0.2.2'
    public static string BaseUrl = Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android
        ? "http://10.0.2.2:5216/"
        : "http://localhost:5216/";

    public static string ApiBaseUrl => $"{BaseUrl}api/";

    // Auth Endpoints
    public const string LoginEndpoint = "auth/login";
    public const string RegisterEndpoint = "auth/register";
}