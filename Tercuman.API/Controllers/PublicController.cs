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
    }
}
=======
using Tercuman.API.Models;
using Tercuman.Contracts.DTOs.Public;
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
            return Ok(ApiResponse<object>.Ok(result));
        }

        [HttpPost("contact")]
        public async Task<IActionResult> SendContact([FromBody] ContactFormDto dto)
        {
            await _publicService.SendContactAsync(dto);
            return Ok(ApiResponse<object>.Ok(null, "Mesaj başarıyla alındı."));
        }
    }
}
>>>>>>> 0426f3014207cc9f149fd2f8b942c2cdddd16ba2
