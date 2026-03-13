using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tercuman.Domin.Common;

namespace Tercuman.Domin.Entities;

public enum ReportStatus { Pending, Resolved, Rejected }

public class Report : BaseEntity
{
    public string UserId { get; set; } = null!;      // Şikayet eden
    public int ListingId { get; set; }               // Şikayet edilen ilan
    public string Reason { get; set; } = null!;      // Şikayet sebebi
    public string Description { get; set; } = null!; // Detaylı açıklama
    public ReportStatus Status { get; set; } = ReportStatus.Pending;
}