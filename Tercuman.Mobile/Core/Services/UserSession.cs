using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Mobile.Core.Abstractions;
namespace Tercuman.Mobile.Core.Services;

public class UserSession : IUserSession
{
    public string Token { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    // Diğer kullanıcı bilgileri buraya gelecek
}