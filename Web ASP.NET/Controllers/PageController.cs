using Microsoft.AspNetCore.Mvc;

namespace Web_ASP.NET.Controllers
{
    public class PageController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
