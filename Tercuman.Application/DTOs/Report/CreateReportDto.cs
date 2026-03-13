using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Application.DTOs.Report;

public class CreateReportDto
{
    public int ListingId { get; set; }        // Şikayet edilen ilanın ID'si
    public string Reason { get; set; } = null!; // Şikayet başlığı/sebebi (örn: Yanıltıcı İlan)
    public string Description { get; set; } = null!; // Kullanıcının yazdığı detaylı açıklama
}
