using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Application.DTOs.Favorite
{
    public class FavoriteItemDto
    {
        public Guid FavoriteId { get; set; }
        public Guid ListingId { get; set; }
        public long ListingNo { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? TranslatorName { get; set; }
        public string? TranslatorEmail { get; set; }
        public string? TranslatorPhoneNumber { get; set; }
        public string? TranslatorProfileImageUrl { get; set; }
        public string? City { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
