using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domain.Enums;

namespace Tercuman.Contracts.DTOs.Listing;


    public class CreateListingDto
    {
        public Guid SourceLanguageId { get; set; }
        public Guid TargetLanguageId { get; set; }
        public Guid CityId { get; set; }

        public decimal Price { get; set; }

        public ExperienceLevel ExperienceLevel { get; set; }

        public ServiceType ServiceType { get; set; }

        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Description { get; set; }
        public string Title { get; set; } = string.Empty;
}

