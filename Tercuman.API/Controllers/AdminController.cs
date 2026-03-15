using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tercuman.Infrastructure.Persistence;
using Tercuman.API.DTOs;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly AppDbContext _context;
    public AdminController(AppDbContext context) => _context = context;

    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers() => Ok(await _context.Users.ToListAsync());

}