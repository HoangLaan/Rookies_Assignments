using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment02.WebApp.Models
{
    public class Project_Employee
    {
        [Key]
        public Guid ProjectId { get; set; }
        [Key]
        public Guid EmployeeId { get; set; }
        [Required]
        public bool Enable { get; set; }
        public Employees Employee { get; set; }
        public Projects Project { get; set; }

    }
}
