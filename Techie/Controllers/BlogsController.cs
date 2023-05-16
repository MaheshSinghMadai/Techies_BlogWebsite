using Microsoft.AspNetCore.Mvc;

namespace Techie.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
