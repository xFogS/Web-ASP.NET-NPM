using Microsoft.AspNetCore.Mvc;

namespace Web_ASP.NET.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            List<string> products = new(){ "vegetables", "fruit", "banana", "milk" };
            ViewData["listOfProducts"] = products;
            return View();
        }
    }
}
