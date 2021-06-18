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
    [Route("api/users")]
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
            try
            {
                IEnumerable<User> users = _repo.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // $"Internal server error. Message: {ex.Message}"
            }
        }

        // @desc    Fetch single user
        // @route   GET /api/user/:id
        // @access  Protected
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User user = _repo.GetById(id);

            if (user == null)
            {
                return NotFound("The user record couldn't be found.");
            }
            return Ok(user);
        }
    }
}
