using Microsoft.AspNetCore.Mvc;
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
    }
}