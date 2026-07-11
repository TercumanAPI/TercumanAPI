using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Mobile.Core.Config;

public static class ApiSettings
{
    // Android Emulator için localhost adresi 10.0.2.2'dir.
    // iOS veya Gerçek cihaz için kendi IP adresini yazmalısın.
    public const string BaseUrl = "http://10.0.2.2:5216/";
    public const string ApiBaseUrl = $"{BaseUrl}api/";

    // Auth Endpoints
    public const string LoginEndpoint = "auth/login";
    public const string RegisterEndpoint = "auth/register";
}