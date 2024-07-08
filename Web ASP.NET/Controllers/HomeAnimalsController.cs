using Microsoft.AspNetCore.Mvc;

namespace Web_ASP.NET.Controllers
{
    public class HomeAnimalsController : Controller
    {
        public string Cat()
        {
            return "<h1>Cat</h1>";
        }
        public string Dog()
        {
            return "<h1>Dog</h1>";
        }
        public string Bird()
        {
            return "<h1>Bird</h1>";
        }
    }
}
