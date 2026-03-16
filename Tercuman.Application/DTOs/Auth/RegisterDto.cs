using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domain.Enums;

namespace Tercuman.Application.DTOs.Auth
{
    public class RegisterDto
    {
        //  FullName is required for registration, but we will also set the BaseEntity.Name to the same value in the AuthService.
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
