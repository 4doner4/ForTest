using Microsoft.EntityFrameworkCore;
namespace WebApplication2.Models
{
    public class TaskContext: DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public TaskContext(DbContextOptions<TaskContext> options)
         : base(options) { }
    }
}
