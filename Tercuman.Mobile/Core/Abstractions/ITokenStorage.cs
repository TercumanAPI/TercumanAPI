using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Mobile.Core.Abstractions;

public interface ITokenStorage
{
    Task SaveTokenAsync(string token);
    Task<string> GetTokenAsync();
    void RemoveToken();
}
