using Microsoft.AspNetCore.Mvc;
using Tercuman.Infrastructure.Persistence;
using Tercuman.API.DTOs;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/public")]
public class PublicController : ControllerBase
{
    private readonly AppDbContext _context;
    public PublicController(AppDbContext context) => _context = context;

    [HttpGet("translators")]
    public async Task<IActionResult> GetTranslators()
    {
        // Öne çıkan veya tüm aktif tercümanları döner
        var translators = await _context.Users.Where(u => u.Role == "Translator").ToListAsync();
        return Ok(translators);
    }

    [HttpPost("contact")]
    public IActionResult SendContactForm([FromBody] ContactDto dto)
    {
        // İletişim formu mantığı buraya
        return Ok(new { message = "Mesajınız iletildi." });
    }
}