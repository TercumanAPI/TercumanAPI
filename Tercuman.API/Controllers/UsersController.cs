using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tercuman.Application.DTOs;
using Tercuman.Application.DTOs.User;
using Tercuman.Application.Interfaces;

namespace Tercuman.API.Controllers
{
    public class UsersController : Controller

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
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

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
        [Authorize]
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateProfileDto dto, IFormFile? image)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
                return NotFound();

            user.FullName = dto.FullName;
            user.Bio = dto.Bio;
            user.PhoneNumber = dto.PhoneNumber;
            user.City = dto.City;
            user.Gender = dto.Gender;

            if (image != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);

                var path = Path.Combine("wwwroot/profiles", fileName);

                using var stream = new FileStream(path, FileMode.Create);

                await image.CopyToAsync(stream);

                user.ProfileImageUrl = "/profiles/" + fileName;
            }

            await _userRepository.SaveChangesAsync();

            return Ok();
        }
    }
}
