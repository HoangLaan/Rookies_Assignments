using EFCoreAssignment01.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment01.WebApp
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
                        
        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Salaries> Salaries { get; set; }
        public DbSet<Project_Employee> ProjectEmployees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project_Employee>()
                .HasKey(pc => new { pc.ProjectId, pc.EmployeeId });
            modelBuilder.Entity<Project_Employee>()
                .HasOne(pc => pc.Projects)
                .WithMany(pc => pc.ProjectEmployee)
                .HasForeignKey(c => c.EmployeeId);
            modelBuilder.Entity<Project_Employee>()
               .HasOne(pc => pc.Employees)
               .WithMany(pc => pc.ProjectEmployee)
               .HasForeignKey(c => c.ProjectId);

            modelBuilder.Entity<Employees>()
                .HasOne<Departments>(e => e.Departments)
                .WithMany(g => g.Employees)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Employees>()
                .HasOne(a => a.Salaries)
                .WithOne(a => a.Employees)
                .HasForeignKey<Salaries>(a => a.EmployeeId);

            //// Seed Departments
            modelBuilder.Entity<Departments>().HasData(
                new Departments { Id = Guid.NewGuid(), Name = "Software Development" },
                new Departments { Id = Guid.NewGuid(), Name = "Finance" },
                new Departments { Id = Guid.NewGuid(), Name = "Accountant" },
                new Departments { Id = Guid.NewGuid(), Name = "HR" }
            );
        }
    }
}
