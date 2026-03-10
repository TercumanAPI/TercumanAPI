using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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
    public async Task<IActionResult> GetAll()
    {
        var languages = await _context.Languages.ToListAsync();

        return Ok(languages);
    }
}