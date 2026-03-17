using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Contracts.DTOs.Auth;

namespace Tercuman.Contracts.DTOs.Auth;

public class LoginResponseDto
{
    public Guid UserId { get; set; }
    public string Token { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
