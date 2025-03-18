using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public required string Username { get; set; }
        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string Role { get; set; }
    }
}
