using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tercuman.API.Models;
using Tercuman.Infrastructure.Persistence;

namespace Tercuman.API.Controllers;

[ApiController]
[Route("api/admin")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var data = new
        {
            users = await _context.Users.CountAsync(),
            listings = await _context.Listings.CountAsync(),
            messages = await _context.Messages.CountAsync()
        };

        return Ok(ApiResponse.Ok(data));
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _context.Users
            .OrderByDescending(x => x.CreatedDate)
            .Select(x => new
            {
                x.Id,
                x.FullName,
                x.Email,
                x.IsActive,
                x.IsApproved,
                x.Role,
                x.CreatedDate
            })
            .ToListAsync();

        return Ok(ApiResponse.Ok(users));
    }

    [HttpPut("users/role")]
    public async Task<IActionResult> UpdateRole([FromBody] UpdateUserRoleRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
        if (user == null)
        {
            return NotFound(ApiResponse.Fail("Kullanıcı bulunamadı."));
        }

        user.Role = request.Role;
        await _context.SaveChangesAsync();

        return Ok(ApiResponse.Ok(new { user.Id, user.Role }, "Rol güncellendi"));
    }

    [HttpPut("users/{id:guid}/toggle-status")]
    public async Task<IActionResult> ToggleUserStatus(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            return NotFound(ApiResponse.Fail("Kullanıcı bulunamadı."));
        }

        user.IsActive = !user.IsActive;
        await _context.SaveChangesAsync();

        return Ok(ApiResponse.Ok(new { user.Id, user.IsActive }, "Kullanıcı durumu güncellendi"));
    }

    [HttpGet("reports")]
    public async Task<IActionResult> GetReports()
    {
        var reports = await _context.Reports
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();

        return Ok(ApiResponse.Ok(reports));
    }

    [HttpPut("reports/{id:guid}/resolve")]
    public async Task<IActionResult> ResolveReport(Guid id)
    {
        var report = await _context.Reports.FirstOrDefaultAsync(x => x.Id == id);
        if (report == null)
        {
            return NotFound(ApiResponse.Fail("Şikayet bulunamadı."));
        }

        report.Status = Tercuman.Domin.Entities.ReportStatus.Resolved;
        await _context.SaveChangesAsync();

        return Ok(ApiResponse.Ok(report, "Şikayet çözüldü"));
    }

    [HttpGet("messages")]
    public async Task<IActionResult> GetMessages([FromQuery] int take = 100)
    {
        var safeTake = Math.Clamp(take, 1, 500);

        var messages = await _context.Messages
            .OrderByDescending(x => x.CreatedDate)
            .Take(safeTake)
            .Select(x => new
            {
                x.Id,
                x.ConversationId,
                x.SenderId,
                x.ReceiverId,
                x.Text,
                x.IsRead,
                x.CreatedDate
            })
            .ToListAsync();

        return Ok(ApiResponse.Ok(messages));
    }
}

public class UpdateUserRoleRequest
{
    public Guid UserId { get; set; }
    public string Role { get; set; } = "User";
}
