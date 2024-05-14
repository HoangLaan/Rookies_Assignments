using EFCoreAssignment02.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment02.WebApp.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Project_Employee> ProjectEmployee { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Salaries> Salaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relative n-n
            modelBuilder.Entity<Project_Employee>()
                .HasKey(p => new { p.EmployeeId, p.ProjectId });
            modelBuilder.Entity<Project_Employee>()
                .HasOne(pc => pc.Project)
                .WithMany(pc => pc.ProjectEmployees)
                .HasForeignKey(c => c.ProjectId);
            modelBuilder.Entity<Project_Employee>()
               .HasOne(pc => pc.Employee)
               .WithMany(pc => pc.ProjectEmployees)
               .HasForeignKey(c => c.EmployeeId);

            //Relative 1-n
            modelBuilder.Entity<Employees>()
                .HasOne<Departments>(p => p.Department)
                .WithMany(p => p.Employess)
                .HasForeignKey(p => p.DepartmentId);

            //Relative 1-1
            modelBuilder.Entity<Employees>()
                .HasOne<Salaries>(p => p.Salary)
                .WithOne(p => p.Employee)
                .HasForeignKey<Salaries>(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Departments>().HasData(
                new Departments { Id = Guid.NewGuid(), Name = "Software Development" },
                new Departments { Id = Guid.NewGuid(), Name = "Finance" },
                new Departments { Id = Guid.NewGuid(), Name = "Accountant" },
                new Departments { Id = Guid.NewGuid(), Name = "HR" });

            modelBuilder.Entity<Projects>().HasData(
                new Departments { Id = Guid.NewGuid(), Name = "MB Bank" },
                new Departments { Id = Guid.NewGuid(), Name = "Techcombank" });

        }
    }
}
