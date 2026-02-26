using Microsoft.AspNetCore.Mvc;
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
            return Ok(_context.Cities.ToList());
        }
    }
}
