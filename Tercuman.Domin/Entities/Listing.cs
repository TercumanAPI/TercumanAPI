using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Common;
using Tercuman.Domin.Enums;

namespace Tercuman.Domin.Entities
{
    public class Listing : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public long ListingNo { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsApproved { get; set; } = true;
        public int ViewCount { get; set; } = 0;


        public ServiceType ServiceType { get; set; }
        public Guid SourceLanguageId { get; set; }
        public Language SourceLanguage { get; set; }

        public Guid TargetLanguageId { get; set; }
        public Language TargetLanguage { get; set; }
        // FK
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid CityId { get; set; }
        public City? City { get; set; }


        // Navigation
        public ICollection<ListingImage> Images { get; set; } = new List<ListingImage>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<ListingView> Views { get; set; } = new List<ListingView>();
    }
}