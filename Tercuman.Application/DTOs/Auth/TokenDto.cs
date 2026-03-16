using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Application.DTOs.Auth
{
    public class TokenDto // veya LoginResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty; 
        public DateTime Expiration { get; set; }
    }
}
