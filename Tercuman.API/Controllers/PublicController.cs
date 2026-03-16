using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
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
=======
using Tercuman.Application.DTOs.Public;
using Tercuman.Application.Interfaces;

namespace Tercuman.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicController : ControllerBase
    {
        private readonly IPublicService _publicService;

        public PublicController(IPublicService publicService)
        {
            _publicService = publicService;
        }

        [HttpGet("translators")]
        public async Task<IActionResult> GetTranslators()
        {
            var result = await _publicService.GetTranslatorsAsync();
            return Ok(result);
        }

        [HttpPost("contact")]
        public async Task<IActionResult> SendContact([FromBody] ContactFormDto dto)
        {
            await _publicService.SendContactAsync(dto);
            return Ok(new { message = "Mesaj başarıyla alındı." });
        }
>>>>>>> efcc83481aea69abe64d12c29ca2bc3db00f783e
    }
}