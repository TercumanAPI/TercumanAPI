using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tercuman.Infrastructure.Persistence;

namespace Tercuman.API.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _context.Users
            .Select(x => new
            {
                x.Id,
                x.FullName,
                x.Email,
                x.IsActive
            })
            .ToListAsync();

        return Ok(users);
    }
}