using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<TaskItem> TaskItems { get; set; }
    }
}
