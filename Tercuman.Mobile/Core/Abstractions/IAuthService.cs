using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Contracts.DTOs.Auth;




namespace Tercuman.Mobile.Core.Abstractions;

public interface IAuthService
{
    Task<bool> LoginAsync(LoginResponseDto request);
}
