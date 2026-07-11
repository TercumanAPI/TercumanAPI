using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tercuman.API.Models;
using Tercuman.Application.DTOs.Report;
using Tercuman.Application.Interfaces;

namespace Tercuman.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReportDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _reportService.CreateReportAsync(userId!, dto);
            return Ok(ApiResponse<object>.Ok(null, "Şikayetiniz alındı, admin tarafından incelenecektir."));
        }
    }
}
