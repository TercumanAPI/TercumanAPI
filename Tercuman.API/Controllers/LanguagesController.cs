using Microsoft.AspNetCore.Mvc;
using Tercuman.Domin.Entities;
using Tercuman.Infrastructure.Persistence;

namespace Tercuman.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController : ControllerBase
{
    private readonly AppDbContext _context;

    public LanguagesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Add(Language language)
    {
        _context.Languages.Add(language);
        await _context.SaveChangesAsync();
        return Ok(language);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Languages.ToList());
    }
}