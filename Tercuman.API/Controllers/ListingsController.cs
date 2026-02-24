using Microsoft.AspNetCore.Mvc;
using Tercuman.Application.DTOs.Listing;
using Tercuman.Application.Interfaces;

namespace Tercuman.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly IListingService _listingService;

        public ListingsController(IListingService listingService)
        {
            _listingService = listingService;
        }

        // POST: api/listings
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateListingDto dto)
        {
            // Şimdilik userId sabit (JWT gelince token’dan alacağız)
            Guid userId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            await _listingService.CreateAsync(dto, userId);

            return Ok(new { message = "Listing created successfully" });
        }

        // GET: api/listings?page=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var listings = await _listingService.GetPagedAsync(page, pageSize);
            var totalCount = await _listingService.CountAsync();

            return Ok(new
            {
                data = listings,
                totalCount,
                page,
                pageSize
            });
        }

        // GET: api/listings/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(Guid id)
        {
            var result = await _listingService.GetDetailAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
