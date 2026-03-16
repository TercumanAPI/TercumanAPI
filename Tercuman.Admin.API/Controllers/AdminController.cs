using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tercuman.Admin.API.Models;
using Tercuman.Application.Interfaces;
using Tercuman.Domain.Entities;

namespace Tercuman.Admin.API.Controllers;

[ApiController]
[Route("api/admin")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMessageRepository _messageRepository;
    private readonly IReportService _reportService;

    public AdminController(IUserRepository userRepository, IMessageRepository messageRepository, IReportService reportService)
    {
        _userRepository = userRepository;
        _messageRepository = messageRepository;
        _reportService = reportService;
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var users = await _userRepository.GetAllAsync();
        var reports = await _reportService.GetReportsAsync();

        var data = new
        {
            totalUsers = users.Count,
            activeUsers = users.Count(x => x.IsActive),
            bannedUsers = users.Count(x => !x.IsActive),
            pendingReports = reports.Count(x => x.Status == "Pending")
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
            x.CreatedDate
        });

        return Ok(ApiResponse<object>.Ok(data));
    }

    [HttpPut("users/{id:guid}/ban")]
    public async Task<IActionResult> BanUser(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound(new ApiResponse<object> { Success = false, Message = "User not found", Errors = new[] { "USER_NOT_FOUND" } });
        }

        user.IsActive = false;
        await _userRepository.SaveChangesAsync();
        return Ok(ApiResponse<object>.Ok(new { user.Id, user.IsActive }));
    }

    [HttpPut("users/{id:guid}/unban")]
    public async Task<IActionResult> UnbanUser(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound(new ApiResponse<object> { Success = false, Message = "User not found", Errors = new[] { "USER_NOT_FOUND" } });
        }

        user.IsActive = true;
        await _userRepository.SaveChangesAsync();
        return Ok(ApiResponse<object>.Ok(new { user.Id, user.IsActive }));
    }

    public record UpdateRoleRequest(string Role);

    [HttpPut("users/{id:guid}/role")]
    public async Task<IActionResult> UpdateRole(Guid id, [FromBody] UpdateRoleRequest request)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound(new ApiResponse<object> { Success = false, Message = "User not found", Errors = new[] { "USER_NOT_FOUND" } });
        }

        user.Role = request.Role;
        await _userRepository.SaveChangesAsync();
        return Ok(ApiResponse<object>.Ok(new { user.Id, user.Role }));
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
            return NotFound(new ApiResponse<object> { Success = false, Message = "Report not found", Errors = new[] { "REPORT_NOT_FOUND" } });
        }

        return Ok(ApiResponse<object>.Ok(new { id, status = "Resolved" }));
    }

    [HttpGet("messages")]
    public async Task<IActionResult> GetMessages([FromQuery] Guid userId)
    {
        var messages = await _messageRepository.GetUserNotificationsAsync(userId);
        var data = messages.Select(x => new
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
