using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tercuman.Application.DTOs.Listing;
using Tercuman.Application.Interfaces;

namespace Tercuman.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ListingsController : ControllerBase
{
    private readonly IListingService _listingService;

    public ListingsController(IListingService listingService)
    {
        _listingService = listingService;
    }

    // ============================
    // CREATE LISTING
    // ============================
    [Authorize] //  Sadece login yeterli
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateListingDto dto)
    {

        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);


        if (userIdClaim == null)
            return Unauthorized(new
            {
                success = false,
                message = "UserId claim bulunamadı"
            });

        var userId = Guid.Parse(userIdClaim.Value);

        await _listingService.CreateAsync(dto, userId);

        return Ok(new
        {
            success = true,
            message = "Listing created successfully"
        });
    }

    // ============================
    // GET DETAIL
    // ============================
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(Guid id)
    {
        var result = await _listingService.GetDetailAsync(id);

        if (result == null)
            return NotFound(new
            {
                success = false,
                message = "Listing bulunamadı"
            });

        return Ok(new
        {
            success = true,
            data = result
        });
    }

    // ============================
    // GET PAGED
    // ============================
    [HttpGet]
    public async Task<IActionResult> GetPaged(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? sort = null)
    {
        var listings = await _listingService.GetPagedAsync(page, pageSize, sort);
        var totalCount = await _listingService.CountAsync();

        return Ok(new
        {
            success = true,
            data = listings,
            totalCount,
            page,
            pageSize
        });
    }

    // ============================
    // FILTER LISTINGS
    // ============================
    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] FilterListingDto filter)
    {
        var result = await _listingService.FilterAsync(filter);

        return Ok(new
        {
            success = true,
            data = result
        });
    }

    // ============================
    // UPLOAD IMAGES
    // ============================
    [Authorize]
    [HttpPost("{id}/images")]
    public async Task<IActionResult> UploadImages(Guid id, [FromForm] List<IFormFile> files)
    {
        if (files == null || files.Count == 0)
            return BadRequest("En az 1 fotoğraf yüklemelisiniz.");

        if (files.Count > 10)
            return BadRequest("En fazla 10 fotoğraf yüklenebilir.");

        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        var imageUrls = new List<string>();

        foreach (var file in files)
        {
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                return BadRequest("Sadece JPG/PNG yüklenebilir.");

            var fileName = Guid.NewGuid() + extension;
            var filePath = Path.Combine(uploadPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            imageUrls.Add("/images/" + fileName);
        }

        await _listingService.AddImagesAsync(id, imageUrls);

        return Ok(new
        {
            success = true,
            images = imageUrls
        });
    }

    // ============================
    // SEARCH LISTINGS
    [HttpGet("search")]
    public async Task<IActionResult> Search(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return BadRequest("Keyword gerekli");

        var result = await _listingService.SearchAsync(keyword);

        return Ok(new
        {
            success = true,
            data = result
        });
    }
}