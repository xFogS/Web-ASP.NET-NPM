using Microsoft.AspNetCore.Mvc;
namespace WebApplicationGeo.Controllers;
public class PageController : Controller
{
    public IActionResult ColorPage()
    {
        return View();
    }
}
