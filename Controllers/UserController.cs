using CarParkAvailability.Models;
using CarParkAvailability.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkAvailability.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataRepository<User> _repo;

        public UserController(IDataRepository<User> dataRepository)
        {
            _repo = dataRepository;
        }

        // @desc    Fetch all users
        // @route   GET /api/user
        // @access  Public
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> users = _repo.GetAll();
            return Ok(users);
        }
    }
}
