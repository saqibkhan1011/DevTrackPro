using DevTrackPro.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTrackPro.Data;

public class DevTrackDbContext : DbContext
{
    public DevTrackDbContext(DbContextOptions<DevTrackDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Department> Departments => Set<Department>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Employee>()
        .HasOne(e => e.Department)
        .WithMany(d => d.Employees)
        .HasForeignKey(e => e.DepartmentId)
        .OnDelete(DeleteBehavior.Restrict);

    // Seed Departments
    modelBuilder.Entity<Department>().HasData(
        new Department { Id = 1, Name = "Engineering" },
        new Department { Id = 2, Name = "Human Resources" }
    );

    // Seed Employees
    modelBuilder.Entity<Employee>().HasData(
        new Employee { Id = 1, Name = "Saqib Khan", Role = "Software Engineer", DepartmentId = 1 },
        new Employee { Id = 2, Name = "Jane Doe", Role = "HR Manager", DepartmentId = 2 }
    );
}
}