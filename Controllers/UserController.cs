using CarParkAvailability.Models;
using CarParkAvailability.Repository;
using CarParkAvailability.Utilities.Classes;
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
        // @route   GET /api/users
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
                Error error = new Error { StatusCode = 500, Message = ex.Message };
                return StatusCode(500, error); // $"Internal server error. Message: {ex.Message}"
            }
        }

        // @desc    Fetch single user
        // @route   GET /api/users/:id
        // @access  Protected
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                User user = _repo.GetById(id);

                if (user == null)
                {
                    Error error = new Error { StatusCode = 404, Message = "The user record couldn't be found." };
                    return StatusCode(404, error);
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Error error = new Error { StatusCode = 500, Message = ex.Message };
                return StatusCode(500, error);
            }
            
        }
    }
}
