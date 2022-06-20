using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Data;

public class TaskManagementDbContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Step> Steps { get; set; }

    public TaskManagementDbContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
