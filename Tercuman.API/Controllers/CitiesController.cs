using Microsoft.AspNetCore.Mvc;
using Tercuman.API.Models;
using Tercuman.Domain.Entities;
using Tercuman.Infrastructure.Persistence;

namespace Tercuman.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CitiesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cities = _context.Cities.ToList();
            return Ok(ApiResponse<List<City>>.Ok(cities));
        }
    }
}