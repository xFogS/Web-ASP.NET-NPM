using Microsoft.AspNetCore.Mvc;

namespace Web_ASP.NET.Controllers
{
    public class WildAnimalsController : Controller
    {
        public string Bear()
        {
            return "<h1>Bear</h1>";
        }
        public string Elephant()
        {
            return "<h1>Elephant</h1>";
        }
        public string Snake()
        {
            return "<h1>Snake</h1>";
        }
    }
}
