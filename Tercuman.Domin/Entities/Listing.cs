using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Common;

namespace Tercuman.Domin.Entities
{
    public class Listing : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsApproved { get; set; } = true;
        public int ViewCount { get; set; } = 0;

        // FK
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; }
        // Navigation
        public ICollection<ListingImage> Images { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<ListingView> Views { get; set; }
    }
}