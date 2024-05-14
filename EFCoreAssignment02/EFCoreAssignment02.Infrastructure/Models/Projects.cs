using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment02.WebApp.Models
{
    public class Projects
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50), MinLength(5)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Project_Employee> ProjectEmployees { get; set; }

    }
}
