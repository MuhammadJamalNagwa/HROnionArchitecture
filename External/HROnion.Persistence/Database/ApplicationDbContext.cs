using HROnion.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HROnion.Persistence.Database;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
  
    //}
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Position> Positions { get; set; }
}
