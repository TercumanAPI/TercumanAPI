using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Enums;

namespace Tercuman.Application.DTOs.Listing
{
    public class ListingDetailDto
    {        
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string City { get; set; }

            // 🔥 User bilgileri
            public string UserFullName { get; set; }
            public string Gender { get; set; }
            public DateTime UserCreatedAt { get; set; }

            // 🔥 Listing bilgileri
            public int ViewCount { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime CreatedDate { get; set; }
            public List<string> Images { get; set; }
            public ExperienceLevel ExperienceLevel { get; set; }
            public ServiceType ServiceType { get; set; }
        
    }
}