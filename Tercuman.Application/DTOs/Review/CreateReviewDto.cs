using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Application.DTOs.Review
{
    public class CreateReviewDto
    {
        public Guid TranslatorId { get; set; } // Puan verilen çevirmen
        public int ListingId { get; set; }      // Hangi ilan üzerinden yorum yapılıyor
        public int Rating { get; set; }         // 1-5 arası puan
        public string Comment { get; set; } = string.Empty; // Yorum metni
    }
}
