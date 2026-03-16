using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tercuman.Application.DTOs.User;
using Tercuman.Application.Interfaces;

namespace Tercuman.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [Authorize]
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null) return NotFound();

        return Ok(new UserProfileDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Bio = user.Bio,
            PhoneNumber = user.PhoneNumber,
            City = user.City,
            ProfileImageUrl = user.ProfileImageUrl,
            Gender = user.Gender,
            IsActive = user.IsActive
        });
    }

    [Authorize]
    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfile(UpdateProfileDto dto)
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null) return NotFound();

        user.FullName = dto.FullName;
        user.Email = dto.Email;
        user.Bio = dto.Bio;
        user.PhoneNumber = dto.PhoneNumber;
        user.City = dto.City;
        user.Gender = dto.Gender;

        await _userRepository.SaveChangesAsync();
        return Ok();
    }

    [Authorize]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null) return NotFound();

        if (!BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, user.PasswordHash))
            return BadRequest("Mevcut şifre yanlış");

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
        await _userRepository.SaveChangesAsync();

        return Ok("Şifre güncellendi");
    }

    [Authorize]
    [HttpPost("profile/image")]
    public async Task<IActionResult> UploadProfileImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Dosya seçilmedi.");

        var extension = Path.GetExtension(file.FileName).ToLower();
        if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
            return BadRequest("Sadece JPG veya PNG yüklenebilir.");

        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
        if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

        var fileName = Guid.NewGuid() + extension;
        var filePath = Path.Combine(uploadPath, fileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return NotFound();

        user.ProfileImageUrl = "/images/" + fileName;
        await _userRepository.SaveChangesAsync();

        return Ok(new { success = true, imageUrl = user.ProfileImageUrl });
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}/toggle-status")]
    public async Task<IActionResult> ToggleUserStatus(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return NotFound();

        user.IsActive = !user.IsActive;
        await _userRepository.SaveChangesAsync();

        return Ok(new { success = true, status = user.IsActive });
    }
}
