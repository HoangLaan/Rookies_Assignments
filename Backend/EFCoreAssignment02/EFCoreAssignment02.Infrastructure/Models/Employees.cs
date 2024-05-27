using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment02.WebApp.Models
{
    public class Employees
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50), MinLength(5)]
        public string Name { get; set; } = string.Empty;

        public Guid DepartmentId { get; set; }
        public DateTime JoinedDated{ get; set; }
        public Salaries Salary { get; set; }
        public Departments Department { get; set; }
        public ICollection<Project_Employee> ProjectEmployees { get; set; }
    }
}
