using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment01.WebApp.Models
{
    public class Projects
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Project name must be from 3 to 20 letters")]
        public string? Name { get; set; }
        public ICollection<Project_Employee> ProjectEmployee { get; set; }
    }
}
