using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment01.WebApp.Models
{
    public class Employees
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength =3, ErrorMessage ="Employee name must be from 3 to 20 letters")]
        public string? Name { get; set; }
        public Guid DepartmentId { get; set; }
        public DateTime JoinedDate { get; set; }
        public Salaries Salaries { get; set; }
        public Departments? Departments { get; set; }
        public ICollection<Project_Employee> ProjectEmployee { get; set; }

    }
}
