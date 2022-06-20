using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace TaskManagement.Data;

public class TaskManagementDbContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Step> Steps { get; set; }

    public TaskManagementDbContext(DbContextOptions options):base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1434;Database=TaskMgmt;User Id=sa;Password=p@ss0wrd!;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder) 
    {
        builder.Entity<TaskStatus>().HasData(new TaskStatus { 
            Id = 1,
            Status = "New",
            Description = "A new task"
        },
        new TaskStatus
        {
            Id = 2,
            Status = "In Progress",
            Description = "In Progress"
        },
        new TaskStatus
        {
            Id = 3,
            Status = "Complete",
            Description = "Complete"
        }
        );
    }
}
