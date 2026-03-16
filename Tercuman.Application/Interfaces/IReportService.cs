using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tercuman.Application.DTOs.Report;

namespace Tercuman.Application.Interfaces;

public interface IReportService
{
    // Kullanıcının şikayet oluşturması için
    Task<bool> CreateReportAsync(string userId, CreateReportDto dto);

    // Adminin tüm şikayetleri listelemesi için
    Task<IEnumerable<ReportDto>> GetReportsAsync();

    // Adminin belirli bir şikayeti detaylı görmesi için
    Task<ReportDto?> GetReportByIdAsync(Guid id);

    // Adminin şikayeti "Çözüldü" (Resolved) olarak işaretlemesi için
    Task<bool> ResolveReportAsync(Guid id);
}
