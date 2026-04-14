using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Mobile.Core.Constants;

public static class StorageKeys
{
    // Hata veren 'AccessToken' tanımı tam olarak budur:
    public const string AccessToken = "access_token";

    // İleride lazım olacak diğer anahtarlar:
    public const string RefreshToken = "refresh_token";
    public const string UserId = "user_id";
    public const string UserName = "user_name";
}
