using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tercuman.Infrastructure.Persistence;

[Authorize(Roles = "Translator")]
[ApiController]
[Route("api/translator")]
public class TranslatorController : ControllerBase
{
    private readonly AppDbContext _context;
    public TranslatorController(AppDbContext context) => _context = context;

    [HttpGet("dashboard")]
    public IActionResult GetDashboardStats()
    {
        // Reviews, Conversations tablolarından istatistik çekilir
        return Ok(new { totalReviews = 0, activeJobs = 0 });
    }

    [HttpPut("profile/toggle")]
    public IActionResult ToggleStatus()
    {
        // Profil aktif/pasif çekme mantığı
        return Ok();
    }
}