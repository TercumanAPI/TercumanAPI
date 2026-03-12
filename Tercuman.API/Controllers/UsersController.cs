using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tercuman.Application.Interfaces;

[ApiController]
[Route("api/translator")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // GET api/translator/profile
    [Authorize]
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
            return NotFound();

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

    // PUT api/translator/profile
    [Authorize]
    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfile(UpdateProfileDto dto)
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
            return NotFound();

        user.FullName = dto.FullName;
        user.Email = dto.Email;
        user.Bio = dto.Bio;
        user.PhoneNumber = dto.PhoneNumber;
        user.City = dto.City;
        user.Gender = dto.Gender;

        await _userRepository.SaveChangesAsync();

        return Ok();
    }
}