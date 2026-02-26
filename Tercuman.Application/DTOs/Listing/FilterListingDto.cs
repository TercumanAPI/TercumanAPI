using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Enums;

namespace Tercuman.Application.DTOs.Listing
{
    public class FilterListingDto
    {
        public Guid? CityId { get; set; }
        public Guid? SourceLanguageId { get; set; }
        public Guid? TargetLanguageId { get; set; }

        public ServiceType? ServiceType { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
