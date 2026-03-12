using Microsoft.AspNetCore.Mvc;

namespace Tercuman.API.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
