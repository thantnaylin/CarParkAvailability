using CarParkAvailability.DataMangers;
using CarParkAvailability.Filters;
using CarParkAvailability.Utilities.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkAvailability.Controllers
{
    [Route("/api/[controller]")]
    public class CarParkController : Controller
    {
        private readonly IConfiguration _config;

        public CarParkController(IConfiguration config)
        {
            _config = config;
        }

        CarParkManager _carPark = new CarParkManager();

        // @desc    Fetch available car parks at current time
        // @route   GET /api/carpark
        // @access  Protected
        [TokenAuthenticationFilter]
        [HttpGet]
        public async Task<object> GetAvailableCarPark()
        {
            try
            {
                string apiurl = _config.GetValue<string>("ApiSettings:ApiUrl");
                var data = await _carPark.GetCarParkAvailabilityData(apiurl);
                return Ok(data);
            }
            catch (Exception ex)
            {
                Error error = new Error { StatusCode = 500, Message = ex.Message };
                return StatusCode(500, error);
            }
            
        }
    }
}
