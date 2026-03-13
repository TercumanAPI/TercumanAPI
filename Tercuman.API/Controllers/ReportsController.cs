using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Tercuman.Application.Interfaces;
using Tercuman.Application.DTOs.Report;

namespace Tercuman.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportsController(IReportService reportService) => _reportService = reportService;

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateReportDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _reportService.CreateReportAsync(userId!, dto);
            return Ok(new { message = "Şikayetiniz alındı, admin tarafından incelenecektir." });
        }

        [Authorize(Roles = "Admin")] // Sadece Adminler görebilir
        [HttpGet("admin/all")]
        public async Task<IActionResult> GetAll() => Ok(await _reportService.GetReportsAsync());

        [Authorize(Roles = "Admin")]
        [HttpPut("admin/{id}/resolve")]
        public async Task<IActionResult> Resolve(Guid id)
        {
            await _reportService.ResolveReportAsync(id);
            return Ok(new { message = "Şikayet çözüldü olarak işaretlendi." });
        }
    }
}
