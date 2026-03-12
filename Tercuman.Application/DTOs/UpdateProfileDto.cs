using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Enums;

namespace Tercuman.Application.DTOs
{
    public class UpdateProfileDto
    {
        public string FullName { get; set; }

        public string? Bio { get; set; }

        public string? PhoneNumber { get; set; }

        public string? City { get; set; }

        public Gender Gender { get; set; }
    }
}
