using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static List<User> _users = new List<User>();

        // POST: api/Auth/Register
        [HttpPost("Register")]
        public ActionResult<User> Register([FromBody] User user)
        {
            // Check if the email is already registered
            if (_users.Any(u => u.Email == user.Email))
            {
                return BadRequest("Email is already registered.");
            }

            // Assign a unique UserID
            user.UserID = _users.Any() ? _users.Max(u => u.UserID) + 1 : 1;

            // Add the user to the list
            _users.Add(user);

            // Return the created user
            return CreatedAtAction(nameof(Register), new { id = user.UserID }, user);
        }

        // POST: api/Auth/Login
        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody] LoginRequest request)
        {
            // Find the user by email and password
            var user = _users.FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Return the user (in a real app, you would return a JWT token)
            return Ok(user);
        }
    }

    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}