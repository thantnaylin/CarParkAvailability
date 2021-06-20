﻿using CarParkAvailability.DataMangers;
using CarParkAvailability.Utilities.Classes;
using Microsoft.AspNetCore.Mvc;
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
        CarParkManager _carPark = new CarParkManager();

        [HttpGet]
        public async Task<object> GetAvailableCarPark()
        {
            try
            {
                var data = await _carPark.GetCarParkAvailabilityData();
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
