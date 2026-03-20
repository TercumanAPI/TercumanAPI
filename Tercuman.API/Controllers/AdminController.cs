using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
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

    [HttpPut("users/change-role")]
    public IActionResult ChangeRole([FromBody] RoleChangeDto dto)
    {
        // Rol değiştirme mantığı
        return Ok();
    }
}
=======
using Microsoft.EntityFrameworkCore;
using Tercuman.API.Models;
using Tercuman.Application.Interfaces;
using Tercuman.Infrastructure.Persistence;

namespace Tercuman.API.Controllers;

[ApiController]
[Route("api/admin")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IReportService _reportService;
    private readonly IMessageRepository _messageRepository;

    public AdminController(AppDbContext context, IUserRepository userRepository, IReportService reportService, IMessageRepository messageRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _reportService = reportService;
        _messageRepository = messageRepository;
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
        var data = users.Select(u => new
        {
            u.Id,
            u.FullName,
            u.Email,
            u.Role,
            u.IsActive,
            u.CreatedDate,
            u.Gender
        });

        return Ok(ApiResponse<object>.Ok(data));
    }

    public record UpdateRoleRequest(Guid UserId, string Role);

    [HttpPut("users/role")]
    public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleRequest request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
            return NotFound(ApiResponse<object>.Fail("User not found"));

        user.Role = request.Role;
        await _userRepository.SaveChangesAsync();

        return Ok(ApiResponse<object>.Ok(new { user.Id, user.Role }, "Role updated"));
    }

    [HttpPut("users/{id:guid}/toggle-status")]
    public async Task<IActionResult> ToggleUserStatus(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            return NotFound(ApiResponse<object>.Fail("User not found"));

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
            return NotFound(ApiResponse<object>.Fail("Report not found"));

        return Ok(ApiResponse<object>.Ok(new { id, status = "Resolved" }));
    }

    [HttpGet("messages")]
    public async Task<IActionResult> GetMessages()
    {
        var messages = await _messageRepository.GetAllAsync();
        var data = messages
            .OrderByDescending(m => m.CreatedDate)
            .Take(200)
            .Select(m => new
            {
                m.Id,
                m.ConversationId,
                m.SenderId,
                m.ReceiverId,
                m.Text,
                m.IsRead,
                m.CreatedDate
            });

        return Ok(ApiResponse<object>.Ok(data));
    }
}
>>>>>>> 0426f3014207cc9f149fd2f8b942c2cdddd16ba2
