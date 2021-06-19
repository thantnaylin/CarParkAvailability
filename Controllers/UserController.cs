using CarParkAvailability.DataMangers;
using CarParkAvailability.Filters;
using CarParkAvailability.Models;
using CarParkAvailability.Repository;
using CarParkAvailability.Utilities.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        [TokenAuthenticationFilter]
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            string token = HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token.Split(" ")[1]);
            var securityToken = jsonToken as JwtSecurityToken;

            int userId = Convert.ToInt32(securityToken.Claims.First(claim => claim.Type == "user_id").Value);

            if (userId != id)
            {
                Error error = new Error { StatusCode = 401, Message = "Unauthorized access." };
                return StatusCode(401, error);
            }

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

        // @desc    Create new user
        // @route   POST /api/users
        // @access  Public
        [HttpPost]
        public IActionResult Save([FromBody] User user)
        {
            if (user == null)
            {
                Error error = new Error { StatusCode = 400, Message = "Invalid input(s)." };
                return StatusCode(400, error);
            }

            try
            {
                //Check if email exist
                User existingUser = _repo.GetByEmail(user.Email);

                if (existingUser != null)
                {
                    Error error = new Error { StatusCode = 400, Message = "Email address already exists." };
                    return StatusCode(400, error);
                }

                //Proceed with password hashing and saving
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = hashedPassword;
                _repo.Add(user);
                //return CreatedAtRoute("GetById", new { Id = user.UserId }, user);
                return StatusCode(201, new { Id = user.UserId });
            }
            catch (Exception ex)
            {
                Error error = new Error { StatusCode = 500, Message = ex.Message };
                return StatusCode(500, error);
            }
        }

        // @desc    User login
        // @route   POST /api/users/login
        // @access  Public
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Login loginDetails)
        {
            try
            {
                User user = _repo.GetByEmail(loginDetails.Email);

                if (user == null)
                {
                    Error error = new Error { StatusCode = 401, Message = "Invalid username or password." };
                    return StatusCode(401, error);
                }

                //Validate password
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDetails.Password, user.Password);

                if (isPasswordValid)
                {
                    //Generate JWT token
                    JwtManager jwtManager = new JwtManager();
                    var token = jwtManager.GenerateToken(user.UserId);
                    return Ok(new { Id = user.UserId, Token = token });
                }
                else
                {
                    //Unauthorized access
                    Error error = new Error { StatusCode = 401, Message = "Invalid username or password." };
                    return StatusCode(401, error);
                }
            }
            catch (Exception ex)
            {
                Error error = new Error { StatusCode = 500, Message = ex.Message };
                return StatusCode(500, error);
            }
            
        }
    }
}
