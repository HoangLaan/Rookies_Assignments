using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment01.WebApp.Models
{
    public class Departments
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Department name must be from 3 to 20 letters")]
        public string? Name { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
