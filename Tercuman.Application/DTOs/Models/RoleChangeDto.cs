using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.API.DTOs
{
    public class RoleChangeDto
    {
        public int UserId { get; set; }
        public string NewRole { get; set; }
    }
}
