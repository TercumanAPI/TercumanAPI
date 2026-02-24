using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Common;


namespace Tercuman.Domin.Entities
{
    public class User : BaseEntity
    {
        // Auth
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Profile
        public string? Bio { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? ProfileImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation
        public ICollection<Listing> Listings { get; set; }
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
    }
}