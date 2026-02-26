using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Application.DTOs.Listing
{
    public class ListingDetailDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string UserFullName { get; set; }   // 🔥 FullName değil


        public int ViewCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<string> Images { get; set; }
    }
}