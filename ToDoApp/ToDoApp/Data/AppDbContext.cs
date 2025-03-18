using Microsoft.EntityFrameworkCore;
using ToDoApp.Models.Entities;

namespace ToDoApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.User)                 // TaskItem has one User
                .WithMany()          // User has many TaskItems
                .HasForeignKey(t => t.UserID)        // Foreign key is UserID
                .OnDelete(DeleteBehavior.Cascade);    // Cascade delete when User is deleted
        }
    }
}
