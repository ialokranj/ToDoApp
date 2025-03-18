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

        // GET: api/Task/5
        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.TaskID == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST: api/Task
        [HttpPost]
        public ActionResult<TaskItem> CreateTask([FromBody] TaskItem task)
        {
            task.TaskID = _tasks.Any() ? _tasks.Max(t => t.TaskID) + 1 : 1;
            task.TaskCreatedAt = DateTime.UtcNow;
            task.TaskUpdatedAt = DateTime.UtcNow;
            _tasks.Add(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.TaskID }, task);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public ActionResult UpdateTask(int id, [FromBody] TaskItem updatedTask)
        {
            var task = _tasks.FirstOrDefault(t => t.TaskID == id);
            if (task == null)
            {
                return NotFound();
            }

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
                return NotFound();
            }

            _tasks.Remove(task);
            return NoContent();
        }
    }
}