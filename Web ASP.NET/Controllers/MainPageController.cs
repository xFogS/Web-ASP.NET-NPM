using Microsoft.AspNetCore.Mvc;

namespace Web_ASP.NET.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult LoadPage()
        {
            ViewData["css_style"] = "css/styles.css";
            ViewData["favicon"] = "assets/favicon.ico";
            ViewData["js_fontawesome"] = "https://use.fontawesome.com/releases/v6.3.0/js/all.js";
            ViewData["fonts_Montserrat"] = "https://fonts.googleapis.com/css?family=Montserrat:400,700";
            ViewData["fonts_Roboto_Slab"] = "https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700";
            return View();
        }
    }
}
