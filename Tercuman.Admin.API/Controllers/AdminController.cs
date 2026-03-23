using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tercuman.Admin.API.Models;
using Tercuman.Application.Interfaces;
using Tercuman.Infrastructure.Persistence;

namespace Tercuman.Admin.API.Controllers;

[ApiController]
[Route("api/admin")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IMessageRepository _messageRepository;
    private readonly IReportService _reportService;

    public AdminController(AppDbContext context, IUserRepository userRepository, IMessageRepository messageRepository, IReportService reportService)
    {
        _context = context;
        _userRepository = userRepository;
        _messageRepository = messageRepository;
        _reportService = reportService;
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var data = new
        {
            totalUsers = await _context.Users.CountAsync(),
            totalListings = await _context.Listings.CountAsync(),
            totalMessages = await _context.Messages.CountAsync()
        };

        return Ok(ApiResponse<object>.Ok(data));
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userRepository.GetAllAsync();
        var data = users.Select(x => new
        {
            x.Id,
            x.FullName,
            x.Email,
            x.Role,
            x.IsActive,
            x.CreatedDate,
            x.Gender
        });

        return Ok(ApiResponse<object>.Ok(data));
    }

    [HttpPut("users/{id:guid}/toggle-status")]
    public async Task<IActionResult> ToggleStatus(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound(ApiResponse<object>.Fail("User not found", new[] { "USER_NOT_FOUND" }));
        }

        user.IsActive = !user.IsActive;
        await _userRepository.SaveChangesAsync();
        return Ok(ApiResponse<object>.Ok(new { user.Id, user.IsActive }));
    }

    [HttpGet("reports")]
    public async Task<IActionResult> GetReports()
    {
        var reports = await _reportService.GetReportsAsync();
        return Ok(ApiResponse<object>.Ok(reports));
    }

    [HttpPut("reports/{id:guid}/resolve")]
    public async Task<IActionResult> ResolveReport(Guid id)
    {
        var resolved = await _reportService.ResolveReportAsync(id);
        if (!resolved)
        {
            return NotFound(ApiResponse<object>.Fail("Report not found", new[] { "REPORT_NOT_FOUND" }));
        }

        return Ok(ApiResponse<object>.Ok(new { id, status = "Resolved" }));
    }

    [HttpGet("messages")]
    public async Task<IActionResult> GetMessages()
    {
        var messages = await _messageRepository.GetAllAsync();
        var data = messages
            .OrderByDescending(x => x.CreatedDate)
            .Take(200)
            .Select(x => new
            {
                x.Id,
                x.SenderId,
                x.ReceiverId,
                x.Text,
                x.IsRead,
                x.CreatedDate
            });

        return Ok(ApiResponse<object>.Ok(data));
    }
}
