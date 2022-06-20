using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

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
        optionsBuilder.UseSqlServer("Server=localhost,1434;Database=TaskMgmt;User Id=sa;Password=p@ss0wrd!;");
        base.OnConfiguring(optionsBuilder);
    }
}
