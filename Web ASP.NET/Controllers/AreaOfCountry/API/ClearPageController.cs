using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_ASP.NET.Data;
using Web_ASP.NET.Models.Enteties;

namespace Web_ASP.NET.Controllers.AreaOfCountry.API
{
    public class ClearPageController : Controller
    {
        // GET: Country
        public IActionResult Index()
        {
            return View();
        }
    }
}
