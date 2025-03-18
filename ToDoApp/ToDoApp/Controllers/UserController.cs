using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> _users = new List<User>();

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserID == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            user.UserID = _users.Any() ? _users.Max(u => u.UserID) + 1 : 1;
            _users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.UserID }, user);
        }
    }
}