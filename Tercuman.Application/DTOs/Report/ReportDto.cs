using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Application.DTOs.Report;

public class ReportDto
{
    public Guid Id { get; set; }               // Şikayetin kendi Guid ID'si
    public string UserId { get; set; } = null!; // Şikayeti yapan kişinin ID'si
    public int ListingId { get; set; }         // Şikayet edilen ilan ID'si
    public string Reason { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Status { get; set; } = null!; // "Pending", "Resolved" veya "Rejected" olarak döner
    public DateTime CreatedDate { get; set; }  // Şikayetin yapıldığı tarih
}
