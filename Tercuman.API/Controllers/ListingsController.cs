using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tercuman.API.Models;
using Tercuman.Contracts.DTOs.Common;
using Tercuman.Contracts.DTOs.Listing;
using Tercuman.Application.Interfaces;

namespace Tercuman.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ListingsController : ControllerBase
{
    private readonly IListingService _listingService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IConfiguration _configuration;

    public ListingsController(IListingService listingService, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    {
        _listingService = listingService;
        _webHostEnvironment = webHostEnvironment;
        _configuration = configuration;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateListingDto dto)
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
            return Unauthorized(ApiResponse<object>.Fail("UserId claim bulunamadı"));

        var userId = Guid.Parse(userIdClaim.Value);
        await _listingService.CreateAsync(dto, userId);

        return Ok(ApiResponse<object>.Ok(null, "Listing created successfully"));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail(Guid id)
    {
        var result = await _listingService.GetDetailAsync(id);

        if (result == null)
            return NotFound(ApiResponse<object>.Fail("Listing bulunamadı"));

        return Ok(ApiResponse<ListingDetailDto>.Ok(result));
    }

    [HttpGet]
    public async Task<IActionResult> GetPaged(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? sort = null)
    {
        var listings = await _listingService.GetPagedAsync(page, pageSize, sort);
        var totalCount = await _listingService.CountAsync();

        var result = new PagedResultDto<ListingDto>
        {
            Items = listings.ToList(),
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };

        return Ok(ApiResponse<PagedResultDto<ListingDto>>.Ok(result));
    }

    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] FilterListingDto filter)
    {
        var result = await _listingService.FilterAsync(filter);
        return Ok(ApiResponse<PagedResultDto<ListingDto>>.Ok(result));
    }

    [Authorize]
    [HttpPost("{id}/images")]
    public async Task<IActionResult> UploadImages(Guid id, [FromForm] List<IFormFile> files)
    {
        if (files == null || files.Count == 0)
            return BadRequest(ApiResponse<object>.Fail("En az 1 fotoğraf yüklemelisiniz."));

        if (files.Count > 10)
            return BadRequest(ApiResponse<object>.Fail("En fazla 10 fotoğraf yüklenebilir."));

        var imageFolder = _configuration["FileStorage:ImagesFolder"] ?? "images";
        var webRootPath = _webHostEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var uploadPath = Path.Combine(webRootPath, imageFolder);

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        var imageUrls = new List<string>();

        foreach (var file in files)
        {
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                return BadRequest(ApiResponse<object>.Fail("Sadece JPG/PNG yüklenebilir."));

            var fileName = Guid.NewGuid() + extension;
            var filePath = Path.Combine(uploadPath, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            imageUrls.Add($"/{imageFolder}/{fileName}");
        }

        await _listingService.AddImagesAsync(id, imageUrls);

        return Ok(ApiResponse<List<string>>.Ok(imageUrls, "Images uploaded successfully"));
    }

    [Authorize]
    [HttpPost("upload-image")]
    public async Task<IActionResult> UploadImageAlias([FromForm] Guid listingId, [FromForm] List<IFormFile> files)
    {
        return await UploadImages(listingId, files);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] SearchListingDto search)
    {
        if (string.IsNullOrWhiteSpace(search.Keyword)
            && !search.CityId.HasValue
            && !search.LanguageId.HasValue
            && !search.ExperienceLevel.HasValue
            && !search.ServiceType.HasValue
            && !search.MinPrice.HasValue
            && !search.MaxPrice.HasValue
            && !search.MinRating.HasValue)
        {
            return BadRequest(ApiResponse<object>.Fail("En az bir arama filtresi gerekli"));
        }

        var result = await _listingService.SearchAsync(search);
        return Ok(ApiResponse<List<ListingListDto>>.Ok(result));
    }

    [HttpPost("{id}/view")]
    public async Task<IActionResult> AddView(Guid id)
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
        Guid? userId = null;

        if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out var parsedUserId))
            userId = parsedUserId;

        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        await _listingService.IncrementViewAsync(id, userId, ipAddress);

        return Ok(ApiResponse<object>.Ok(null, "View count updated"));
    }
}
