using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Enums;

namespace Tercuman.Application.DTOs.Listing;


    public class CreateListingDto
    {
        public Guid SourceLanguageId { get; set; }
        public Guid TargetLanguageId { get; set; }
        public Guid CityId { get; set; }

        public decimal Price { get; set; }

        public ExperienceLevel ExperienceLevel { get; set; }

        public ServiceType ServiceType { get; set; }

        public string Description { get; set; }
        public string Title { get; set; } = string.Empty;
}

