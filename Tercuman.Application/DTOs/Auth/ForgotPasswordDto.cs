using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Application.DTOs.Auth;

namespace Tercuman.Application.DTOs.Auth
{
    public class ForgotPasswordDto
    {
        public string Email { get; set; } = string.Empty;
    }
}
