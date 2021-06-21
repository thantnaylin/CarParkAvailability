using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkAvailability.Controllers
{
    [Route("/api/[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return StatusCode(200, new {  message = "API Documentation Page" });
        }
    }
}
