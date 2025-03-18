using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models.Entities
{
    public class TaskItem
    {
        [Key]
        public int TaskID { get; set; }

        [Required]
        public required string TaskTitle { get; set; }

        public required string TaskDescription { get; set; }

        [Required]
        public required string TaskStatus { get; set; } // "Pending" or "Completed"

        public DateTime TaskDueDate { get; set; }

        public DateTime TaskCreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime TaskUpdatedAt { get; set; } = DateTime.UtcNow;
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public required User User { get; set; }

    }
}
