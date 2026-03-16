using Tercuman.Application.Interfaces;
using Tercuman.Application.DTOs.Report; // DTO'lar için bu şart!
using Tercuman.Domain.Entities;
using Microsoft.EntityFrameworkCore;
//eski sürümü geri yükledim

namespace Tercuman.Application.Services // .cs kısmını sildik, namespace'te dosya adı olmaz
{
    public class ReportService : IReportService
    {
        private readonly IGenericRepository<Report> _repository;

        public ReportService(IGenericRepository<Report> repository) => _repository = repository;

        public async Task<bool> CreateReportAsync(string userId, CreateReportDto dto)
        {
            // 7. MADDE: Spam kontrolü
            var exists = await _repository.FindAsync(r => r.UserId == userId && r.ListingId == dto.ListingId && r.Status == ReportStatus.Pending);

            if (exists.Any())
                throw new Exception("Bu ilan için henüz sonuçlanmamış bir şikayetiniz bulunmaktadır.");

            var report = new Report
            {
                UserId = userId,
                ListingId = dto.ListingId,
                Reason = dto.Reason,
                Description = dto.Description,
                Status = ReportStatus.Pending, // Başlangıç durumu
                CreatedDate = DateTime.UtcNow
            };

            await _repository.AddAsync(report);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ReportDto>> GetReportsAsync()
        {
            var reports = await _repository.GetAllAsync();
            return reports.Select(r => new ReportDto
            {
                Id = r.Id,
                ListingId = r.ListingId,
                Reason = r.Reason,
                Description = r.Description,
                Status = r.Status.ToString(),
                CreatedDate = r.CreatedDate
            }).ToList(); // Listeye çevirmezsen hata verebilir
        }

        // Interface'de söz verdiğimiz ama unuttuğumuz metot:
        public async Task<ReportDto?> GetReportByIdAsync(Guid id)
        {
            var r = await _repository.GetByIdAsync(id);
            if (r == null) return null;

            return new ReportDto
            {
                Id = r.Id,
                ListingId = r.ListingId,
                Reason = r.Reason,
                Description = r.Description,
                Status = r.Status.ToString(),
                CreatedDate = r.CreatedDate
            };
        }

        public async Task<bool> ResolveReportAsync(Guid id)
        {
            var report = await _repository.GetByIdAsync(id);
            if (report != null)
            {
                report.Status = ReportStatus.Resolved;
                _repository.Update(report);
                await _repository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}