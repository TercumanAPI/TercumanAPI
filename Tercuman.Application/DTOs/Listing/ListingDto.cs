using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Tercuman.Domin.Enums;

namespace Tercuman.Application.DTOs.Listing
{
    public class ListingDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public Guid CityId { get; set; }
        public string CityName { get; set; }

        public Guid SourceLanguageId { get; set; }
        public Guid TargetLanguageId { get; set; }

        public ServiceType ServiceType { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }

        public int ViewCount { get; set; }
        public string City { get; internal set; }
    }
}