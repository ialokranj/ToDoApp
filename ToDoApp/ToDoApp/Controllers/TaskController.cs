using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Entities;
using ToDoApp.Data;
using System.Linq;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("ByUser/{userId}")]
        public IActionResult GetTasksByUser(int userId)
        {
            var tasks = _context.TaskItems.Where(t => t.UserID == userId).ToList();

            if (!tasks.Any())
            {
                return NotFound("No tasks found for the specified user.");
            }

            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskItem task)
        {
            _context.TaskItems.Add(task);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTasksByUser), new { userId = task.UserID }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskItem updatedTask)
        {
            var task = _context.TaskItems.FirstOrDefault(t => t.TaskID == id);
            if (task == null)
            {
                return NotFound("Task not found.");
            }

            task.TaskTitle = updatedTask.TaskTitle;
            task.TaskDescription = updatedTask.TaskDescription;
            task.TaskStatus = updatedTask.TaskStatus;
            task.TaskDueDate = updatedTask.TaskDueDate;
            task.TaskUpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.TaskItems.FirstOrDefault(t => t.TaskID == id);
            if (task == null)
            {
                return NotFound("Task not found.");
            }

            _context.TaskItems.Remove(task);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
