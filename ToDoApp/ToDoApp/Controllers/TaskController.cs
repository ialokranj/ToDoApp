using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static List<TaskItem> _tasks = new List<TaskItem>();

        // GET: api/Task/ByUser/5
        [HttpGet("ByUser/{userId}")]
        public ActionResult<IEnumerable<TaskItem>> GetTasksByUser(int userId)
        {
            var tasks = _tasks.Where(t => t.UserID == userId).ToList();
            if (!tasks.Any())
            {
                return NotFound("No tasks found for the specified user.");
            }
            return Ok(tasks);
        }

        // POST: api/Task
        [HttpPost]
        public ActionResult<TaskItem> CreateTask([FromBody] TaskItem task)
        {
            // Assign a unique TaskID
            task.TaskID = _tasks.Any() ? _tasks.Max(t => t.TaskID) + 1 : 1;

            // Set timestamps
            task.TaskCreatedAt = DateTime.UtcNow;
            task.TaskUpdatedAt = DateTime.UtcNow;

            // Add the task to the list
            _tasks.Add(task);

            // Return the created task
            return CreatedAtAction(nameof(GetTasksByUser), new { userId = task.UserID }, task);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public ActionResult UpdateTask(int id, [FromBody] TaskItem updatedTask)
        {
            var task = _tasks.FirstOrDefault(t => t.TaskID == id);
            if (task == null)
            {
                return NotFound("Task not found.");
            }

            // Update task properties
            task.TaskTitle = updatedTask.TaskTitle;
            task.TaskDescription = updatedTask.TaskDescription;
            task.TaskStatus = updatedTask.TaskStatus;
            task.TaskDueDate = updatedTask.TaskDueDate;
            task.TaskUpdatedAt = DateTime.UtcNow;

            return NoContent();
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.TaskID == id);
            if (task == null)
            {
                return NotFound("Task not found.");
            }

            // Remove the task
            _tasks.Remove(task);

            return NoContent();
        }
    }
}